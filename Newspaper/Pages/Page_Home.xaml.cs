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
    /// Логика взаимодействия для Page_Home.xaml
    /// </summary>
    public partial class Page_Home : Page
    {
        Users user;

        public Page_Home(Users user)
        {
            InitializeComponent();
            this.user = user;
            GetInfoWorker(user);
        }

        private void btnProductsNavigete_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.Page_Products(user));
        }

        private void GetInfoWorker(Users user)
        {
            tbLastName.Text = user.LastName;
            tbName.Text = user.Name;
            tbPatronimic.Text = user.Patronymic;
            if (user.ID_Post == 1)
                tbPost.Text = "Пользователь";
            if (user.ID_Post == 2)
                tbPost.Text = "Администратор";
        }
    }
}
