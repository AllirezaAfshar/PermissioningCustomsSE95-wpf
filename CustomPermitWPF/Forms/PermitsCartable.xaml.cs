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
    /// Interaction logic for PermitsCartable.xaml
    /// </summary>
    public partial class PermitsCartable : Window
    {
        public PermitsCartable()
        {
            InitializeComponent();


            if (MemoryStatic.DocumentList.Count == 0)
            {
                DocumentListView.Content = "هیچ سندی یافت نشد";
            }
            else
            {
                foreach (Documents documentse in MemoryStatic.DocumentList)
                {
                    DocumentListView.Content += string.Format("شماره سند: {0}   نام کالا: {1}  ارزش کالا: {2} ",documentse.ID,documentse.CommodityName,documentse.Price) + Environment.NewLine ;


                }
            }

        }

        private void btnInsertDocument_Click(object sender, RoutedEventArgs e)
        {
            InsertDocument insertDocument = new InsertDocument();
            App.Current.MainWindow = insertDocument;
            this.Close();
            insertDocument.Show();
        }
    }
}
