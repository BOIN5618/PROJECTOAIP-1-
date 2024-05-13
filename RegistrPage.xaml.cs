using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using ПРОЕКТ2;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ПРОЕКТ2


{
    /// <summary>
    /// Логика взаимодействия для RegistrPage.xaml
    /// </summary>
    public partial class RegistrPage : Page
    {
        public RegistrPage()
        {
            InitializeComponent();
        }

        private void buttonGoMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Frame());
        }

        private void ButtonRegistr_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Создаем объект контекста базы данных
            var optionsBuilder = new DbContextOptionsBuilder<DB1>();
            optionsBuilder.UseSqlServer(connectionString);
            using (DB1 context = new DB1(optionsBuilder.Options))
            {
                // Создаем новый объект Student
                Students newStudent = new Students
                {
                    FirstName = FirstNameRegistrTextBox.Text,
                    Name = NameRegistrTextBox.Text,
                    LastName = LastNameRegistrTextBox.Text,
                    Email = EmailRegistrTextBox.Text,
                    Password = PasswordRegistrPasswordBox.Password
                };

                // Добавляем нового студента в таблицу Students
                context.Students.Add(newStudent);

                // Сохраняем изменения в базе данных
                context.SaveChanges();

                // Переходим на страницу авторизации или другую страницу после успешной регистрации
                AvtorizPage avtorizPage = new AvtorizPage();
                NavigationService.Navigate(avtorizPage);
            }
        }

        private void ButtonRegistGoAvtoriz_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AvtorizPage());
        }
    }
}
