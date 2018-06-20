using NUnit.Framework;
using ParqueaderoXamarinIos.Data;
using ParqueaderoXamarinIos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueaderoT.Tests
{
    [TestFixture]
    class VigilanteImplTest
    {

        Vigilante vigilante = VigilanteImpl.getInstance();
        [Test]
        public void testValidarCantidadCarrosMenor()
        {
            //Arrange 
            int cantidadCarros = 19;
            //Act
            bool puedeIngresar = vigilante.validarCantidadCarros(cantidadCarros);
            //Assert
            Assert.AreEqual(true, puedeIngresar);
        }

        [Test]
        public void testValidarCantidadCarrosMayor()
        {
            //Arrange
            int cantidadCarros = 20;
            //Act
            bool puedeIngresar = vigilante.validarCantidadCarros(cantidadCarros);
            //Assert
            Assert.AreEqual(false, puedeIngresar);
        }

        [Test]
        public void testValidarCantidadMotosMenor()
        {
            //Arrange
            int cantidadMotos = 9;
            //Act
            bool puedeIngresar = vigilante.validarCantidadMotos(cantidadMotos);
            //Assert
            Assert.AreEqual(true, puedeIngresar);
        }

        [Test]
        public void testValidarCantidadMotosMayor()
        {
            //Arrange
            int cantidadMotos = 10;
            //Act
            bool puedeIngresar = vigilante.validarCantidadMotos(cantidadMotos);
            //Assert
            Assert.AreEqual(false, puedeIngresar);
        }

        [Test]
        public void testValidarPlacaSinAInicial()
        {
            //Arrange
            Vehiculo vehiculo = VehiculoBuilder.aVehicle().withPlacaWithoutAinit("BTA234").build();
            int diaDeLaSemana = 3;
            //Act
            bool puedeIngresar = vigilante.validarPlaca(vehiculo.getPlaca(), diaDeLaSemana);
            //Assert
            Assert.AreEqual(true, puedeIngresar);
        }

        [Test]
        public void testValidarPlacaConAInicialDiasValidos()
        {
            //Arrange
            Vehiculo vehiculo = VehiculoBuilder.aVehicle().withFechaValida(DateTime.ParseExact("18/01/1970 08:05", "dd/MM/yyyy HH:mm", new System.Globalization.CultureInfo("en-US"))).build();//Sun Jan 18 1970 08:05:34 GMT-0500
            int diaDeLaSemana = 1;
            //Act
            bool puedeIngresar = vigilante.validarPlaca(vehiculo.getPlaca(), diaDeLaSemana);
            //Assert
            Assert.AreEqual(true, puedeIngresar);
        }

        [Test]
        public void testValidarPlacaConAInicialDiasNoValidos()
        {
            //Arrange
            Vehiculo vehiculo = VehiculoBuilder.aVehicle().build();
            int diaDeLaSemana = 3;
            //Act
            bool puedeIngresar = vigilante.validarPlaca(vehiculo.getPlaca(), diaDeLaSemana);
            //Assert
            Assert.AreEqual(false, puedeIngresar);
        }

        [Test]
        public void testCalcularTiempoVehiculoParqueadero()
        {
            //Arrange
            Vehiculo vehiculo = VehiculoBuilder.aVehicle().build();
            //Act
            long horasEnParqueadero = vigilante.calcularTiempoVehiculoParqueadero(vehiculo.getFechaIngreso(), vehiculo.getFechaSalida());
            //Assert
            Assert.AreEqual(27, horasEnParqueadero);
        }

        //Si el carro permaneció un día y 3 horas se debe cobrar 11.000
        [Test]
        public void testCobrarParqueaderoCarro()
        {
            //Arrange
            Vehiculo vehiculo = VehiculoBuilder.aVehicle()
                    .withTiempoEnParqueadero(3, 1).build();
            Parqueadero parqueadero = ParqueaderoBuilder.aParking().buildParking();
            //Act
            long cobro = vigilante.cobrarParqueadero(vehiculo, parqueadero);
            //Assert
            Assert.AreEqual(11000, cobro);
        }

        //Si la moto permaneció un 10 horas y es de 650CC se cobra 6.000
        [Test]
        public void testCobrarParqueaderoMotoConAltoCilindraje()
        {
            //Arrange
            Vehiculo vehiculo = VehiculoBuilder.aVehicle()
                    .withFechaDeSalida(DateTime.ParseExact("16/01/1970 11:05", "dd/MM/yyyy HH:mm", new System.Globalization.CultureInfo("en-US"))) //Fri Jan 16 1970 21:05:34 GMT-0500
                    .withTiempoEnParqueadero(0, 1)
                    .buildMotoWithAltoCilindraje().build();
            Parqueadero parqueadero = ParqueaderoBuilder.aParking().buildParking();
            //Act
            long cobro = vigilante.cobrarParqueadero(vehiculo, parqueadero);
            //Assert
            Assert.AreEqual(6000, cobro);
        }

        //Si la moto permaneció un 10 horas se cobra 4.000
        [Test]
        public void testCobrarParqueaderoMotoConBajoCilindraje()
        {
            //Arrange
            Vehiculo vehiculo = VehiculoBuilder.aVehicle()
                    .withFechaDeSalida(DateTime.ParseExact("16/01/1970 11:05", "dd/MM/yyyy HH:mm", new System.Globalization.CultureInfo("en-US"))) //Fri Jan 16 1970 21:05:34 GMT-0500
                    .withTiempoEnParqueadero(0, 1)
                    .buildMotoWithBajoCilindraje().build();
            Parqueadero parqueadero = ParqueaderoBuilder.aParking().buildParking();
            //Act
            long cobro = vigilante.cobrarParqueadero(vehiculo, parqueadero);
            //Assert
            Assert.AreEqual(4000, cobro);
        }

        [Test]
        public void testCalcularDiasHoras()
        {
            //Arrange
            Vehiculo vehiculo = VehiculoBuilder.aVehicle().build();
            //Act
            long[] diasHoras = vigilante.calcularDiasHoras(35);
            //Assert
            Assert.AreEqual(new long[] { 2, 0 }, diasHoras);
        }

    }
}
