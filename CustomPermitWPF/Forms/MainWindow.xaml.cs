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
using CustomPermitWPF.Controllers;
using CustomPermitWPF.Forms;
using CustomPermitWPF.Model;

namespace CustomPermitWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {

            if (Authentication.Login(txtUserName.Text, txtPassword.Password))
            {
                PermitsCartable cartable = new PermitsCartable();
                App.Current.MainWindow = cartable;
                this.Close();
                cartable.Show();
            }
            else
            {
                txtUserName.Clear();
                txtPassword.Clear();
            }
        }
    }
}
