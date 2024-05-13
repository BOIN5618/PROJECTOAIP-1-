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
    /// Логика взаимодействия для PageTM.xaml
    /// </summary>
    public partial class PageTM : Page
    {
        public PageTM()
        {
            InitializeComponent();
            Loaded += PageTM_Loaded;
        }

        private void PageTM_Loaded(object sender, RoutedEventArgs e)
        {
            LoadManagerData();
        }

        private void LoadManagerData()
        {
            Dictionary<string, Dictionary<string, string>> managerData = ManagerDataProvider.GetManagerData();

            if (managerData.TryGetValue("Тайм-менеджмент", out Dictionary<string, string> tmManagerData))
            {
                TextBoxInstructorTM.Text = tmManagerData["Name"];
                TextBoxAchievementsTMInstructor.Text = tmManagerData["Achievement"];
            }
        }

        private void ButtonFinanceTM_Click(object sender, RoutedEventArgs e)
        {
            PageKursy pageKursy = new PageKursy();
            NavigationService.Navigate(pageKursy);
        }
    }
}
