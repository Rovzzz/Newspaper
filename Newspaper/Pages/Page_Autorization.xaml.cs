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
    /// Логика взаимодействия для Page_Autorization.xaml
    /// </summary>
    public partial class Page_Autorization : Page
    {
        public Page_Autorization()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text;
            string password = tbPassword.Text;
            bool isAuth = false;

            List<Users> users = DataBase.Base.Users.ToList();
            foreach (Users user in users)
            {
                if (user.Login == login && user.Password == password)
                {
                    DataBase.users = user;
                    Manager.MainFrame.Navigate(new Pages.Page_Home(user));
                    isAuth = true;
                    break;
                }
            }

            if (!isAuth)
            {
                MessageBox.Show("Логин или пароль неверен");
            }
        }
    }
}
