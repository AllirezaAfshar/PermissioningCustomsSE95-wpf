using CustomPermitWPF.Controllers;
using CustomPermitWPF.Model;
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

namespace CustomPermitWPF.Forms
{
    /// <summary>
    /// Interaction logic for Registeration.xaml
    /// </summary>
    public partial class Registeration : Window
    {
        public Window returnWindow = new PermitsCartable();

        public Registeration(Window returnWindow)
        {
            InitializeComponent();
            this.returnWindow = returnWindow;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {

            ComboBoxItem roleItem = (ComboBoxItem)comboBox.SelectedItem;
            string role = "Normal";
            if (((string)roleItem.Content).Equals("ادمین"))
                role = "Admin";
            
            if (Authentication.Register(txtUserName.Text, txtPassword.Password, role))
            {
                App.Current.MainWindow = returnWindow;
                this.Close();
                returnWindow.Show();
            }
            else
            {
                txtUserName.Clear();
                txtPassword.Clear();
            }
        }
    }
}
