using Microsoft.Data.SqlClient;
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
using static System.Net.Mime.MediaTypeNames;

namespace ПРОЕКТ2
{
    /// <summary>
    /// Логика взаимодействия для PageLichKab.xaml
    /// </summary>
    public partial class PageLichKab : Page
    {
        
        public PageLichKab()
        {
            InitializeComponent();
            NameTextBox.Text = AuthData.Instance.FirstName;
            LastNameTextBox.Text = AuthData.Instance.LastName;
            FirstNameTextBox.Text = AuthData.Instance.Name;
            EmailTextBox.Text = AuthData.Instance.Email;

        }
        public PageLichKab(string firstName, string lastName, string Name, string email)
        {
            InitializeComponent();
            FirstNameTextBox.Text = firstName;
            LastNameTextBox.Text = lastName;
            NameTextBox.Text = Name;
            EmailTextBox.Text = email;
            bool isAdmin = AuthData.Instance.IsAdmin;
            btnViewUserList.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonGoMain1_Click(object sender, RoutedEventArgs e)
        {
            AuthData.Instance.FirstName = string.Empty;
            AuthData.Instance.LastName = string.Empty;
            AuthData.Instance.Name = string.Empty;
            AuthData.Instance.Email = string.Empty;

            // Переход на страницу авторизации
            AvtorizPage avtorizPage = new AvtorizPage();
            NavigationService.Navigate(avtorizPage);
        }

        private void ButtonGoKursy_Click(object sender, RoutedEventArgs e)
        {
            List<string> courseNames = GetCourseNamesFromDatabase();
            PageKursy pageKursy = new PageKursy { CourseName = courseNames };
            this.NavigationService.Navigate(pageKursy);
        }
        private List<string> GetCourseNamesFromDatabase()
        {
            List<string> courseNames = new List<string>();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Проекты VS\\ПРОЕКТ2\\ПРОЕКТ2\\DB1.mdf\";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT CourseName FROM Courses";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string courseName = reader.GetString(0);
                    courseNames.Add(courseName);
                }

                reader.Close();
            }

            return courseNames;
        }

        private void btnViewUserList_Click(object sender, RoutedEventArgs e)
        {
            PageUsers pageUsers = new PageUsers();
            NavigationService.Navigate(pageUsers);
        }
    }
}