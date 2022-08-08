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

namespace Bowenslab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double total = 0, tax = 0; //decare the toal and the tax
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            //clear the listbox and all the label with HST and total
            lstItems.Items.Clear();
        }


        //combo box toy event
        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            double electronics = 0, books = 0, jewelary = 0, toys = 0; //declare the variable
            const double HST = 0.13; //declare the HST tax variable

            if (cmbElectronics.SelectedIndex >= 0) //combox item is selected
            {
                electronics = 300; //set the price
                lstItems.Items.Add(cmbElectronics.Text + " : " + electronics); //add items to the listbox           
            }

            if (cmbBooks.SelectedIndex >= 0) //combox item is selected
            {
                books = 200; //set the price
                lstItems.Items.Add(cmbBooks.Text + " : " + books); //add items to the listbox           

            }

            if (cmbJewelry.SelectedIndex >= 0) //combox item is selected
            {
                jewelary = 250; //set the price
                lstItems.Items.Add(cmbJewelry.Text + " : " + jewelary);   //add items to the listbox              
            }

            if (cmbToys.SelectedIndex >= 0) //combox item is selected
            {
                toys = 100; //set the price
                lstItems.Items.Add(cmbToys.Text + " : " + toys);    //add items to the listbox           
            }

            tax = (electronics + books + jewelary + toys) * HST; //calculate the tax
            total = tax + (electronics + books + jewelary + toys); //calculate the total

            //displayt to the label

            lblHST.Content = tax;
            lblTotal.Content = total;
        }
    }
}
