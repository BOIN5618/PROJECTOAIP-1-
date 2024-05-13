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

namespace ПРОЕКТ2.Kursy
{
    /// <summary>
    /// Логика взаимодействия для PageFinance.xaml
    /// </summary>
    public partial class PageFinance : Page
    {
        private readonly DatabaseHelper _databaseHelper = new DatabaseHelper();

        public PageFinance()
        {
            InitializeComponent();
            Loaded += PageFinance_Loaded;
        }

        private void PageFinance_Loaded(object sender, RoutedEventArgs e)
        {
            LoadManagerData();
        }

        private void LoadManagerData()
        {
            Dictionary<string, Dictionary<string, string>> managerData = ManagerDataProvider.GetManagerData();

            if (managerData.TryGetValue("Финансы", out Dictionary<string, string> financeManagerData))
            {
                TextBoxInstructorFinance.Text = financeManagerData["Name"];
                TextBoxAchievementsFinanceInstructor.Text = financeManagerData["Achievement"];
            }
        }

        private void ButtonFinanceGoKursy_Click(object sender, RoutedEventArgs e)
        {
            PageKursy pageKursy = new PageKursy();
            NavigationService.Navigate(pageKursy);
        }
    }
}
