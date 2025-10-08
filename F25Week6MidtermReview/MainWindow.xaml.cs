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
        private List<Employee> _employees;
        private Employee _emp;

        public MainWindow()
        {
            InitializeComponent();

            rdoHourly.IsChecked = true;
            _employees = new List<Employee>();
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

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            rdoHourly.IsChecked = true;
            txtName.Text = txtInput2.Text = txtInput3.Text = "";
            txtGrossEarnings.Text = txtTax.Text = txtNetEarnings.Text = "";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;

            if (rdoHourly.IsChecked == true)
            {
                int hours = Convert.ToInt32(txtInput2.Text);
                double wage = Convert.ToDouble(txtInput3.Text);

                _emp = new HourlyEmployee(name, hours, wage);
            }
            else
            {
                double grossSales = Convert.ToDouble(txtInput2.Text);
                double commissionRate = Convert.ToDouble(txtInput3.Text) / 100;

                _emp = new CommissionEmployee(name, grossSales, commissionRate);
            }

            txtGrossEarnings.Text = _emp.GrossEarnings().ToString("C");
            txtTax.Text = _emp.Tax().ToString("C");
            txtNetEarnings.Text = _emp.NetEarnings().ToString("C");

            lstEmployees.Items.Add(_emp.Name);
            _employees.Add(_emp);
        }

        private void lstEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstEmployees.SelectedItem != null)
            {
                int index = lstEmployees.SelectedIndex;
                _emp = _employees[index];

                txtName.Text = _emp.Name;

                if (_emp is HourlyEmployee hrEmp)
                {
                    //HourlyEmployee hrEmp = _emp as HourlyEmployee;
                    txtInput2.Text = hrEmp.Hours.ToString();
                    txtInput3.Text = hrEmp.Wage.ToString();
                    rdoHourly.IsChecked = true;
                }
                else if (_emp is CommissionEmployee commEmp)
                {
                    txtInput2.Text = commEmp.GrossSales.ToString();
                    txtInput3.Text = (commEmp.CommissionRate * 100).ToString();
                    rdoCommission.IsChecked = true;
                }

                txtGrossEarnings.Text = _emp.GrossEarnings().ToString("C");
                txtTax.Text = _emp.Tax().ToString("C");
                txtNetEarnings.Text = _emp.NetEarnings().ToString("C");
            }
        }
    }
}