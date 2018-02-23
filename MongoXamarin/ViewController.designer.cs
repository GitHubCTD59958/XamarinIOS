// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace App
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton BtnInsert { get; set; }

		[Outlet]
		UIKit.UITextField txtLastName { get; set; }

		[Outlet]
		UIKit.UITextField txtName { get; set; }

		[Outlet]
		UIKit.UITextField txtseCondLastName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BtnInsert != null) {
				BtnInsert.Dispose ();
				BtnInsert = null;
			}

			if (txtLastName != null) {
				txtLastName.Dispose ();
				txtLastName = null;
			}

			if (txtName != null) {
				txtName.Dispose ();
				txtName = null;
			}

			if (txtseCondLastName != null) {
				txtseCondLastName.Dispose ();
				txtseCondLastName = null;
			}
		}
	}
}
