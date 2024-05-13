using Microsoft.EntityFrameworkCore;
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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using ПРОЕКТ2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ПРОЕКТ2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
    public class DB1 : DbContext
    {

        public DB1(DbContextOptions<DB1> options) : base(options) { }

        public DbSet<Students> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Проекты VS\\ПРОЕКТ2\\ПРОЕКТ2\\DB1.mdf\";Integrated Security=True");
            }
        }
        private static DbContextOptions<DB1>? _options;
        public static DbContextOptions<DB1> Options
        {
            get
            {
                if (_options == null)
                {
                    var optionsBuilder = new DbContextOptionsBuilder<DB1>();
                    optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Проекты VS\\ПРОЕКТ2\\ПРОЕКТ2\\DB1.mdf\";Integrated Security=True");
                    _options = optionsBuilder.Options;
                }
                return _options;
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>().HasKey(s => new { s.Name, s.FirstName, s.LastName,  s.Email, s.Password });
        }

    }
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            var optionsBuilder = new DbContextOptionsBuilder<DB1>();
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Проекты VS\\ПРОЕКТ2\\ПРОЕКТ2\\DB1.mdf\";Integrated Security=True");
            var context = new DB1(optionsBuilder.Options);

            // Работа с данными
            var students = context.Students.ToList();
        }

        private void ButtonVoiti_Click(object sender, RoutedEventArgs e)
        {
            AvtorizPage avtorizPage = new AvtorizPage();

            // Переходим на новую страницу
            this.mainFrame.Content = avtorizPage;
        }
        private void ButtonGoOproecte_Click(object sender, RoutedEventArgs e)
        {
            OproectePage oproectePage = new OproectePage();

            this.mainFrame.Content = oproectePage;
        }

        private void mainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
