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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prikazRacuna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /*TODO
         Probaj da sklonis dodatni red u datagrid, iz nekog razloga ima jedan prazan
        --ovo gore se radi tako sto dodas new u puni grid kod selecta, imas primer u posldenjem zadatku u repos--
        
         Dodaj funkcionalnosti dugmeta dodaj,obrisi i izmeni gde je prikaz firma
         Naesti filter i pretragu da rade
         
         */
        public static string idPIb;
        pregledRacunaDataContext pregledRacuna = new pregledRacunaDataContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void puniGrid()
        {
            var firme = from f in pregledRacuna.Firmas
                        select f;

            dataGrid1.ItemsSource = firme;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            puniGrid();
            puniCombo();
        }

        private void dataGrid1_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            string fir = ((Firma)(dataGrid1.SelectedItem)).IDPIB;
            var duguje = (from f in pregledRacuna.Firmas
                          join r in pregledRacuna.Racuns
                          on f.IDPIB equals r.FK_PIB
                          where f.IDPIB == fir
                          select r.Duguje).Sum();

            var potrazuje = (from f in pregledRacuna.Firmas
                             join r in pregledRacuna.Racuns
                             on f.IDPIB equals r.FK_PIB
                             where f.IDPIB == fir
                             select r.Potrazuje).Sum();

            if (duguje == null)
            {
                duguje = 0;
            }
            if (potrazuje == null)
            {
                potrazuje = 0;
            }

            TextBox tb1 = e.DetailsElement.FindName("tbDuguje") as TextBox;
            tb1.Text = duguje.ToString();
            TextBox tb2 = e.DetailsElement.FindName("tbPotrazuje") as TextBox;
            tb2.Text = potrazuje.ToString();
            TextBox tb3 = e.DetailsElement.FindName("tbSaldo") as TextBox;
            tb3.Text = (duguje - potrazuje).ToString();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            if (dataGrid1.SelectedCells.Count == 5)
            {
                idPIb = ((Firma)(dataGrid1.SelectedItem)).IDPIB;
                Racuni racun = new Racuni();
                racun.ShowDialog();
                puniGrid();

            }
            else if (dataGrid1.SelectedCells.Count > 5)
            {
                MessageBox.Show("Izaberite samo 1 firmu");
            }
            else
            {
                MessageBox.Show("Morate izabrati firmu");
            }
        }

        private void btnNova_Click(object sender, RoutedEventArgs e)
        {
            DodajFirmu firmaDodaj = new DodajFirmu();
            firmaDodaj.ShowDialog();
            puniGrid();
        }

        private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
        {

            if (dataGrid1.SelectedCells.Count == 5)
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da izbrisete", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    string id = ((Firma)(dataGrid1.SelectedItem)).IDPIB;
                    Firma brisi = (from f in pregledRacuna.Firmas
                                   where f.IDPIB == id
                                   select f).First();

                    pregledRacuna.Firmas.DeleteOnSubmit(brisi);

                    try
                    {
                        pregledRacuna.SubmitChanges();
                        MessageBox.Show("Uspesno je obrisano");
                        puniGrid();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Doslo je do greske, " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Morate izabrati firmu za brisanje");
            }


        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid1.SelectedCells.Count == 5)
            {
                idPIb = ((Firma)(dataGrid1.SelectedItem)).IDPIB;
                IzmenaFirme izmena = new IzmenaFirme();
                izmena.ShowDialog();
                puniGrid();
            }
            else
            {
                MessageBox.Show("Morate izabrati firmu");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(cmbFilter.SelectedIndex != -1 && !String.IsNullOrEmpty(tbPretraga.Text))
            {
                prikazPodatakaPoFilteruIPretrazi();

            }
            else
            {
                puniGrid();
            }
        }

        private void prikazPodatakaPoFilteruIPretrazi()
        {
            //string pom = "f.";
            //pom += cmbFilter.Text;
            //MessageBox.Show(pom);
            //if(cmbFilter.Text =="PIB")
            //{
            //    pom += "IDPIB";
            //    var rezPretrage = from f in pregledRacuna.Firmas
            //                      where pom.StartsWith(tbPretraga.Text)
            //                      select f;

            //    dataGrid1.ItemsSource = rezPretrage;
            //}
            //TODO: Moras da smanjis ovaj kod a ne da bude ovoliko mnogo, ovo moze mnogo lakse da se uradi
            if (cmbFilter.Text == "PIB")
            {

                var rezPretrage = from f in pregledRacuna.Firmas
                                  where f.IDPIB.StartsWith(tbPretraga.Text)
                                  select f;

                dataGrid1.ItemsSource = rezPretrage;
            }
            else if (cmbFilter.Text == "Maticni broj")
            {
                var rezPretrage = from f in pregledRacuna.Firmas
                                  where f.MB.StartsWith(tbPretraga.Text)
                                  select f;

                dataGrid1.ItemsSource = rezPretrage;
            }
            else if (cmbFilter.Text == "Naziv")
            {
                var rezPretrage = from f in pregledRacuna.Firmas
                                  where f.IDPIB.StartsWith(tbPretraga.Text)
                                  select f;

                dataGrid1.ItemsSource = rezPretrage;
            }
            else if (cmbFilter.Text == "Sediste")
            {
                var rezPretrage = from f in pregledRacuna.Firmas
                                  where f.Sediste.StartsWith(tbPretraga.Text)
                                  select f;

                dataGrid1.ItemsSource = rezPretrage;
            }
            else if (cmbFilter.Text == "Tekuci racun")
            {
                var rezPretrage = from f in pregledRacuna.Firmas
                                  where f.TR.StartsWith(tbPretraga.Text)
                                  select f;

                dataGrid1.ItemsSource = rezPretrage;
            }
        }

        private void puniCombo()
        {
            cmbFilter.Items.Add("PIB");
            cmbFilter.Items.Add("Maticni Broj");
            cmbFilter.Items.Add("Naziv");
            cmbFilter.Items.Add("Sediste");
            cmbFilter.Items.Add("Tekuci racun");
        }
    }
}
