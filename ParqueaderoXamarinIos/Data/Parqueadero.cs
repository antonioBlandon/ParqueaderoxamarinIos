namespace ParqueaderoXamarinIos.Data
{
    public class Parqueadero
    {

        private int adicionCilindraje;
        private int cantidadCarros;
        private int cantidadMotos;
        private long valorDiaCarro;
        private long valorDiaMoto;
        private long valorHoraCarro;
        private long valorHoraMoto;
        private int topeCilindraje;

        static Parqueadero instance;

        public Parqueadero()
        {
            this.adicionCilindraje = 2000;
            this.cantidadCarros = 0;
            this.cantidadMotos = 0;
            this.valorDiaCarro = 8000;
            this.valorDiaMoto = 4000;
            this.valorHoraCarro = 1000;
            this.valorHoraMoto = 500;
            this.topeCilindraje = 500;
        }

        public static Parqueadero getInstance() {
            if (instance == null) {
                instance = new Parqueadero();
            }
            return instance;
        }

        public int getAdicionCilindraje()
        {
            return adicionCilindraje;
        }

        public void setAdicionCilindraje(int adicionCilindraje)
        {
            this.adicionCilindraje = adicionCilindraje;
        }

        public int getCantidadCarros()
        {
            return cantidadCarros;
        }

        public void setCantidadCarros(int cantidadCarros)
        {
            this.cantidadCarros = cantidadCarros;
        }

        public int getCantidadMotos()
        {
            return cantidadMotos;
        }

        public void setCantidadMotos(int cantidadMotos)
        {
            this.cantidadMotos = cantidadMotos;
        }

        public long getValorDiaCarro()
        {
            return valorDiaCarro;
        }

        public void setValorDiaCarro(long valorDiaCarro)
        {
            this.valorDiaCarro = valorDiaCarro;
        }

        public long getValorDiaMoto()
        {
            return valorDiaMoto;
        }

        public void setValorDiaMoto(long valorDiaMoto)
        {
            this.valorDiaMoto = valorDiaMoto;
        }

        public long getValorHoraCarro()
        {
            return valorHoraCarro;
        }

        public void setValorHoraCarro(long valorHoraCarro)
        {
            this.valorHoraCarro = valorHoraCarro;
        }

        public long getValorHoraMoto()
        {
            return valorHoraMoto;
        }

        public void setValorHoraMoto(long valorHoraMoto)
        {
            this.valorHoraMoto = valorHoraMoto;
        }

        public int getTopeCilindraje()
        {
            return topeCilindraje;
        }

        public void setTopeCilindraje(int topeCilindraje)
        {
            this.topeCilindraje = topeCilindraje;
        }

    }
}