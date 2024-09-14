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

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            //add delivery charge
            const decimal DELIVERY_CHARGE = 25.00m;
            //add wrap charge
            const decimal WRAP_CHARGE = 5.00m;
            //add GST rate
            const decimal GST_RATE = 1.1m;

            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();
                totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);
                //add totalCharge
                decimal totalCharge = cProduct.TotalPayment + DELIVERY_CHARGE;

                //add totalWrapCharge
                decimal totalWrapCharge = cProduct.TotalPayment + DELIVERY_CHARGE + WRAP_CHARGE;

                //add totalGSTCharge
                decimal totalGSTCharge = totalWrapCharge * GST_RATE;



                //display the total charge in the totalChargeTextBlock
                totalChargeTextBlock.Text = Convert.ToString(totalCharge);

                //display the total charge in the totalChargeWrapTextBlock
                totalChargeWrapTextBlock.Text = Convert.ToString(totalWrapCharge);

                //display the total charge in the totalChargeGSTTextBlock
                totalChargeGSTTextBlock.Text = Convert.ToString(totalGSTCharge);
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
            totalChargeTextBlock.Text = "";  //also clear the total charge field
            totalChargeWrapTextBlock.Text = ""; //clear the total wrap charge field
            totalChargeGSTTextBlock.Text = ""; //clear the total wrap field
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
