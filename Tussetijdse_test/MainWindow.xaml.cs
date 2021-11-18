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
using System.Windows.Threading;

namespace Tussetijdse_test
{
    public partial class MainWindow : Window
    {

        public string output;
        public double totaalPrijs;
        public string totaalPrijsString = "";
        public string outputString;

        public DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnVoegToe_Click(object sender, RoutedEventArgs e)
        {
            if (totaalPrijsString.Length > 0)
            {
                totaalPrijsString = "";
                string productNaam = TxtProductNaam.Text;
                double productPrijs = Convert.ToDouble(TxtProductPrijs.Text);
                int productHoeveelheid = Convert.ToInt32(TxtHoeveelheid.Text);
                outputString += $"{productHoeveelheid} X {productNaam}\n";
                totaalPrijs += productHoeveelheid * productPrijs;
                output = outputString;
                TxtOutput.Text = output;
            }
            else
            {
                string productNaam = TxtProductNaam.Text;
                double productPrijs = Convert.ToDouble(TxtProductPrijs.Text);
                int productHoeveelheid = Convert.ToInt32(TxtHoeveelheid.Text);
                outputString += $"{productHoeveelheid} X {productNaam}\n";
                totaalPrijs += productHoeveelheid * productPrijs;
                output = outputString;
                TxtOutput.Text = output;
            }
        }

        public void KaderResultaat(double totaalPrijsArg)
        {
            totaalPrijsString = $" €{totaalPrijsArg.ToString("N2")} ";
            int lengteTotaal = totaalPrijsString.Length;
            totaalPrijsString = "";
            totaalPrijsString += $"\n{String.Concat(Enumerable.Repeat("*", lengteTotaal + 2))}";
            totaalPrijsString += $"\n* €{totaalPrijsArg.ToString("N2")} *";
            totaalPrijsString += $"\n{String.Concat(Enumerable.Repeat("*", lengteTotaal + 2))}\n\n";
            totaalPrijsString += "PXL - Shop";
        }

        private void BtnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            KaderResultaat(totaalPrijs);
            output += totaalPrijsString;
            TxtOutput.Text = output;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            int num = rnd.Next(1, 5);
            AchterGrondKleur(num);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            LblTijd.Content = (DateTime.Now.ToString("HH:mm:ss"));
        }

        private void BtnNieuweBestelling_Click(object sender, RoutedEventArgs e)
        {
            TxtOutput.Clear();
            TxtHoeveelheid.Clear();
            TxtProductNaam.Clear();
            TxtProductPrijs.Clear();
            output = "";
            outputString = "";
            totaalPrijs = 0;
            totaalPrijsString = "";
            outputString = "";
        }

        private void AchterGrondKleur(int kleurcode)
        {
            switch (kleurcode)
            {
                case 1:
                    DPBG.Background = Brushes.Red;
                    break;
                case 2:
                    DPBG.Background = Brushes.Wheat;
                    break;
                case 3:
                    DPBG.Background = Brushes.Gold;
                    break;
                case 4:
                    DPBG.Background = Brushes.Purple;
                    break;
                default:
                    DPBG.Background = Brushes.Green;
                    break;
            }
        }

    }
}
