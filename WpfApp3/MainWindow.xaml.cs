using System.Printing;
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
using WpfApp3.Service;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ICustomerService _customerServcie = new CustomerService();



        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                
                var customerList = _customerServcie.FindAll();

                if (customerList == null || customerList.Count==0)
                {
                    MessageBox.Show("고객이 없습니다");
                    return;
                }

                CustomerGrid.ItemsSource = customerList;

            }
            catch (Exception ex)
            {
                MessageBox.Show("조회 처리 중 오류가 발생했습니다.");
            }

        }

    }
}