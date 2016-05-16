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
using CustomPermitWPF.Controllers;
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

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            MemoryStatic.AddDoc(new Documents(new User("test","test"),0,txtCommodityName.Text,txtCountryOfOrigin.Text,int.Parse(txtAmount.Text),int.Parse(txtprice.Text)));


            PermitsCartable cartable = new PermitsCartable();
            App.Current.MainWindow = cartable;
            this.Close();
            cartable.Show();
        }
    }
}
