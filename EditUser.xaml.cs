using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace Приемная_комиссия
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        User user;
        AdminUser admin;
        public EditUser(User user, AdminUser admin)
        {
            InitializeComponent();
            this.user = user;
            this.admin = admin;
            l.Text = user.Login;
            p.Text = user.Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (l.Text != "" && p.Text != "")
            {
                using (PCEntities db = new PCEntities())
                {
                    User u = null;
                    foreach (var us in db.User)
                    {
                        if (us.IDUser == this.user.IDUser)
                        {
                            u = db.User.Find(us.IDUser);
                            break;
                        }
                    }
                    u.Login = l.Text;
                    u.Password = p.Text;
                    db.SaveChanges();
                    System.Windows.MessageBox.Show("Сохранено");
                    admin.New();
                    this.Close();
                }
            }
            else
                MessageBox.Show("Не все поля заполнены");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = (MessageBoxResult)System.Windows.MessageBox.Show("Вы точно хотите удалить этого пользователя?", "Уведомление", (MessageBoxButton)(MessageBoxButtons)MessageBoxButton.YesNo);
            if (r == MessageBoxResult.Yes)
            {
                using (PCEntities db = new PCEntities())
                {
                    User u = null;
                    Entrant entrant = null;
                    foreach (var en in db.Entrant)
                    {
                        if (en.IDUser == this.user.IDUser)
                        {
                            entrant = db.Entrant.Find(en.IDEntrant);
                            break;
                        }
                    }
                    foreach (var us in db.User)
                    {
                        if (us.IDUser == this.user.IDUser)
                        {
                            u = db.User.Find(us.IDUser);
                            break;
                        }
                    }
                    foreach (var l in db.List)
                    {
                        List list = null;
                        if (l.IDEntrant == entrant.IDEntrant)
                        {
                            list = db.List.Find(l.IDList);
                            db.List.Remove(list);
                        }
                    }
                    db.Entrant.Remove(entrant);
                    db.User.Remove(u);
                    db.SaveChanges();
                    MessageBox.Show("Успешно удалено");
                    admin.New();
                    this.Close();
                }
            }
        }
    }
}
