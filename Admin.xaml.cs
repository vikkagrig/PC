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

namespace Приемная_комиссия
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        User user;
        public Admin(User user)
        {
            InitializeComponent();
            this.user = user;
            using(PCEntities db = new PCEntities())
            {
                foreach(var u in db.User)
                {
                    if(u.IDUser == user.IDUser)
                    {
                        lnum.Text = u.IDUser.ToString();
                        break;
                    }
                }
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminSpec adminSpec = new AdminSpec(this);
            this.Visibility = Visibility.Hidden;
            adminSpec.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminFac fac = new AdminFac(this);
            this.Visibility = Visibility.Hidden;
            fac.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AdminUser a = new AdminUser(this);
            this.Visibility = Visibility.Hidden;
            a.Show();
        }
    }
}
