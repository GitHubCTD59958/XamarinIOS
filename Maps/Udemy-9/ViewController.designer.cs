// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Udemy9
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UILabel LblCountry { get; set; }

		[Outlet]
		UIKit.UILabel Lbllatitud { get; set; }

		[Outlet]
		UIKit.UILabel LblLocality { get; set; }

		[Outlet]
		UIKit.UILabel LblLongitud { get; set; }

		[Outlet]
		UIKit.UILabel Lblstate { get; set; }

		[Outlet]
		UIKit.UILabel LblSublocality { get; set; }

		[Outlet]
		MapKit.MKMapView Mapa { get; set; }

		[Outlet]
		UIKit.UITextView TxtDescripcion { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LblCountry != null) {
				LblCountry.Dispose ();
				LblCountry = null;
			}

			if (Lblstate != null) {
				Lblstate.Dispose ();
				Lblstate = null;
			}

			if (Lbllatitud != null) {
				Lbllatitud.Dispose ();
				Lbllatitud = null;
			}

			if (LblLongitud != null) {
				LblLongitud.Dispose ();
				LblLongitud = null;
			}

			if (LblSublocality != null) {
				LblSublocality.Dispose ();
				LblSublocality = null;
			}

			if (LblLocality != null) {
				LblLocality.Dispose ();
				LblLocality = null;
			}

			if (Mapa != null) {
				Mapa.Dispose ();
				Mapa = null;
			}

			if (TxtDescripcion != null) {
				TxtDescripcion.Dispose ();
				TxtDescripcion = null;
			}
		}
	}
}
