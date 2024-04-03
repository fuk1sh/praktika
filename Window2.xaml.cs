using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public class User
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }

            public string EMAEL { get; set; }
        }

        public class AppDbContext : DbContext
        {
            public DbSet<User> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=kolbaster;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        public Window2()
        {
            InitializeComponent();
        }

        private async void registr(object sender, RoutedEventArgs e)
        {
            string password = parol.Text;

            if (loginAGAIN.Text.Length > 16)
            {
                loginAGAIN.Text = "слишком длинный логин";
                loginAGAIN.BorderBrush = Brushes.Red;
                await Task.Delay(1500);
                loginAGAIN.Text = "";
                loginAGAIN.BorderBrush = Brushes.Black;
                loginAGAIN.BorderThickness = new Thickness(0.5);
            }
            else if (parol.Text != parolA.Text)
            {
                parol.Text = "пароли не совпадают!";
                parol.BorderBrush = Brushes.Red;
                await Task.Delay(1500);
                parol.Text = "";
                parol.BorderBrush = Brushes.Black;
                parol.BorderThickness = new Thickness(0.5);

                parolA.Text = "";


            }
            else if (loginAGAIN.Text.Length < 3 || parol.Text.Length <= 3)
            {
                loginAGAIN.Text = "логин должен содержать хотя бы 3 символа";
                loginAGAIN.BorderBrush = Brushes.Red;

                parol.Text = "пароль должен содержать минимум 3 символа";
                parol.BorderBrush = Brushes.Red;

                await Task.Delay(1500);
                loginAGAIN.Text = "";
                loginAGAIN.BorderBrush = Brushes.Black;
                loginAGAIN.BorderThickness = new Thickness(0.5);

                parol.Text = "";
                parol.BorderBrush = Brushes.Black;
                parol.BorderThickness = new Thickness(0.5);
            }
            else if (password.Contains('!') || password.Contains('@')
                || password.Contains('#')
                || password.Contains('$')
                || password.Contains('%')
                || password.Contains('^')
                || password.Contains('*')
                || password.Contains('(')
                || password.Contains(')')
                || password.Contains('_')
                || password.Contains('-')
                || password.Contains('=')
                || password.Contains('+'))
            {
                parol.Text = "недопустимый символ";
                parol.BorderBrush = Brushes.Red;
                await Task.Delay(1500);
                parol.Text = "";
                parol.BorderBrush = Brushes.Black;
                parol.BorderThickness = new Thickness(0.5);
            }
            else
            {
                var login = loginAGAIN.Text;

                var pass = parol.Text;

                var EMAEL = email.Text;

                var context = new AppDbContext();
                var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
                if (user_exists is not null)
                {
                    MessageBox.Show("est takoy uje");
                    return;
                }
                var user = new User { Login = login, Password = pass, EMAEL = EMAEL };
                context.Users.Add(user);
                context.SaveChanges();
                MessageBox.Show("xarow bro");

                Window uspex = new MainWindow();
                uspex.Show();
                this.Close();
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Window back = new MainWindow();
            back.Show();
            this.Close();
        }
    }
}
