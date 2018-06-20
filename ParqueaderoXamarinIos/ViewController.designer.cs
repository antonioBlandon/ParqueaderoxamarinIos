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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnIrACobrar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnRegistrar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textCilindraje { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textPlaca { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnIrACobrar != null) {
                btnIrACobrar.Dispose ();
                btnIrACobrar = null;
            }

            if (btnRegistrar != null) {
                btnRegistrar.Dispose ();
                btnRegistrar = null;
            }

            if (textCilindraje != null) {
                textCilindraje.Dispose ();
                textCilindraje = null;
            }

            if (textPlaca != null) {
                textPlaca.Dispose ();
                textPlaca = null;
            }
        }
    }
}