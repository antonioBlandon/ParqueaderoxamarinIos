// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ParqueaderoXamarinIos
{
    [Register ("VehicleTableViewCell")]
    partial class VehicleTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel cilindrajeItemLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel fechaIngresoItemLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ivTypeVehicle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel placaItemLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (cilindrajeItemLabel != null) {
                cilindrajeItemLabel.Dispose ();
                cilindrajeItemLabel = null;
            }

            if (fechaIngresoItemLabel != null) {
                fechaIngresoItemLabel.Dispose ();
                fechaIngresoItemLabel = null;
            }

            if (ivTypeVehicle != null) {
                ivTypeVehicle.Dispose ();
                ivTypeVehicle = null;
            }

            if (placaItemLabel != null) {
                placaItemLabel.Dispose ();
                placaItemLabel = null;
            }
        }
    }
}