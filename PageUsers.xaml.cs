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

namespace ПРОЕКТ2
{
    /// <summary>
    /// Логика взаимодействия для PageUsers.xaml
    /// </summary>
    public partial class PageUsers : Page
    {
        public PageUsers()
        {
            InitializeComponent();
            LoadInstructorsData();
            LoadStudentsData();
        }

        private void LoadInstructorsData()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Проекты VS\ПРОЕКТ2\ПРОЕКТ2\DB1.mdf"";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT NameInstructor, Email FROM Instructors";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string nameInstructor = reader.GetString(0);
                    string email = reader.GetString(1);

                    TextBoxManagers.Text += nameInstructor + Environment.NewLine;
                    TextBoxManagersEmail.Text += email + Environment.NewLine;
                }

                reader.Close();
            }
        }

        private void LoadStudentsData()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Проекты VS\ПРОЕКТ2\ПРОЕКТ2\DB1.mdf"";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT FirstName, Name, LastName, Email FROM Students";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string firstName = reader.GetString(0);
                    string name = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    string email = reader.GetString(3);

                    StringBuilder fullName = new StringBuilder();
                    fullName.Append(firstName);
                    fullName.Append(" ");
                    fullName.Append(name[0]); // Первая буква имени
                    fullName.Append(".");
                    fullName.Append(lastName[0]); // Первая буква фамилии
                    fullName.Append(".");

                    TextBoxStudents.Text += fullName.ToString() + Environment.NewLine;
                    TextBoxStudentsEmail.Text += email + Environment.NewLine;
                }

                reader.Close();
            }
        }

        private void ButtonUsersGoKab_Click(object sender, RoutedEventArgs e)
        {
            PageLichKab pageLichKab = new PageLichKab();
            NavigationService.Navigate(pageLichKab);
        }
    }
}
