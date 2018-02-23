using System;
using UIKit;
using Plugin.Geolocator;
using CoreLocation;
using MapKit;

namespace Udemy9
{
    public partial class ViewController : UIViewController
    {

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        double latitud, longitud;
        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            Mapa.ShowsUserLocation = true;

            var Localizador = CrossGeolocator.Current;
            Localizador.DesiredAccuracy = 50;
            var pocision = await Localizador.GetPositionAsync();
            var Ubicacion = new CLLocation(pocision.Latitude, pocision.Longitude);
            var GeoReference = new CLGeocoder();

            var Datos = await GeoReference.ReverseGeocodeLocationAsync(Ubicacion);
            var pais = Datos[0].Country;
            var Estado = Datos[0].AdministrativeArea;
            var Ciudad = Datos[0].Locality;
            var Colonia = Datos[0].SubLocality;
            var Descripcion = Datos[0].Description;
            longitud = pocision.Longitude;
            latitud = pocision.Latitude;

            LblLocality.Text = Ciudad;
            LblSublocality.Text = Colonia;
            LblCountry.Text = pais;
            Lblstate.Text = Estado;
            Lbllatitud.Text = latitud.ToString();
            LblLongitud.Text = longitud.ToString();
            TxtDescripcion.Text = Descripcion;

            Mapa.MapType = MapKit.MKMapType.HybridFlyover;
            var Centrar = new CLLocationCoordinate2D(latitud, longitud);
            var Altura = new MKCoordinateSpan(.003, .003);
            var Region = new MKCoordinateRegion(Centrar, Altura);
            Mapa.SetRegion(Region, true);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
