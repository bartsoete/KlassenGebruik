using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voertuigen
{
    public class Auto
    {
        public enum Kleur { Groen, Oranje, Rood, Zwart }
        public enum Merken { BMW, Volkswagen, Ford, Mercedes }
        public Kleur KleurAuto { get; set; }
        public int AantalPlaatsen { get; set; }
        public int MaximumSnelheid { get; private set; }
        public int ActueleSnelheid { get; private set; }
        public Merken Merk { get; set; }


        // Constructor aangemaakt bij het intiantiëren van een wagen dienen deze velden minimaal ingegeven
        public Auto(Merken merk, Kleur kleur, int aantalPlaatsen, int maxSnelheid)
        {
            Merk = merk;
            KleurAuto = kleur;
            MaximumSnelheid = maxSnelheid;
            AantalPlaatsen = aantalPlaatsen;
        }

        public void Versnel(int waarde)
        {
            ActueleSnelheid += waarde;
            if (ActueleSnelheid > MaximumSnelheid)
            { 
             ActueleSnelheid = MaximumSnelheid;
            }
        }

        public void Vertraag(int waarde)
        {
            ActueleSnelheid -= waarde;
            if (ActueleSnelheid < 0)
            { 
            ActueleSnelheid = 0;
            }
        }

        // Weergeven van de Auto met een override ToString() => Netjes weergeven in de Listbox
        public override string ToString()
        {
            return Merk + "(" + KleurAuto + ")"; 
        }
    }
}
