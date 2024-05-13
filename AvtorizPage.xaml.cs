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
    /// Логика взаимодействия для AvtorizPage.xaml
    /// </summary>
   

    public partial class AvtorizPage : Page
    {
        public AvtorizPage()
        {
            InitializeComponent();
        }
        private bool CheckCredentials(string email, string password)
        {
            using (var context = new DB1(DB1.Options))
            {
                var student = context.Students.FirstOrDefault(s => s.Email == email && s.Password == password);
                return student != null;
            }
        }

        private void ButtonGoRegistr_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrPage());
        }

        private void ButtonVoitiGoKab_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginAvtoriz.Text;
            string password = Password.Password;

            if (CheckCredentials(login, password))
            {
                using (var context = new DB1(DB1.Options))
                {
                    // Получаем данные авторизованного пользователя из базы данных
                    var student = context.Students.FirstOrDefault(s => s.Email == login && s.Password == password);

                    if (student != null)
                    {
                        AuthData.Instance.FirstName = student.FirstName;
                        AuthData.Instance.LastName = student.LastName;
                        AuthData.Instance.Name = student.Name;
                        AuthData.Instance.Email = student.Email;

                        // Проверка на администратора
                        if (login == "Admin" && password == "admin")
                        {
                            AuthData.Instance.IsAdmin = true;
                        }
                        else
                        {
                            AuthData.Instance.IsAdmin = false;
                        }

                        PageLichKab pageLichKab = new PageLichKab(student.FirstName, student.LastName, student.Name, student.Email);
                        NavigationService.Navigate(pageLichKab);
                    }
                }
            }
            else
            {
                ErrorMessage.Text = "Неверный логин или пароль. Попробуйте еще раз.";

                // Очистка полей ввода
                LoginAvtoriz.Text = "";
                Password.Password = "";
            }
            
        }

        private void buttonAvtorizGoMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Frame());
        }
    }
}