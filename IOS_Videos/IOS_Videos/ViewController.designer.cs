// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace IOS_Videos
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton VideoInternet { get; set; }

		[Outlet]
		UIKit.UIButton VideoLocal { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (VideoLocal != null) {
				VideoLocal.Dispose ();
				VideoLocal = null;
			}

			if (VideoInternet != null) {
				VideoInternet.Dispose ();
				VideoInternet = null;
			}
		}
	}
}
