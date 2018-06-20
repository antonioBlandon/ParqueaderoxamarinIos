using Foundation;
using System;
using UIKit;

namespace ParqueaderoXamarinIos
{
    public partial class DetailsController : UIViewController
    {
        public string placa;
        public DetailsController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            labelDetail.Text = placa;
        }
    }
}