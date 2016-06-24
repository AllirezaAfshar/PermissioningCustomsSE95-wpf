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
    /// Interaction logic for RuleInsertion.xaml
    /// </summary>
    public partial class RuleInsertion : Window
    {
        public RuleInsertion()
        {
            InitializeComponent();
        }

        private void FinalRegistratin_Click(object sender, RoutedEventArgs e)
        {
            Rule newRule = new Rule();
            if (!SourceCountry.Text.Equals(""))
                newRule.CountryOriginConstraints.Add(new EqualityConstraint<string>(SourceCountry.Text));
            if (!ProductType.Text.Equals(""))
                newRule.CommodityNameConstraints.Add(new EqualityConstraint<string>(ProductType.Text));
            if (!MinimumWeight.Text.Equals("") && !MaximumWeight.Text.Equals(""))
                newRule.AmountConstraints.Add(new RangeConstraint<int>(int.Parse(MinimumWeight.Text),int.Parse(MaximumWeight.Text)));

            CustomPermission.rules.Add(newRule);
        }
    }
}
