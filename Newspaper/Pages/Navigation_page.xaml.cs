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
    /// Логика взаимодействия для Navigation_page.xaml
    /// </summary>
    public partial class Navigation_page : Page
    {
        public Navigation_page()
        {
            InitializeComponent();
        }

        private void btnNavigateAgents_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.Page_Agents());
        }

        private void btnNavigateSale_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.Page_Sale());
        }

        private void btnNavigateProducts_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.Page_Products());
        }
    }
}
