using System;
using System.IO;
using Foundation;
using UIKit;

namespace StorageIMage
{
    public partial class ViewController : UIViewController
    {
        UIImagePickerController SeleccionImage;
        UIImage Fotografia;
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            BtnCam.Layer.CornerRadius = 10;
            BtnBB.Layer.CornerRadius = 10;
            SeleccionImage = new UIImagePickerController();
            SeleccionImage.FinishedPickingMedia += FinalizandoSeleccion;
            SeleccionImage.Canceled += CancelarSeleccion;
            if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))
            {
                SeleccionImage.SourceType = UIImagePickerControllerSourceType.Camera;
            }
            else
            { SeleccionImage.SourceType = UIImagePickerControllerSourceType.PhotoLibrary; }
           
            BtnBB.TouchUpInside += delegate {
                BtnBB.Layer.BorderWidth = 5;
                //Ruta local 
                string RutaCarpeta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                //Nombre Archivo
                string ArchivoLocal = "Foto1.jpg";
                string RutaCompleta = Path.Combine(RutaCarpeta, ArchivoLocal);
                ImgView.Image = UIImage.FromFile(RutaCompleta);

            };
            BtnCam.TouchUpInside += delegate
            {
                PresentViewController(SeleccionImage, true, null);
            };
            // Perform any additional setup after loading the view, typically from a nib.
        }
        private void FinalizandoSeleccion(object sender,
                                        UIImagePickerMediaPickedEventArgs e)
        {
            Fotografia = e.Info[UIImagePickerController.OriginalImage] as UIImage;
           ImgView.Image = Fotografia;
            Fotografia.SaveToPhotosAlbum(delegate (UIImage image, NSError error)
            {
                if (null != error)
                {
                    Console.WriteLine(error.LocalizedDescription);
                }
            });
            Fotografia.AsJPEG();
            ////Ruta local 
            string RutaCarpeta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            ////Nombre Archivo
            string ArchivoLocal = "Foto1.jpg";
            string RutaCompleta = Path.Combine(RutaCarpeta, ArchivoLocal);
            NSError err = null;
            NSData img = Fotografia.AsJPEG();
            img.Save(RutaCompleta,false,out err );
            ImgView.Image = UIImage.FromFile(RutaCompleta);
            SeleccionImage.DismissViewControllerAsync(true);

        }
        private void CancelarSeleccion(object sender, EventArgs e)
        {
            SeleccionImage.DismissViewControllerAsync(true);
        }
       
    }
}
