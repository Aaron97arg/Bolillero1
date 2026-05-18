using System;

namespace Bolillero
{
    public abstract class GeneradorAzar : IAzar
    {
        public abstract int SacarIndice(int cantidadElementos);
    }

    public class AzarAleatorio : GeneradorAzar
    {
        private readonly Random _random = new Random();
        
        public override int SacarIndice(int cantidadElementos)
        {
            return _random.Next(cantidadElementos);
        }
    }

    public class Primero : GeneradorAzar
    {
        public override int SacarIndice(int cantidadElementos)
        {
            return 0; 
        }
    }
}