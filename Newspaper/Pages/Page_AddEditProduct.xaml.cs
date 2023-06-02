using Newspaper.Classes;
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

namespace Newspaper.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_AddEditProduct.xaml
    /// </summary>
    public partial class Page_AddEditProduct : Page
    {
        private Product _currentProduct = new Product(); 
        public Page_AddEditProduct(Product selectedProduct)
        {
            InitializeComponent();
            if(selectedProduct != null)
            {
                _currentProduct = selectedProduct;
            }
            DataContext = _currentProduct;
            ComboBox_Type_Product.ItemsSource = NewspaperNewEntities.GetContext().Type_Product.ToList();
        }

        private void BtnSave_AddEdit_Product_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentProduct.Name_Product))
                errors.AppendLine("Укажите Наименование продукта");

            if (string.IsNullOrWhiteSpace(_currentProduct.Article))
                errors.AppendLine("Укажите Артикул");

            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentProduct.ProductionPersonCount)))
                errors.AppendLine("Укажите Кол-во человек для производства");

            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentProduct.ProductionWorkshopNumber)))
                errors.AppendLine("Укажите Номер цеха производства");

            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentProduct.MinCostForAgent)))
                errors.AppendLine("Укажите Минимальная цена продажи");

            if (_currentProduct.Type_Product == null)
                errors.AppendLine("Укажите Тип продукции");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentProduct.ID == 0)
                NewspaperNewEntities.GetContext().Product.Add(_currentProduct);

            try
            {
                NewspaperNewEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
