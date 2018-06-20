using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using ParqueaderoXamarinIos.Data;
using ParqueaderoXamarinIos.Domain;

namespace ParqueaderoXamarinIos
{
    public partial class ViewController : UIViewController
    {
        public static List<Vehiculo> listVehicles = new List<Vehiculo>();

        public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            btnRegistrar.TouchUpInside += (object sender, EventArgs e) =>
            {
                registrar(textPlaca.Text, textCilindraje.Text);
            };
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            // set the View Controller that’s powering the screen we’re
            // transitioning to

            var cobroParqueaderoController = segue.DestinationViewController as CobroParqueaderoController;

            //set the Table View Controller’s list of phone numbers to the
            // list of dialed phone numbers

            if (cobroParqueaderoController != null)
            {
                cobroParqueaderoController.listVehicles = listVehicles;
            }
        }

        public void agregarVehiculo(Vehiculo vehiculo, Parqueadero parqueadero)
        {
            listVehicles.Add(vehiculo);
            if (vehiculo.getCilindraje() == 0)
            {
                parqueadero.setCantidadCarros(parqueadero.getCantidadCarros() + 1);
            }
            else
            {
                parqueadero.setCantidadMotos(parqueadero.getCantidadMotos() + 1);
            }
            textPlaca.Text = "";
            var alert = UIAlertController.Create("Exito", "El vehículo ingresó exitosamente", UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }

        public Vehiculo crearVehiculo(string placa, int cilindraje)
        {
            return new Vehiculo(placa, cilindraje, DateTime.Now);
        }

        private void registrar(string placa, string cilindraje)
        {
            validarCamposNulos(placa, cilindraje);
        }

        public void showMessageError(string messageError) {
            var alert = UIAlertController.Create("Ocurrio un Inconveniente", messageError, UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }

        public void validarCamposNulos(string placa, string cilindraje)
        {
            if (string.IsNullOrEmpty(placa))
            {
                showMessageError("El campo de placa esta vacío. Ingrese una placa e intente nuevamente");
            }
            else
            {
                if (string.IsNullOrEmpty(cilindraje))
                {
                    validarPlaca(crearVehiculo(placa, 0));
                }
                else
                {
                    validarPlaca(crearVehiculo(placa, int.Parse(cilindraje)));
                }
            }
        }

        public void validarCupoCarro(Vehiculo vehiculo, Parqueadero parqueadero)
        {
            if (VigilanteImpl.getInstance().validarCantidadCarros(parqueadero.getCantidadCarros()))
            {
                validarPlacaExiste(listVehicles, vehiculo);
            }
            else
            {
                showMessageError("El parqueadero no tiene cupo para carros");
            }
        }

        public void validarCupoMoto(Vehiculo vehiculo, Parqueadero parqueadero)
        {
            if (VigilanteImpl.getInstance().validarCantidadMotos(parqueadero.getCantidadMotos()))
            {
                validarPlacaExiste(listVehicles, vehiculo);
            }
            else
            {
                showMessageError("El parqueadero no tiene cupo para motos");
            }
        }

        public void validarPlaca(Vehiculo vehiculo)
        {
            if (VigilanteImpl.getInstance().validarPlaca(vehiculo.getPlaca(), (int)DateTime.Now.DayOfWeek))
            {
                if (vehiculo.getCilindraje() == 0)
                {
                    validarCupoCarro(vehiculo, Parqueadero.getInstance());
                }
                else
                {
                    validarCupoMoto(vehiculo, Parqueadero.getInstance());
                }
            }
            else
            {
                showMessageError("Vehiculo no autorizado para ingresar");
            }
        }

        public void validarPlacaExiste(List<Vehiculo> listVehiculo, Vehiculo newVehicle)
        {
            foreach (Vehiculo vehiculoItem in listVehiculo)
            {
                if (vehiculoItem.getPlaca().Contains(newVehicle.getPlaca()))
                {
                    showMessageError("Hay un vehiculo con la misma placa en el parqueadero. Por favor varifique e intente nuevamente.");
                    return;
                }
            }
            agregarVehiculo(newVehicle, Parqueadero.getInstance());
        }

    }
}