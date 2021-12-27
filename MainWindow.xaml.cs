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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CRUD db = new CRUD();
        List<ProductBLL> allProducts;
        List<OrderBLL> allOrders;
        List<SupplyBLL> allSupplies;

        public MainWindow()
        {
            InitializeComponent();
            loadData();

        }

        void loadData()
        {
            loadProducts();
            loadOrders();
            loadSupplies();
        }

        void loadProducts()
        {
            allProducts = db.GetAllProducts();
            ProductsDataGrid.ItemsSource = allProducts;
        }

        void loadOrders()
        {
            allOrders = db.GetAllOrders();
            OrdersDataGrid.ItemsSource = OrderDop.Orderdop();

        }

        void loadSupplies()
        {
            allSupplies = db.GetAllSupplies();
            SuppliesDataGrid.ItemsSource = SupplyDop.Supplydop();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow w = new OrderWindow();
            w.ShowDialog();
            allOrders = db.GetAllOrders();
            OrdersDataGrid.ItemsSource = OrderDop.Orderdop();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            ReportsDataGrid.ItemsSource = ReportsService.StatisticsForMonth(dt.Month);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int index;
            index = OrdersDataGrid.SelectedIndex;

            if (index != -1)
            {
                int id = 0;
                bool converted = Int32.TryParse((OrdersDataGrid.Columns[0].GetCellContent(OrdersDataGrid.Items[index])as TextBlock).Text, out id);
                if (converted == false)
                    return;

                OrderBLL o = allOrders.Where(i => i.Id == id).FirstOrDefault();
                if (o != null)
                {
                    string st = (OrdersDataGrid.Columns[1].GetCellContent(OrdersDataGrid.Items[index])as TextBlock).Text;
                   
                    o.Status = st;
                    if (o.Status == "Доставлено")
                        o.ClosingDate = DateTime.Now;

                    db.UpdateStatus(o);
                    OrdersDataGrid.ItemsSource = db.GetAllOrders();
                    MessageBox.Show("Объект обновлен");
                    if (o.Status == "Доставлено")
                    {
                        MessageBoxResult result = MessageBox.Show("Оформить поставку?", " ", MessageBoxButton.YesNo);
                        switch (result)
                        {
                            case MessageBoxResult.Yes:
                                {
                                    SupplyWindow s = new SupplyWindow(id);
                                    s.ShowDialog();
                                    allSupplies = db.GetAllSupplies();
                                    SuppliesDataGrid.ItemsSource = SupplyDop.Supplydop();
                                }
                                break;
                            case MessageBoxResult.No:
                                Close();
                                break;
                            
                        }
                    }
                }
            }
            else
                MessageBox.Show("Ни один объект не выбран!");
        }
    }
}
