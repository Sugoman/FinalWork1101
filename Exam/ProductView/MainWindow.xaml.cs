using Library.Data;
using System.Windows;

namespace ProductView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FragrantWorldContext _context;
        private int _currentProductId;
        public MainWindow()
        {
            InitializeComponent();
            _context = new FragrantWorldContext();
            LoadProduct(1);
        }

        private void LoadProduct(int productId)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                _currentProductId = product.ProductId;
                PageTextBlock.Text = _currentProductId.ToString();
                ProductArticleNumber.Text = product.ProductArticleNumber;
                ProductName.Text = product.ProductName;
                ProductDescription.Text = product.ProductDescription;
                ProductManufacturer.Text = product.ProductManufacturer;
                ProductPrice.Text = product.ProductCost.ToString("C");
            }
            else
            {
                MessageBox.Show("Товар не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            var previousId = _currentProductId - 1;
            if (_context.Products.Any(p => p.ProductId == previousId))
            {
                LoadProduct(previousId);
            }
            else
            {
                MessageBox.Show("Предыдущий товар отсутствует", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var nextId = _currentProductId + 1;
            if (_context.Products.Any(p => p.ProductId == nextId))
            {
                LoadProduct(nextId);
            }
            else
            {
                MessageBox.Show("Следующий товар отсутствует", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == _currentProductId);
            if (product != null)
            {
                MessageBox.Show($"Вы заказали: {product.ProductName}", "Заказ оформлен", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}