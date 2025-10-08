using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace F25Week6MidtermReview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            rdoHourly.IsChecked = true;
        }

        private void rdoCommission_Checked(object sender, RoutedEventArgs e)
        {
            lblInput2.Content = "Gross Sales:";
            lblInput3.Content = "Commission Rate:";
        }

        private void rdoHourly_Checked(object sender, RoutedEventArgs e)
        {
            lblInput2.Content = "Hours Worked:";
            lblInput3.Content = "Hourly Wage:";
        }
    }
}