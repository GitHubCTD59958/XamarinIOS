using System;

using UIKit;

namespace AccesoACamara
{
    public partial class ViewController : UIViewController
    {
        UIImage Fotografia;
        UIImagePickerController SeleccionImage;
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
      
        public  override void ViewDidLoad()
        {
            base.ViewDidLoad();
            BtnCam.Layer.CornerRadius = 10;
            BtnBiblio.Layer.CornerRadius = 10;
            BtnCam.Layer.BorderWidth = 5;
            BtnBiblio.Layer.BorderWidth = 5;
            SeleccionImage = new UIImagePickerController();
            SeleccionImage.FinishedPickingMedia += FinalizandoSeleccion;
            SeleccionImage.Canceled += CancelarSeleccion;

            BtnBiblio.TouchUpInside+=delegate {
                SeleccionImage.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
                PresentViewController(SeleccionImage,true,null);
            };
            BtnCam.TouchUpInside += delegate
            {
                SeleccionImage.SourceType = UIImagePickerControllerSourceType.Camera;
                PresentViewController(SeleccionImage, true, null);
            };
        }
        private void FinalizandoSeleccion(object sender,
                                          UIImagePickerMediaPickedEventArgs e)
        {
            Fotografia = e.Info[UIImagePickerController.OriginalImage] as UIImage;
            IMGV.Image = Fotografia;
            SeleccionImage.DismissViewControllerAsync(true);
        }
        private void  CancelarSeleccion(object sender, EventArgs e)
        {
            SeleccionImage.DismissViewControllerAsync(true);
        }
    }
}
