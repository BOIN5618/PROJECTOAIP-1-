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
using ПРОЕКТ2.Models;

namespace ПРОЕКТ2
{
    /// <summary>
    /// Логика взаимодействия для PageMarceting.xaml
    /// </summary>
    public partial class PageMarceting : Page
    {
        public PageMarceting()
        {
            InitializeComponent();
            Loaded += PageMarceting_Loaded;
        }

        private void PageMarceting_Loaded(object sender, RoutedEventArgs e)
        {
            LoadManagerData();
        }

        private void LoadManagerData()
        {
            Dictionary<string, Dictionary<string, string>> managerData = ManagerDataProvider.GetManagerData();

            if (managerData.TryGetValue("Маркетинг", out Dictionary<string, string> marketingManagerData))
            {
                TextBoxInstructorMarceting.Text = marketingManagerData["Name"];
                TextBoxAchievementsMarcetingInstructor.Text = marketingManagerData["Achievement"];
            }
        }

        private void ButtonMarcetingGoKursy_Click(object sender, RoutedEventArgs e)
        {
            PageKursy pageKursy = new PageKursy();
            NavigationService.Navigate(pageKursy);
        }
    }
}
