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
    /// Interaction logic for Racuni.xaml
    /// </summary>
    public partial class Racuni : Window
    {
        private string id = MainWindow.idPIb;
        pregledRacunaDataContext pregledRacuna = new pregledRacunaDataContext();
        public Racuni()
        {
            InitializeComponent();
        }

        //public void puniCombo()
        //{
        //    cmbCalendar.Items.Add("Mesec");
        //    cmbCalendar.Items.Add("Godina");
        //}

        public void prikazStanja()
        {
            var duguje = (from r in pregledRacuna.Racuns
                         where r.FK_PIB == id
                         select r.Duguje).Sum();

            var potrazuje = (from r in pregledRacuna.Racuns
                          where r.FK_PIB == id
                          select r.Potrazuje).Sum();

            if(duguje == null)
            {
                duguje = 0;
            }
            if(potrazuje == null)
            {
                potrazuje = 0;
            }

            tbDuguje.Text = duguje.ToString();
            tbPotrazuje.Text = potrazuje.ToString();
            tbSaldo.Text = (duguje - potrazuje).ToString();
        }

        public void prikazNaziva()
        {
            //jesi doradio
            var naziv = (from f in pregledRacuna.Firmas
                        where f.IDPIB == MainWindow.idPIb
                        select f.Naziv).FirstOrDefault();

            tbNazivFirme.Text = naziv.ToString();
            //tbNazivFirme.Text = naziv.ToString();
        }


        public void puniGrid()
        {
            var racuni = from r in pregledRacuna.Racuns
                         where r.FK_PIB == id
                         select r;

            dataGrid2.ItemsSource = racuni;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            puniGrid();
            //puniCombo(); izbrisano
            prikazStanja();
            prikazNaziva();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeRacuna dodaj = new DodavanjeRacuna();
            dodaj.ShowDialog();
            puniGrid();
            prikazStanja();
        }

        private void btnOsvezi_Click(object sender, RoutedEventArgs e)
        {
            puniGrid();
            prikazStanja();
            prikazNaziva();
        }

        private void tbPretraga_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(tbRacun.Text) && calendar.SelectedDate.HasValue)
            {
                var racun = from r in pregledRacuna.Racuns
                            where r.BR_RAC.StartsWith(tbRacun.Text) && r.FK_PIB == MainWindow.idPIb && r.Datum == calendar.SelectedDate.Value
                            select r;

                dataGrid2.ItemsSource = racun;
            }
            else if(!String.IsNullOrEmpty(tbRacun.Text) && !calendar.SelectedDate.HasValue)
            {
                var racun = from r in pregledRacuna.Racuns
                              where r.BR_RAC.StartsWith(tbRacun.Text) &&r.FK_PIB == MainWindow.idPIb
                              select r;

                dataGrid2.ItemsSource = racun;
            }
            else if(String.IsNullOrEmpty(tbRacun.Text) && calendar.SelectedDate.HasValue)
            {
                var racun = from r in pregledRacuna.Racuns
                            where r.Datum == calendar.SelectedDate.Value.Date && r.FK_PIB == MainWindow.idPIb
                            select r;

                dataGrid2.ItemsSource = racun;
            }
            else
            {
                puniGrid();
            }
            calendar.SelectedDate = null;
        }

        //private void cmbCalendar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if(cmbCalendar.Text == "Mesec")
        //    {
        //        calendar.DisplayMode = CalendarMode.Month;
        //    }
        //    else if(cmbCalendar.Text == "Godina")
        //    {
        //        calendar.DisplayMode = CalendarMode.Year;
        //    }

        //}
    }
}
