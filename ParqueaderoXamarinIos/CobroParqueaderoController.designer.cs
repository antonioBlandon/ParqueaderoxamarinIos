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
    [Register ("CobroParqueaderoController")]
    partial class CobroParqueaderoController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnBuscarPlaca { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCobrarParqueadero { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textBuscarPlaca { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel textCilindraje { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel textFechaIngreso { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel textPlaca { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnBuscarPlaca != null) {
                btnBuscarPlaca.Dispose ();
                btnBuscarPlaca = null;
            }

            if (btnCobrarParqueadero != null) {
                btnCobrarParqueadero.Dispose ();
                btnCobrarParqueadero = null;
            }

            if (textBuscarPlaca != null) {
                textBuscarPlaca.Dispose ();
                textBuscarPlaca = null;
            }

            if (textCilindraje != null) {
                textCilindraje.Dispose ();
                textCilindraje = null;
            }

            if (textFechaIngreso != null) {
                textFechaIngreso.Dispose ();
                textFechaIngreso = null;
            }

            if (textPlaca != null) {
                textPlaca.Dispose ();
                textPlaca = null;
            }
        }
    }
}