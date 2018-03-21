using System;
using CoreAnimation;
using CoreGraphics;
using CoreMotion;
using Foundation;
using LocalAuthentication;
using UIKit;

namespace SensoresUDM8
{
    public partial class ViewController : UIViewController
    {
        CMMotionManager Movimeinto;
        UIAlertController Alert;
        nfloat Ancho;
        nfloat Altura;
        nfloat AnchoCapa;
        nfloat AlturaCapa;
        nfloat ActualziaX;
        nfloat ActulizaY;
        CALayer Capaimagen;
        protected ViewController(IntPtr handle) : base(handle)
        {

        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            try
            {
                //MoverIMagen con el iphone 
                var verificar = new LAContext();
                var autorizar = await verificar.EvaluatePolicyAsync(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, "Autenticacion Biometric");
                if (autorizar.Item1)
                {
                    Altura = View.Bounds.Width;
                    Ancho = View.Bounds.Height;
                    AnchoCapa = Altura / 2;
                    AlturaCapa = Altura / 2;
                    Capaimagen = new CALayer();
                    Capaimagen.Bounds = new CGRect(Altura / 2 - AnchoCapa / 2, Ancho / 2 - AlturaCapa, AnchoCapa, AlturaCapa);
                    Capaimagen.Position = new CGPoint(100, 100);
                    Capaimagen.Contents = UIImage.FromFile("angel-chest-tattoo-for-men.jpg").CGImage;
                    View.Layer.AddSublayer(Capaimagen);
                    var Actuliza = Capaimagen.Frame;
                    Movimeinto = new CMMotionManager();
                    if(Movimeinto.AccelerometerAvailable)
                    {
                        Movimeinto.AccelerometerUpdateInterval = 0.02;
                        Movimeinto.StartAccelerometerUpdates(NSOperationQueue.CurrentQueue, (data, error) =>
                         {
                            ActualziaX = Capaimagen.Frame.X;
                             ActulizaY = Capaimagen.Frame.Y;
                            if(ActualziaX+(nfloat)data.Acceleration.X*10> 0 && ActualziaX+(nfloat)data.Acceleration.X*10 < Altura-AnchoCapa)
                            {
                                 Actuliza.X = ActualziaX + (nfloat)data.Acceleration.X * 10;
                            }
                            if (ActulizaY + (nfloat)data.Acceleration.Y* 10 > 0 && ActulizaY + (nfloat)data.Acceleration.Y* 10 < Ancho - AlturaCapa)
                             {
                                Actuliza.Y = ActulizaY + (nfloat)data.Acceleration.Y * 10;
                             }
                            Lblx.Text=data.Acceleration.X.ToString("0.0");
                            Lbly.Text=data.Acceleration.Y.ToString("0.0");
                            Lblz.Text=data.Acceleration.Z.ToString("0.0");
                             Capaimagen.Frame = Actuliza;
                        });

                    }
                }
                else
                {
                    System.Threading.Thread.CurrentThread.Abort();
                }
            }
            catch (Exception ex)
            {
                Alert = UIAlertController.Create("Status", ex.Message, UIAlertControllerStyle.Alert);
                Alert.AddAction(UIAlertAction.Create("Aceptar", UIAlertActionStyle.Default, null));
                PresentViewController(Alert, true, null);
            }

        }
    }
}
