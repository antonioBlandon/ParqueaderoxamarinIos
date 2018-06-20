using Foundation;
using ParqueaderoXamarinIos.Data;
using ParqueaderoXamarinIos.Domain;
using System;
using System.Collections.Generic;
using UIKit;

namespace ParqueaderoXamarinIos
{
    public partial class CobroParqueaderoController : UIViewController
    {
        public List<Vehiculo> listVehicles { get; set; }
        private Vehiculo vehiculo;
        public CobroParqueaderoController (IntPtr handle) : base (handle)
        {
            listVehicles = new List<Vehiculo>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            btnBuscarPlaca.TouchUpInside += (object sender, EventArgs e) => {
                validarCamposNulos(textBuscarPlaca.Text);
            };
            btnCobrarParqueadero.TouchUpInside += (object sender, EventArgs e) =>
            {
                registrarSalida(vehiculo, Parqueadero.getInstance());
            };
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            // set the View Controller that’s powering the screen we’re
            // transitioning to

            var parqueaderoController = segue.DestinationViewController as ParqueaderoController;

            //set the Table View Controller’s list of phone numbers to the
            // list of dialed phone numbers

            if (parqueaderoController != null)
            {
                parqueaderoController.listVehiculo = listVehicles;
            }
        }

        public void getVehiculo(List<Vehiculo> vehiculoList, String placa)
        {
            Vehiculo vehiculoRetrieve = new Vehiculo();
            foreach (Vehiculo itemVehiculo in vehiculoList)
            {
                if (itemVehiculo.getPlaca().Equals(placa))
                {
                    vehiculoRetrieve = itemVehiculo;
                    break;
                }
            }
            validarPlacaExiste(vehiculoRetrieve);
        }

        public void registrarSalida(Vehiculo vehiculo, Parqueadero parqueadero)
        {
            if (vehiculo != null)
            {
                vehiculo.setFechaSalida(DateTime.Now);
                vehiculo.setValorPagado(cobrar(vehiculo, parqueadero));
                if (vehiculo.getCilindraje() == 0)
                {
                    parqueadero.setCantidadCarros(parqueadero.getCantidadCarros() - 1);
                }
                else
                {
                    parqueadero.setCantidadMotos(parqueadero.getCantidadMotos() - 1);
                }
                listVehicles.Remove(vehiculo);
                showResumen(vehiculo);
            }
        }

        public long cobrar(Vehiculo vehiculo, Parqueadero parqueadero)
        {
            Vigilante vigilante = VigilanteImpl.getInstance();
            long tiempoParqueadero = vigilante.calcularTiempoVehiculoParqueadero(vehiculo.getFechaIngreso(), vehiculo.getFechaSalida());
            long[] diasHoras = vigilante.calcularDiasHoras(tiempoParqueadero);
            vehiculo.setDiasEnParqueadero(diasHoras[0]);
            vehiculo.setHorasEnParqueadero(diasHoras[1]);
            return vigilante.cobrarParqueadero(vehiculo, parqueadero);
        }

        public void setUpInfo(Vehiculo vehiculo)
        {
            String format = @"MM\/dd\/yyyy HH:mm";
            //tlDatosVehiculo.Visibility = ViewStates.Visible;
            textPlaca.Text = vehiculo.getPlaca();
            textFechaIngreso.Text = vehiculo.getFechaIngreso().ToString(format);
            if (vehiculo.getCilindraje() != 0)
            {
                textCilindraje.Text = vehiculo.getCilindraje().ToString();
            }
        }

        public void showAlert(string title, string message)
        {
            var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }

        public void showResumen(Vehiculo vehiculo)
        {
            String format = @"MM\/dd\/yyyy HH:mm";
            showAlert("Resumen", "Placa: " + vehiculo.getPlaca() 
                + "\nFecha Ingreso: " + vehiculo.getFechaIngreso().ToString(format)
                + "\nFecha Salida: " + vehiculo.getFechaSalida().ToString(format)
                + "\nTiempo: " + VigilanteImpl.getInstance().calcularTiempoVehiculoParqueadero(vehiculo.getFechaIngreso(), vehiculo.getFechaSalida()).ToString() + " hora(s)"
                + "\nCosto: " + vehiculo.getValorPagado().ToString());
        }

        public void validarCamposNulos(String placa)
        {
            if (String.IsNullOrEmpty(placa))
            {
                showAlert("Ocurrio un Inconveniente", "Por favor ingrese una placa e intente nuevamente.");
            }
            else
            {
                getVehiculo(listVehicles, placa);
            }
        }

        public void validarPlacaExiste(Vehiculo vehiculo)
        {
            if (vehiculo.getPlaca() != null)
            {
                setUpInfo(vehiculo);
                this.vehiculo = vehiculo;
            }
            else
            {
                showAlert("Ocurrio un Inconveniente", "La placa que esta buscando no existe o ya salió del parquedero. Por favor valide e intente nuevamente");
            }
        }
    }
}