using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AdminUser.xaml
    /// </summary>
    public partial class AdminUser : Window
    {
        Admin admin;
        public AdminUser(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            New();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            admin.Visibility = Visibility.Visible;
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public void New()
        {
            int n = 0;
            table.Items.Clear();
            using (var db = new PCEntities())
            {
                foreach (var u in db.User)
                {
                    if(u.Role == "Абитуриент")
                    {
                        table.Items.Add(new User { IDUser = u.IDUser, Login = u.Login, Password = u.Password });
                        n++;
                    }
                }
                num.Text = n.ToString();
            }
        }

        private void table_MouseUp(object sender, MouseButtonEventArgs e)
        {
            User user = table.SelectedItem as User;
            if (user != null)
            {
                EditUser edit = new EditUser(user, this);
                edit.Show();
            }
        }
    }
}
