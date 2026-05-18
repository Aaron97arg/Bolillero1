using System;
using System.Collections.Generic;

namespace Bolillero
{
    public class BolilleroClase
    {
        // Ahora manejamos colecciones de objetos Bolilla
        public List<Bolilla> Adentro { get; private set; }
        public List<Bolilla> Afuera { get; private set; }
        
        private readonly IAzar _azar;

        public BolilleroClase(int cantidad, IAzar azar)
        {
            _azar = azar;
            Adentro = new List<Bolilla>();
            Afuera = new List<Bolilla>();

            // Instanciamos objetos Bolilla correlativos del 0 al N-1
            for (int i = 0; i < cantidad; i++)
            {
                Adentro.Add(new Bolilla(i));
            }
        }

        public Bolilla SacarBolilla()
        {
            if (Adentro.Count == 0)
                throw new InvalidOperationException("No quedan bolillas en el bolillero.");

            int indice = _azar.SacarIndice(Adentro.Count);
            Bolilla bolillaSacada = Adentro[indice];

            // Efecto de lado
            Adentro.RemoveAt(indice);
            Afuera.Add(bolillaSacada);

            return bolillaSacada;
        }

        public void Reingresar()
        {
            Adentro.AddRange(Afuera);
            Afuera.Clear();
        }

        public bool Jugar(List<Bolilla> jugada)
        {
            foreach (Bolilla bolillaEsperada in jugada)
            {
                // Gracias a la sobrescritura de Equals en Bolilla, 
                // podemos comparar los objetos directamente con el operador !=
                if (!SacarBolilla().Equals(bolillaEsperada))
                {
                    return false;
                }
            }
            return true;
        }

        public int JugarNVeces(List<Bolilla> jugada, int veces)
        {
            int victorias = 0;
            for (int i = 0; i < veces; i++)
            {
                if (Jugar(jugada))
                {
                    victorias++;
                }
                Reingresar();
            }
            return victorias;
        }
    }
}