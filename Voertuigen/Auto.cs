﻿using System;
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
        public decimal MaximumSnelheid { get; private set; }
        public decimal ActueleSnelheid { get; private set; }
        public Merken Merk { get; set; }
        private static Random rd = new Random();

        // Constructor aangemaakt bij het intiantiëren van een wagen dienen deze velden minimaal ingegeven
        public Auto(Merken merk, Kleur kleur, int aantalPlaatsen, decimal maxSnelheid)
        {
            Merk = merk;
            KleurAuto = kleur;
            MaximumSnelheid = maxSnelheid;
            AantalPlaatsen = aantalPlaatsen;
        }

        // Constructor voor de aanmaak van een Random Auto
        public Auto()
        {
            Merk = (Merken)rd.Next(0, Enum.GetNames(typeof(Merken)).Length);
            KleurAuto = (Kleur)rd.Next(0, Enum.GetNames(typeof(Kleur)).Length);
            AantalPlaatsen = rd.Next(2, 6);
            MaximumSnelheid = rd.Next(150, 300);
        }


        public void Versnel(decimal waarde)
        {
            ActueleSnelheid += waarde;
            if (ActueleSnelheid > MaximumSnelheid)
            { 
             ActueleSnelheid = MaximumSnelheid;
            }
        }

        public void Vertraag(decimal waarde)
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
