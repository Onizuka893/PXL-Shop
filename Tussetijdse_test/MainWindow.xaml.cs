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

namespace Tussetijdse_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string output;
        public double totaalPrijs;
        public string totaalPrijsString = "";

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
                output += $"{productHoeveelheid} X {productNaam}\n";
                totaalPrijs += productHoeveelheid * productPrijs;
                TxtOutput.Text = output;
            }
            else
            {
                string productNaam = TxtProductNaam.Text;
                double productPrijs = Convert.ToDouble(TxtProductPrijs.Text);
                int productHoeveelheid = Convert.ToInt32(TxtHoeveelheid.Text);
                output += $"{productHoeveelheid} X {productNaam}\n";
                totaalPrijs += productHoeveelheid * productPrijs;
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
    }
}
