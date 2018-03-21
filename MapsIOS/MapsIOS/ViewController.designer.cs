// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MapsIOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		MapKit.MKMapView MapX { get; set; }

		[Outlet]
		UIKit.UISegmentedControl Selector { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MapX != null) {
				MapX.Dispose ();
				MapX = null;
			}

			if (Selector != null) {
				Selector.Dispose ();
				Selector = null;
			}
		}
	}
}
