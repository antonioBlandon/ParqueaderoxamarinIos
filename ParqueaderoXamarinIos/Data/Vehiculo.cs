using System;

namespace ParqueaderoXamarinIos.Data
{
    public class Vehiculo
    {
        private int cilindraje;
        private DateTime fechaIngreso;
        private DateTime fechaSalida;
        private String placa;
        private long diasEnParqueadero;
        private long horasEnParqueadero;
        private long valorPagado;

        public Vehiculo() { }

        public Vehiculo(String placa, int cilindraje, DateTime fechaIngreso)
        {
            this.placa = placa;
            this.cilindraje = cilindraje;
            this.fechaIngreso = fechaIngreso;
        }

        public Vehiculo(String placa, int cilindraje, 
            DateTime fechaIngreso, DateTime fechaSalida,
            long diasEnParqueadero, long horasEnParqueadero, long valorPagado)
        {
            this.placa = placa;
            this.cilindraje = cilindraje;
            this.fechaIngreso = fechaIngreso;
            this.fechaSalida = fechaSalida;
            this.diasEnParqueadero = diasEnParqueadero;
            this.horasEnParqueadero = horasEnParqueadero;
            this.valorPagado = valorPagado;
        }

        public int getCilindraje()
        {
            return cilindraje;
        }

        public void setCilindraje(int cilindraje)
        {
            this.cilindraje = cilindraje;
        }

        public DateTime getFechaIngreso()
        {
            return fechaIngreso;
        }

        public void setFechaIngreso(DateTime fechaIngreso)
        {
            this.fechaIngreso = fechaIngreso;
        }

        public DateTime getFechaSalida()
        {
            return fechaSalida;
        }

        public void setFechaSalida(DateTime fechaSalida)
        {
            this.fechaSalida = fechaSalida;
        }

        public String getPlaca()
        {
            return placa;
        }

        public void setPlaca(String placa)
        {
            this.placa = placa;
        }

        public long getDiasEnParqueadero()
        {
            return diasEnParqueadero;
        }

        public void setDiasEnParqueadero(long diasEnParqueadero)
        {
            this.diasEnParqueadero = diasEnParqueadero;
        }

        public long getHorasEnParqueadero()
        {
            return horasEnParqueadero;
        }

        public void setHorasEnParqueadero(long horasEnParqueadero)
        {
            this.horasEnParqueadero = horasEnParqueadero;
        }

        public long getValorPagado()
        {
            return valorPagado;
        }

        public void setValorPagado(long valorPagado)
        {
            this.valorPagado = valorPagado;
        }

    }
}