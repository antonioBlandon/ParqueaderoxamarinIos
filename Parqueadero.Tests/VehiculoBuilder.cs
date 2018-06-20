using ParqueaderoXamarinIos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueaderoT.Tests
{
    public class VehiculoBuilder
    {

        private String placa;
        private int cilindraje;
        private DateTime fechaIngreso;
        private DateTime fechaSalida;
        private long horasEnParqueadero;
        private long diasEnParqueadero;
        private long valorPagado;

        public VehiculoBuilder()
        {
            placa = "ABC123";
            cilindraje = 0;
            fechaIngreso = DateTime.ParseExact("16/01/1970 11:05", "dd/MM/yyyy HH:mm", new System.Globalization.CultureInfo("en-US")); //Fri Jan 16 1970 11:05:34 GMT-0500
            fechaSalida = DateTime.ParseExact("17/01/1970 14:05", "dd/MM/yyyy HH:mm", new System.Globalization.CultureInfo("en-US")); //Sat Jan 17 1970 14:05:34 GMT-0500
            horasEnParqueadero = 0;
            diasEnParqueadero = 1;
            valorPagado = 11000;
        }

        public VehiculoBuilder withPlacaWithoutAinit(String placa)
        {
            this.placa = placa;
            return this;
        }

        public VehiculoBuilder withFechaValida(DateTime fechaIngreso)
        {
            this.fechaIngreso = fechaIngreso;
            return this;
        }

        public VehiculoBuilder withFechaDeSalida(DateTime fechaSalida)
        {
            this.fechaSalida = fechaSalida;
            return this;
        }

        public VehiculoBuilder withTiempoEnParqueadero(long horasEnParqueadero, long diasEnParqueadero)
        {
            this.horasEnParqueadero = horasEnParqueadero;
            this.diasEnParqueadero = diasEnParqueadero;
            return this;
        }

        public VehiculoBuilder buildMotoWithAltoCilindraje()
        {
            this.cilindraje = 650;
            return this;
        }

        public VehiculoBuilder buildMotoWithBajoCilindraje()
        {
            this.cilindraje = 250;
            return this;
        }

        public Vehiculo build()
        {
            return new Vehiculo(placa, cilindraje, fechaIngreso, fechaSalida, diasEnParqueadero, horasEnParqueadero, valorPagado);
        }

        public static VehiculoBuilder aVehicle()
        {
            return new VehiculoBuilder();
        }

    }
}
