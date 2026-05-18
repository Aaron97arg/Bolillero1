using System;

namespace Bolillero
{
    public class Bolilla
    {
        // Propiedad de solo lectura: el número de la bolilla no debería cambiar una vez creada
        public int Numero { get; private set; }

        public Bolilla(int numero)
        {
            Numero = numero;
        }

        // Sobrescribimos Equals para poder comparar dos objetos Bolilla por su número de forma directa
        public override bool Equals(object? obj)
        {
            if (obj is Bolilla otraBolilla)
            {
                return this.Numero == otraBolilla.Numero;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Numero.GetHashCode();
        }
    }
}