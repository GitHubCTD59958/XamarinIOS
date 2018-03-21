using System;
using CoreGraphics;
using UIKit;

namespace GestosUDM
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
        }
        nfloat Rotation=0;
        nfloat CoordenadaX=0;
        nfloat CoordenadaY = 0;
        bool Toque;
        UIRotationGestureRecognizer GestoRotar;
        UIPanGestureRecognizer Gestomover;
        UIAlertController Alert;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Imagen.UserInteractionEnabled = true;
            var GestoToque = new UITapGestureRecognizer(Tocando);
            Gestomover = new UIPanGestureRecognizer(() =>
            {
                if ((Gestomover.State == UIGestureRecognizerState.Began || Gestomover.State == UIGestureRecognizerState.Changed) &&
                                                                                 (Gestomover.NumberOfTouches == 1))
                {
                    var p0 = Gestomover.LocationInView(View);
                    if (CoordenadaX == 0) CoordenadaX = p0.X - Imagen.Center.X;
                    if (CoordenadaY == 0) CoordenadaY = p0.Y - Imagen.Center.Y;
                    var p1 = new CGPoint(p0.X - CoordenadaX, p0.Y - CoordenadaY);
                    Imagen.Center = p1;
                }
                else
                {
                    CoordenadaX = 0;
                    CoordenadaY = 0;
                }
            });
            GestoRotar = new UIRotationGestureRecognizer(() =>
             {
                if((GestoRotar.State==UIGestureRecognizerState.Began || GestoRotar.State == UIGestureRecognizerState.Changed)
                   &&(GestoRotar.NumberOfTouches==2))
                {
                    Imagen.Transform = CGAffineTransform.MakeRotation(GestoRotar.Rotation + Rotation);
                      
                }
                else if(GestoRotar.State== UIGestureRecognizerState.Ended)
                {
                     Rotation = GestoRotar.Rotation;
                }
             });
            Imagen.AddGestureRecognizer(Gestomover);
            Imagen.AddGestureRecognizer(GestoRotar);
            Imagen.AddGestureRecognizer(GestoToque);
                                                   
        }
        void Tocando(UITapGestureRecognizer toque)
        {
            if(!Toque)
            {
                toque.View.Transform *= CGAffineTransform.MakeRotation((float)Math.PI);
                Toque = true;
                Alert = UIAlertController.Create("Imagen Tocada","Imagen Girando",UIAlertControllerStyle.Alert);
                Alert.AddAction(UIAlertAction.Create("Acceptar",UIAlertActionStyle.Default,null));
                PresentViewController(Alert
                                      ,true,null);
            }
            else
            {
                toque.View.Transform *= CGAffineTransform.MakeRotation((float)-Math.PI);
                Toque = false;
                Alert = UIAlertController.Create("Imagen Regresa", "Imagen Regresando", UIAlertControllerStyle.Alert);
                Alert.AddAction(UIAlertAction.Create("Acceptar", UIAlertActionStyle.Default, null));
                PresentViewController(Alert
                                      , true, null);
            }
        }
    }
}
