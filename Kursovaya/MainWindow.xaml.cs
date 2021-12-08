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
        public MainWindow()
        {
            InitializeComponent();
            loadData();
            
         }

        void loadData()
        {
            loadProducts();
            loadOrders();
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

    }
}
