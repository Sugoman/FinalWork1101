using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

namespace SortProduct
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly FragrantWorldContext _context;
        private List<Product> _products;
        public MainWindow()
        {
            InitializeComponent();
            _context = new FragrantWorldContext();
            LoadData();
        }

        private void LoadData()
        {
            _products = _context.Products.ToList();
            ManufacturerComboBox.ItemsSource = new List<string> { "Все производители" }
                .Concat(_products.Select(p => p.ProductManufacturer).Distinct().ToList());
            ManufacturerComboBox.SelectedIndex = 0;
            UpdateDataGrid();
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            var filteredProducts = _products.AsQueryable();

            if (ManufacturerComboBox.SelectedIndex > 0)
            {
                var selectedManufacturer = ManufacturerComboBox.SelectedItem.ToString();
                filteredProducts = filteredProducts.Where(p => p.ProductManufacturer == selectedManufacturer);
            }

            if (decimal.TryParse(MinPriceTextBox.Text, out var minPrice))
                filteredProducts = filteredProducts.Where(p => p.ProductCost >= minPrice);
            if (decimal.TryParse(MaxPriceTextBox.Text, out var maxPrice))
                filteredProducts = filteredProducts.Where(p => p.ProductCost <= maxPrice);

            if (!string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                var searchQuery = SearchTextBox.Text.ToLower();
                filteredProducts = filteredProducts.Where(p => p.ProductName.ToLower().Contains(searchQuery));
            }

            if (SortComboBox.SelectedIndex == 0) 
                filteredProducts = filteredProducts.OrderBy(p => p.ProductCost);
            else if (SortComboBox.SelectedIndex == 1)
                filteredProducts = filteredProducts.OrderByDescending(p => p.ProductCost);

            var resultList = filteredProducts.ToList();
            ProductsDataGrid.ItemsSource = resultList;

            DataCountLabel.Content = $"{resultList.Count} из {_products.Count}";
        }
    }
}