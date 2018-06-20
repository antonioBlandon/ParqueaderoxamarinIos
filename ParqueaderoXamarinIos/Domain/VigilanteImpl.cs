using System;
using ParqueaderoXamarinIos.Data;

namespace ParqueaderoXamarinIos.Domain
{
    public class VigilanteImpl : Vigilante
    {

        static VigilanteImpl reference;

        public static VigilanteImpl getInstance()
        {
            if (reference == null)
            {
                reference = new VigilanteImpl();
            }
            return reference;
        }

        public  VigilanteImpl()
        {
        }

        public long[] calcularDiasHoras(long horas)
        {
            long dias = 0;
            long[] diasHoras = new long[2];
            while (horas >= 0)
            {

                if (horas > 9)
                {
                    dias++;
                    horas = horas - 24;
                }
                else
                {
                    break;
                }

            }
            if (horas < 0)
            {
                horas = 0;
            }
            diasHoras[0] = dias;
            diasHoras[1] = horas;
            return diasHoras;
        }

        public long calcularTiempoVehiculoParqueadero(DateTime fechaIngreso, DateTime fechaSalida)
        {
            TimeSpan span = fechaSalida.Subtract(fechaIngreso);
            int MINUTOS_EN_UNA_HORA = 60;
            long tiempo = Convert.ToInt64(Math.Ceiling(span.TotalMinutes/MINUTOS_EN_UNA_HORA));
            return tiempo;
        }

        public long cobrarParqueadero(Vehiculo vehiculo, Parqueadero parqueadero)
        {
            long valor = 0;
            if (vehiculo.getCilindraje() != 0)
            {
                valor = (vehiculo.getDiasEnParqueadero() * parqueadero.getValorDiaMoto())
                        + (vehiculo.getHorasEnParqueadero() * parqueadero.getValorHoraMoto());
                if (vehiculo.getCilindraje() > parqueadero.getTopeCilindraje())
                {
                    valor = valor + parqueadero.getAdicionCilindraje();
                }
            }
            else
            {
                valor = (vehiculo.getDiasEnParqueadero() * parqueadero.getValorDiaCarro())
                        + (vehiculo.getHorasEnParqueadero() * parqueadero.getValorHoraCarro());
            }
            return valor;
        }

        public bool validarCantidadCarros(int cantidadCarrosActual)
        {
            int cantidadCarros = cantidadCarrosActual + 1;
            return cantidadCarros <= 20;
        }

        public bool validarCantidadMotos(int cantidadMotosActual)
        {
            int cantidadMotos = cantidadMotosActual + 1;
            return cantidadMotos <= 10;
        }

        public bool validarPlaca(string placa, int diaIngresoDeLaSemana)
        {
            String primeraLetra = placa.Substring(0, 1);
            if (primeraLetra.Equals("A"))
            {
                //Dias validos
                int lunes = 1;
                int domingo = 0;

                return ((diaIngresoDeLaSemana == domingo) || (diaIngresoDeLaSemana == lunes));

            }
            return true;
        }
    }
}