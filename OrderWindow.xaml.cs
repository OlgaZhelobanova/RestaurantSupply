using BLLnew;
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

namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        CRUD db = new CRUD();
        public OrderWindow()
        {
            InitializeComponent();

            c1.ItemsSource = db.GetAllProducts();
            c2.ItemsSource = db.GetAllDoers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            OrderBLL order = new OrderBLL();
            order.Priority = priority.Text;
            order.Supplier = supplier.Text;
            order.Doer = c2.SelectedIndex + 1;

            OrderLineBLL orderLine = new OrderLineBLL();
            orderLine.Product = c1.SelectedIndex + 1;
            orderLine.Quantity = Int32.Parse(quantity.Text);
            orderLine.Measure = measure.Text;
            

            OrderService service = new OrderService();
            bool result = service.MakeOrder(order, orderLine);
            if (result)
            {
                MessageBox.Show("Заявка оформлена");
            }
            
            this.Close();
        }

    }
}
