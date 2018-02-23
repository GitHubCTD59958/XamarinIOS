using System;
using CoreGraphics;
using AVFoundation;
using Foundation;
using UIKit;

namespace IOS_Videos
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            VideoLocal.Layer.CornerRadius = 10;
            VideoInternet.Layer.CornerRadius = 10;
            VideoLocal.TouchUpInside+=delegate {
                AVPlayer Reproductor;
                AVPlayerLayer CapaRedproductor;
                AVAsset Recurso;
                AVPlayerItem RecursoReproducir;
                Recurso = AVAsset.FromUrl(NSUrl.FromFilename("toystory.mp4"));
                RecursoReproducir = new AVPlayerItem(Recurso);
                Reproductor = new AVPlayer(RecursoReproducir);
                CapaRedproductor = AVPlayerLayer.FromPlayer(Reproductor);
                CapaRedproductor.Frame = new CGRect(50, 100, 300, 300);
                View.Layer.AddSublayer(CapaRedproductor);
                Reproductor.Play();
            };
            VideoInternet.TouchUpInside+=delegate {
                AVPlayer Reproductor;
                AVPlayerLayer CapaRedproductor;
                AVAsset Recurso;
                AVPlayerItem RecursoReproducir;
                Recurso = AVAsset.FromUrl(NSUrl.FromString("https://www.rmp-streaming.com/media/bbb-360p.mp4"));
                RecursoReproducir = new AVPlayerItem(Recurso);
                Reproductor = new AVPlayer(RecursoReproducir);
                CapaRedproductor = AVPlayerLayer.FromPlayer(Reproductor);
                CapaRedproductor.Frame = new CGRect(50, 100, 300, 300);
                View.Layer.AddSublayer(CapaRedproductor);
                Reproductor.Play(); 
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
