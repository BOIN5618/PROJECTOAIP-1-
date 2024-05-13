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

namespace ПРОЕКТ2
{
    /// <summary>
    /// Логика взаимодействия для OproectePage.xaml
    /// </summary>
    public partial class OproectePage : Page
    {
        public OproectePage()
        {
            InitializeComponent();
        }

        private void ButtonOproecteGoMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Frame());
        }
    }
}
