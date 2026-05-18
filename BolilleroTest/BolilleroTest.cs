using System.Collections.Generic;
using Bolillero;
using Xunit;

namespace BolilleroTest
{
    public class BolilleroTests
    {
        private readonly BolilleroClase _bolillero;

        public BolilleroTests()
        {
            // El requerimiento pide crear el bolillero con 10 bolillas y la estrategia Primero
            _bolillero = new BolilleroClase(10, new Primero());
        }

        [Fact]
        public void SacarBolilla()
        {
            // Act
            Bolilla bolillaSacada = _bolillero.SacarBolilla();

            // Assert
            Assert.Equal(0, bolillaSacada.Numero);      // Verificar que devuelve la bolilla con número 0
            Assert.Equal(9, _bolillero.Adentro.Count); // Verificar que adentro quedan 9 bolillas
            Assert.Single(_bolillero.Afuera);          // Verificar que afuera hay una bolilla
            Assert.Equal(0, _bolillero.Afuera[0].Numero);
        }

        [Fact]
        public void ReIngresar()
        {
            // Arrange
            _bolillero.SacarBolilla();

            // Act
            _bolillero.Reingresar();

            // Assert
            Assert.Equal(10, _bolillero.Adentro.Count); // Verificar que adentro hay 10 bolillas
            Assert.Empty(_bolillero.Afuera);            // Verificar que afuera no hay ninguna bolilla
        }

        [Fact]
        public void JugarGana()
        {
            // Arrange
            var jugada = new List<Bolilla> 
            { 
                new Bolilla(0), 
                new Bolilla(1), 
                new Bolilla(2), 
                new Bolilla(3) 
            };

            // Act
            bool gano = _bolillero.Jugar(jugada);

            // Assert
            Assert.True(gano); 
        }

        [Fact]
        public void JugarPierde()
        {
            // Arrange
            var jugada = new List<Bolilla> 
            { 
                new Bolilla(4), 
                new Bolilla(2), 
                new Bolilla(1) 
            };

            // Act
            bool gano = _bolillero.Jugar(jugada);

            // Assert
            Assert.False(gano); 
        }

        [Fact]
        public void GanarNVeces()
        {
            // Arrange
            var jugada = new List<Bolilla> 
            { 
                new Bolilla(0), 
                new Bolilla(1) 
            };

            // Act
            int vecesGanadas = _bolillero.JugarNVeces(jugada, 1);

            // Assert
            Assert.Equal(1, vecesGanadas); 
        }
    }
}