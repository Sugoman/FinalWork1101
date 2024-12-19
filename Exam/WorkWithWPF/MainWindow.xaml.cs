using Library.Data;
using Library.Models;
using Library.Services;
using System.Windows;
using System.Windows.Controls;

namespace WorkWithWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly FragrantWorldContext _context = new();
        private UserService _userService;
        private RoleService _roleService;
        private OrderService _orderService;
        private PickupPointService _pickupPointService;
        private ProductService _productService;
        public MainWindow()
        {
            InitializeComponent();
            _userService = new UserService(_context);
            _roleService = new RoleService(_context);
            _orderService = new OrderService(_context);
            _pickupPointService = new PickupPointService(_context);
            _productService = new ProductService(_context);
        }
        
        private async void UserButton_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = await _userService.GetAllUsersAsync();
        }

        private async void FindUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                grid.ItemsSource = new List<User> { await _userService.GetUserByIdAsync(Convert.ToInt32(UserIdTextBox.Text)) };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void RoleButton_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = await _roleService.GetAllRolesAsync();
        }

        private async void FindRoleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                grid.ItemsSource = new List<Role> { await _roleService.GetRoleByIdAsync(Convert.ToInt32(RoleIdTextBox.Text)) };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void FindOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                grid.ItemsSource = new List<Order> { await _orderService.GetOrderByIdAsync(Convert.ToInt32(OrderIdTextBox.Text)) };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = await _orderService.GetAllOrdersAsync();
        }

        private async void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = await _productService.GetAllProductsAsync();
        }
        private async void FindProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                grid.ItemsSource = new List<Product> { await _productService.GetProductByIdAsync(Convert.ToInt32(PickupPointIdTextBox.Text)) };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void PickupPointButton_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = await _pickupPointService.GetAllPickupPointsAsync();
        }


        private async void FindPickupPointButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                grid.ItemsSource = new List<PickupPoint> { await _pickupPointService.GetPickupPointByIdAsync(Convert.ToInt32(PickupPointIdTextBox.Text)) };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}