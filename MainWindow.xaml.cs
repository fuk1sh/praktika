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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class User
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string password { get; set; }
        }
        public class AppDbContext : DbContext
        {
            public DbSet<User> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=kolbaster;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void vxod(object sender, RoutedEventArgs e)
        {
            var login1 = login.Text;
            var password = parol.Text;
            
            var context = new AppDbContext();

            var user = context.Users.SingleOrDefault(x => x.Login == login1 && x.password == password);
            if (user is null) 
            {
                abobin1.Content = "успех!!!";
            }

            Window vxod = new Window1();
            vxod.Show();
            this.Close();
        }

        private void regBTN(object sender, RoutedEventArgs e)
        {
            Window rega = new Window2();
            rega.Show();
            this.Close();
        }
    }
}
