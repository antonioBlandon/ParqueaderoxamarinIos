using ParqueaderoXamarinIos.Data;
using System;

namespace ParqueaderoXamarinIos.Domain
{
    public interface Vigilante
    {
        bool validarCantidadCarros(int cantidadCarrosActual);

        bool validarCantidadMotos(int cantidadMotosActual);

        bool validarPlaca(String placa, int diaIngresoDeLaSemana);

        long calcularTiempoVehiculoParqueadero(DateTime fechaIngreso, DateTime fechaSalida);

        long cobrarParqueadero(Vehiculo vehiculo, Parqueadero parqueadero);

        long[] calcularDiasHoras(long horas);
    }
}