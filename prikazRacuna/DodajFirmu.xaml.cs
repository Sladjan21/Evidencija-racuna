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

namespace prikazRacuna
{
    /// <summary>
    /// Interaction logic for DodajFirmu.xaml
    /// </summary>
    public partial class DodajFirmu : Window
    {
        pregledRacunaDataContext pregledRacuna = new pregledRacunaDataContext();
        public DodajFirmu()
        {
            InitializeComponent();
        }

        private void tbDodaj_Click(object sender, RoutedEventArgs e)
        {
            dodajFirmu();
            this.Close();
        }

        private void dodajFirmu()
        {
            if (!String.IsNullOrEmpty(tbPIB.Text) && !String.IsNullOrEmpty(tbMB.Text) && !String.IsNullOrEmpty(tbNaziv.Text) &&
                            !String.IsNullOrEmpty(tbSediste.Text) && !String.IsNullOrEmpty(tbTekuci.Text))
            {
                Firma firma = new Firma();
                firma.IDPIB = tbPIB.Text;
                firma.MB = tbMB.Text;
                firma.Naziv = tbNaziv.Text;
                firma.Sediste = tbSediste.Text;
                firma.TR = tbTekuci.Text;

                pregledRacuna.Firmas.InsertOnSubmit(firma);

                try
                {
                    pregledRacuna.SubmitChanges();
                    MessageBox.Show("Uspesno ste dodali firmu");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doslo je do greske, " + ex.Message);
                }
            }
        }
    }
}
