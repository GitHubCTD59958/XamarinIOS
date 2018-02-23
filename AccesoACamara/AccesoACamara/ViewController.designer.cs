// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AccesoACamara
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton BtnBiblio { get; set; }


        [Outlet]
        UIKit.UIButton BtnCam { get; set; }


        [Outlet]
        UIKit.UIImageView IMGV { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BtnBiblio != null) {
                BtnBiblio.Dispose ();
                BtnBiblio = null;
            }

            if (BtnCam != null) {
                BtnCam.Dispose ();
                BtnCam = null;
            }

            if (IMGV != null) {
                IMGV.Dispose ();
                IMGV = null;
            }
        }
    }
}