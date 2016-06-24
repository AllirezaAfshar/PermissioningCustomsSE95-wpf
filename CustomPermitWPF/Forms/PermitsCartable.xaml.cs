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

            bool isAdmin = CustomPermission.active_user.Role.Equals("admin");
            btnRegisteration.Visibility = isAdmin ? Visibility.Visible : Visibility.Hidden;
            btnAddRule.Visibility = isAdmin ? Visibility.Visible : Visibility.Hidden;

            using (CustomPermission connection = new CustomPermission())
            {
                IEnumerable<Decleration> declerations = connection.Declerations.AsEnumerable();

                if (declerations.Count() == 0)
                {
                    DocumentListView.Content = "هیچ سندی یافت نشد";
                }
                else
                {
                    foreach (Decleration decleration in declerations)
                    {
                        DocumentListView.Content += string.Format("شماره سند: {0}   نام کالا: {1}  ارزش کالا: {2} ", decleration.ID, decleration.CommodityName, decleration.Price) + Environment.NewLine;
                    }
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

        private void btnRegisteration_Click(object sender, RoutedEventArgs e)
        {
            Registeration registerationDocument = new Registeration(this);
            App.Current.MainWindow = registerationDocument;
            this.Close();
            registerationDocument.Show();
        }

        private void btnAddRule(object sender, RoutedEventArgs e)
        {
            RuleInsertion doc = new RuleInsertion();
            App.Current.MainWindow = doc;
            this.Close();
            doc.Show();
        }
    }
}
