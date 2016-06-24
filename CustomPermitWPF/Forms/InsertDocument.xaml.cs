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
using CustomPermitWPF.Domain;

namespace CustomPermitWPF.Forms
{
    /// <summary>
    /// Interaction logic for InsertDocument.xaml
    /// </summary>
    public partial class InsertDocument : Window
    {
        public InsertDocument()
        {
            InitializeComponent();
        }

        private void button_restart(object sender, RoutedEventArgs e)
        {
        }

        private void button_submit(object sender, RoutedEventArgs e)
        {
            using (CustomPermission connection = new CustomPermission())
            {
                Decleration dec = new Decleration(CustomPermission.active_user, 0, ImportedGoods.Text, SourceCountry.Text, int.Parse(Amount.Text), int.Parse(PriceOfAUnit.Text));
                dec.User = null;
                connection.Declerations.Add(dec);
                connection.SaveChanges();
                dec.User = CustomPermission.active_user;
            }

            PermitsCartable cartable = new PermitsCartable();
            App.Current.MainWindow = cartable;
            this.Close();
            cartable.Show();
        }
    }
}
