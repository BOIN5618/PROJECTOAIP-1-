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
using ПРОЕКТ2;
using ПРОЕКТ2.Kursy;

namespace ПРОЕКТ2
{
    /// <summary>
    /// Логика взаимодействия для PageKursy.xaml
    /// </summary>
    public partial class PageKursy : Page
    {
        private readonly DatabaseHelper _databaseHelper = new DatabaseHelper();

        public string MarketingCourse { get; set; }
        public string FinanceCourse { get; set; }
        public string RSCourse { get; set; }
        public string TMCourse { get; set; }
        public List<string> CourseName { get; set; }

        public PageKursy()
        {
            InitializeComponent();
            DataContext = this; // Устанавливаем контекст данных для привязки

            // Получаем данные из базы данных и присваиваем их свойствам
            List<string> courseNames = _databaseHelper.GetCourseNames();
            if (courseNames.Count >= 4)
            {
                MarketingCourse = courseNames[0];
                FinanceCourse = courseNames[1];
                RSCourse = courseNames[2];
                TMCourse = courseNames[3];
            }
        }

        private void PageKursy_Loaded(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр DatabaseHelper внутри метода
            DatabaseHelper databaseHelper = new DatabaseHelper();
            CourseName = databaseHelper.GetCourseNames();

            if (CourseName != null && CourseName.Count >= 4)
            {
                Marketing.Text = CourseName[0];
                Finance.Text = CourseName[1];
                RS.Text = CourseName[2];
                TM.Text = CourseName[3];
            }
        }

        private void ButtonKursyGoOproecte_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OproectePage());
        }

        private void ButtonKursyGoKab_Click(object sender, RoutedEventArgs e)
        {
            PageLichKab pageLichKab = new PageLichKab();
            NavigationService.Navigate(pageLichKab);
        }

        private void PosmotretFinance_Click(object sender, RoutedEventArgs e)
        {
            PageFinance pageFinance = new PageFinance();
            NavigationService.Navigate(pageFinance);
        }

        private void PosmotretTM_Click(object sender, RoutedEventArgs e)
        {
            PageTM pageTM = new PageTM();
            NavigationService.Navigate(pageTM);
        }

        private void PosmotretRS_Click(object sender, RoutedEventArgs e)
        {
            PageRS pageRS = new PageRS();
            NavigationService.Navigate(pageRS);
        }

        private void PosmotretMarceting_Click(object sender, RoutedEventArgs e)
        {
            PageMarceting pageMarceting = new PageMarceting();
            NavigationService.Navigate(pageMarceting);
        }
    }
    public class DatabaseHelper
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Проекты VS\\ПРОЕКТ2\\ПРОЕКТ2\\DB1.mdf\";Integrated Security=True";

        public List<string> GetCourseNames()
        {
            List<string> courseNames = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT CourseName FROM Courses";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

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
        public Dictionary<string, string> GetManagerData()
        {
            Dictionary<string, string> managerData = new Dictionary<string, string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Name, Achievement FROM Managers";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    string achievement = reader.GetString(1);
                    managerData[name] = achievement;
                }

                reader.Close();
            }

            return managerData;
        }
    }
}
