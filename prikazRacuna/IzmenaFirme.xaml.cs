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
    /// Interaction logic for IzmenaFirme.xaml
    /// </summary>
    public partial class IzmenaFirme : Window
    {
        pregledRacunaDataContext pregledRacuna = new pregledRacunaDataContext();
        public IzmenaFirme()
        {
            InitializeComponent();
        }

        public void popuniPolja()
        {
            Firma firma = (from f in pregledRacuna.Firmas
                        where f.IDPIB == MainWindow.idPIb
                        select f).FirstOrDefault();

            tbNaziv.Text = firma.Naziv;
            tbMB.Text = firma.MB;
            tbPIB.Text = firma.IDPIB;
            tbSediste.Text = firma.Sediste;
            tbTekuci.Text = firma.TR;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            popuniPolja();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Firma izmeni = (from f in pregledRacuna.Firmas
                           where f.IDPIB == MainWindow.idPIb
                           select f).First();

            izmeni.Naziv = tbNaziv.Text;
            izmeni.MB = tbMB.Text;
            izmeni.IDPIB = tbPIB.Text;
            izmeni.Sediste = tbSediste.Text;
            izmeni.TR = tbTekuci.Text;

            try
            {
                pregledRacuna.SubmitChanges();
                MessageBox.Show("Uspesno azurirano");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske, " + ex.Message);
            }
        }
    }
}
