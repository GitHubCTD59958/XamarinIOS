// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace StorageIMage
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton BtnBB { get; set; }

		[Outlet]
		UIKit.UIButton BtnCam { get; set; }

		[Outlet]
		UIKit.UIImageView ImgView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ImgView != null) {
				ImgView.Dispose ();
				ImgView = null;
			}

			if (BtnBB != null) {
				BtnBB.Dispose ();
				BtnBB = null;
			}

			if (BtnCam != null) {
				BtnCam.Dispose ();
				BtnCam = null;
			}
		}
	}
}
