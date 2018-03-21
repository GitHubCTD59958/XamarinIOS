using System;
using CoreLocation;
using Foundation;
using Geolocator.Plugin;
using MapKit;
using UIKit;


namespace MapsIOS
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        MyMapDelegate mapDel;
        CLLocationManager locationManager = new CLLocationManager();

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);


            ////Darle una longitud y latidud ubicacino.
            var Centrar = new CLLocationCoordinate2D(21.151777, -101.712158);
            var UDLSB = new CLLocationCoordinate2D
                (position.Latitude, position.Longitude);
            var Altura = new MKCoordinateSpan(.003, .003);
            var Region = new MKCoordinateRegion(UDLSB, Altura);
            MapX.SetRegion(Region, true);

            #region Selector
            Selector.ValueChanged += (s, e) =>
            {
                switch (Selector.SelectedSegment)
                {
                    case 0:
                        MapX.MapType = MKMapType.Standard;
                        break;
                    case 1:
                        MapX.MapType = MKMapType.Satellite;
                        break;
                    case 2:
                        MapX.MapType = MKMapType.HybridFlyover;
                        break;
                }
            };
            #endregion
            MapX.ZoomEnabled = false;
            MapX.ScrollEnabled = false;
            mapDel = new MyMapDelegate();
            MapX.Delegate = mapDel;

            // add an annotation 

            //MapX.AddAnnotations(new MKPointAnnotation()
            //{
            //    Title = "MyAnnotation",
            //    Subtitle = "Im Here",
            //    Coordinate = new CLLocationCoordinate2D(21.151777, -101.712155)
            //});

           // MapX.AddAnnotation(new MonkeyAnnotation("Xamarin", Centrar));

            MapX.AddAnnotation(new MonkeyAnnotation("Xamarin", UDLSB));

        }


        class MyMapDelegate : MKMapViewDelegate
        {
            string pId = "PinAnnotation";
            string mId = "MonkeyAnnotation";

            public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
            {
                MKAnnotationView anView;

                if (annotation is MKUserLocation)
                    return null;

                if (annotation is MonkeyAnnotation)
                {

                    // show monkey annotation
                    anView = mapView.DequeueReusableAnnotation(mId);

                    if (anView == null)
                        anView = new MKAnnotationView(annotation, mId);

                    anView.Image = UIImage.FromFile("Xamarin.png");
                    anView.CanShowCallout = true;
                    anView.Draggable = true;
                    anView.RightCalloutAccessoryView = UIButton.FromType(UIButtonType.DetailDisclosure);

                }
                else
                {

                    // show pin annotation
                    anView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation(pId);

                    if (anView == null)
                        anView = new MKPinAnnotationView(annotation, pId);

                    ((MKPinAnnotationView)anView).PinColor = MKPinAnnotationColor.Red;
                    anView.CanShowCallout = true;
                }

                return anView;
            }
            public override void CalloutAccessoryControlTapped(MKMapView mapView, MKAnnotationView view, UIControl control)
            {
                var monkeyAn = view.Annotation as MonkeyAnnotation;

                if (monkeyAn != null)
                {
                    var alert = new UIAlertView("Monkey Annotation", monkeyAn.Title, null, "OK");
                    alert.Show();
                }
            }

        }
        public class MonkeyAnnotation : MKAnnotation
        {
            string title;
      
            CLLocationCoordinate2D coord;

            public MonkeyAnnotation(string title, CLLocationCoordinate2D coord)
            {
                this.title = title;
                this.coord = coord;
            }

            public override string Title
            {
                get
                {
                    return title;
                }
            }
       
            public override CLLocationCoordinate2D Coordinate
            {
                get
                {
                    return coord;
                }
            }
        }
    }

}
