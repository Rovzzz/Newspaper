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
    /// Логика взаимодействия для Page_Products.xaml
    /// </summary>
    public partial class Page_Products : Page
    {
        Users user;

        public Page_Products(Users user)
        {
            InitializeComponent();
            //DgProducts.ItemsSource = NewspaperNewEntities.GetContext().Product.ToList();

            this.user = user;

            //Настройка combobox
            var allTypes = NewspaperNewEntities.GetContext().Type_Product.ToList();
            allTypes.Insert(0, new Type_Product
            {
                Name_Type_Product = "Все типы"
            });
            cbTypeProduct.ItemsSource = allTypes;


            //Отображение кнопок
            if (user.Post.Name_Post == "Пользователь")
            {
                BtnAdd.Visibility = Visibility.Hidden;
                BtnDelete.Visibility = Visibility.Hidden;
                btnEditProduct.Visibility = Visibility.Hidden;
            }

        }

        private void BtnAdd_Users_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.Page_AddEditProduct(null));
        }

        private void BtnDelete_Users_Click(object sender, RoutedEventArgs e)
        {
            var wproductsForRemoving = DgProducts.SelectedItems.Cast<Product>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {wproductsForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    NewspaperNewEntities.GetContext().Product.RemoveRange(wproductsForRemoving);
                    NewspaperNewEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены !");

                    DgProducts.ItemsSource = NewspaperNewEntities.GetContext().Product.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.Page_AddEditProduct((sender as Button).DataContext as Product));

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                NewspaperNewEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DgProducts.ItemsSource = NewspaperNewEntities.GetContext().Product.ToList();
            }
        }

        private void tbPoisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgProducts.ItemsSource = UpdateProducts();
        }

        private void cbTypeProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DgProducts.ItemsSource = UpdateProducts();
        }

        private List<Product> UpdateProducts()
        {
            var allProducts = NewspaperNewEntities.GetContext().Product.ToList();

            if (cbTypeProduct.SelectedIndex > 0)
            {
                Type_Product selectedType = cbTypeProduct.SelectedItem as Type_Product;
                allProducts = allProducts.Where(p => p.Type_Product.ID == selectedType.ID).ToList();
            }

            string searchKeyword = tbPoisk.Text.ToLower();
            allProducts = allProducts.Where(p => p.Name_Product.ToLower().Contains(searchKeyword)).ToList();

            return allProducts;
        }
    }
}
