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
    /// Interaction logic for DodavanjeRacuna.xaml
    /// </summary>
    public partial class DodavanjeRacuna : Window
    {
        pregledRacunaDataContext pregledRacuna = new pregledRacunaDataContext();
        public DodavanjeRacuna()
        {
            InitializeComponent();
        }

        public bool radio()
        {
            bool tacno = false;
            foreach(RadioButton rb in radioGrupa.Children)
            {
                if(rb.IsChecked == true)
                {
                    tacno = true;
                }
            }
            return tacno;
        }
        public string vratiVrstu()
        {
            string vrsta = "";
            foreach (RadioButton rb in radioGrupa.Children)
            {
                if (rb.IsChecked == true)
                {
                    vrsta = rb.Content.ToString();
                }
            }
            return vrsta;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(tbBroj.Text) && calendar.SelectedDate.HasValue && !String.IsNullOrEmpty(tbIznos.Text) && radio())
            {
                Racun racun = new Racun();
                racun.FK_PIB = MainWindow.idPIb;
                racun.BR_RAC = tbBroj.Text;
                racun.Datum = (DateTime)calendar.SelectedDate;
                if(vratiVrstu() == rbDuguje.Content.ToString())
                {
                    racun.Duguje = float.Parse(tbIznos.Text);
                }
                else
                {
                    racun.Potrazuje = float.Parse(tbIznos.Text);
                }

                pregledRacuna.Racuns.InsertOnSubmit(racun);

                try
                {
                    pregledRacuna.SubmitChanges();
                    MessageBox.Show("Uspesno ste dodali racun");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doslo je do greske prilikom dodavanja, " +ex.Message);
                }

            }
        }
    }
}
