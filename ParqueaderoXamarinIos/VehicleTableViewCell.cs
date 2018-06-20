using Foundation;
using ParqueaderoXamarinIos.Data;
using System;
using UIKit;

namespace ParqueaderoXamarinIos
{
    public partial class VehicleTableViewCell : UITableViewCell
    {
        private Vehiculo vehiculo;
        private String format = @"MM\/dd\/yyyy HH:mm";
        private string PATH_CAR_IMAGE = "images/car.png";
        private string PATH_MOTO_IMAGE = "images/scooter.png";

        public Vehiculo VehiculoData
        {
            get { return vehiculo; }
            set
            {
                vehiculo = value;

                placaItemLabel.Text = vehiculo.getPlaca();
                cilindrajeItemLabel.Text = vehiculo.getCilindraje().ToString();
                fechaIngresoItemLabel.Text = vehiculo.getFechaIngreso().ToString();
                if (vehiculo.getCilindraje() == 0)
                {
                    ivTypeVehicle.Image = UIImage.FromFile(PATH_CAR_IMAGE);
                }
                else {
                    ivTypeVehicle.Image = UIImage.FromFile(PATH_MOTO_IMAGE);
                }

            }
        }
        public VehicleTableViewCell (IntPtr handle) : base (handle)
        {
        }
    }
}