using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Voertuigen;

namespace KlassenGebruik
{
    /// <summary>
    /// Interaction logic for Autos.xaml
    /// </summary>
    public partial class Autos : Window
    {
        public Autos()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Opvullen van de comboBoxen

           foreach (string s in Enum.GetNames(typeof(Auto.Kleur)))
            {
                cmbKleur.Items.Add(s);
            } 
            foreach (string s in Enum.GetNames(typeof(Auto.Merken)))
            {
                cmbMerk.Items.Add(s);
            }

            // Netjex : Eerste item Selecteren
            cmbKleur.SelectedIndex = 0;
            cmbMerk.SelectedIndex = 0;

            // Opvullen van de ListBox met Random Autos
            for(int i =0; i<10; i++)
            {
                Auto nieuweAuto = new Auto();
                lstAutos.Items.Add(nieuweAuto);
            }

            // Netjes Selectie van eerste wagen
            lstAutos.SelectedIndex = 0;

        }

        private void btnVoegToe_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int snelheidMax = int.Parse(txtMaxSnelheid.Text);
                int plaatsenAuto = int.Parse(txtPlaatsen.Text);
                Auto nieuweWagen = new Auto((Auto.Merken)Enum.Parse(typeof(Auto.Merken),cmbMerk.SelectedItem.ToString()),(Auto.Kleur)Enum.Parse(typeof(Auto.Kleur),cmbKleur.SelectedItem.ToString()),plaatsenAuto, snelheidMax);
                lstAutos.Items.Add(nieuweWagen);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Kan niet invoegen, foutieve ingave \nReden :\t" + ex.Message, "Foutmelding");
            }
        }

        private void btnVersnel_Click(object sender, RoutedEventArgs e)
        {
            Auto geselecteerdeWagen = (Auto)lstAutos.SelectedItem;
            geselecteerdeWagen.Versnel(20);
            tbActSnelheid.Text = geselecteerdeWagen.ActueleSnelheid.ToString();
        }

        private void btnVertraag_Click(object sender, RoutedEventArgs e)
        {
            Auto geselecteerdeWagen = (Auto)lstAutos.SelectedItem;
            geselecteerdeWagen.Vertraag(20);
            tbActSnelheid.Text = geselecteerdeWagen.ActueleSnelheid.ToString();
        }

        private void lstAutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstAutos.SelectedItem != null)
            {
                Auto geselecteerdeWagen = (Auto)lstAutos.SelectedItem;
                tbMerk.Text = geselecteerdeWagen.Merk.ToString();
                tbKleur.Text = geselecteerdeWagen.KleurAuto.ToString();
                tbPlaatsen.Text = geselecteerdeWagen.AantalPlaatsen.ToString();
                tbMaxSnelheid.Text = geselecteerdeWagen.MaximumSnelheid.ToString();
                tbActSnelheid.Text = geselecteerdeWagen.ActueleSnelheid.ToString();

            }
        }




    }
}
