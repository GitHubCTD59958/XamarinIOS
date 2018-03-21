// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CongnitiveServices
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton ButtonDesc { get; set; }

        [Outlet]
        UIKit.UIImageView ImgDetection { get; set; }

        [Outlet]
        UIKit.UITextView TextDescription { get; set; }
        
        void ReleaseDesignerOutlets ()
        {
            if (ImgDetection != null) {
                ImgDetection.Dispose ();
                ImgDetection = null;
            }

            if (TextDescription != null) {
                TextDescription.Dispose ();
                TextDescription = null;
            }

            if (ButtonDesc != null) {
                ButtonDesc.Dispose ();
                ButtonDesc = null;
            }
        }
    }
}
