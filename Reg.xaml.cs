using Microsoft.Win32;
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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        bool[] flags;
        byte[] im = null;
        public Reg()
        {
            InitializeComponent();
            flags = new bool[9] { true, true, true, true, true, true, true, true, true};
        }

        private void pas3_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flags[0] == true)
            {
                pas3.Text = null;
                pas3.Foreground = Brushes.Black;
                flags[0] = false;
                pas2.Foreground = Brushes.Black;
                pas2.Visibility = Visibility.Visible;
                pas2.Width = 480;
                pas3.Width = 0;
                pas2.Focus();
            }
        }

        private void im3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            im3.Width = 0;
            im3.Visibility = Visibility.Hidden;
            im4.Width = 30;
            im4.Visibility = Visibility.Visible;
            pas3.Text = pas2.Password;
            pas2.Visibility = Visibility.Hidden;
            pas2.Width = 0;
            pas3.Visibility = Visibility.Visible;
            pas3.Width = 480;
            pas3.Foreground = Brushes.Black;
            pas3.SelectionStart = pas3.Text.Length;
            pas3.Focus();
        }

        private void im4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            im4.Width = 0;
            im4.Visibility = Visibility.Hidden;
            im3.Width = 30;
            im3.Visibility = Visibility.Visible;
            pas3.Visibility = Visibility.Hidden;
            pas3.Width = 0;
            pas2.Visibility = Visibility.Visible;
            pas2.Width = 480;
            pas2.Password = pas3.Text;
        }

        private void f_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flags[1] == true)
            {
                f.Text = null;
                f.Foreground = Brushes.Black;
                flags[1] = false;
            }
        }

        private void i_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flags[2] == true)
            {
                i.Text = null;
                i.Foreground = Brushes.Black;
                flags[2] = false;
            }
        }

        private void o_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flags[3] == true)
            {
                o.Text = null;
                o.Foreground = Brushes.Black;
                flags[3] = false;
            }
        }

        private void p_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flags[4] == true)
            {
                p.Text = null;
                p.Foreground = Brushes.Black;
                flags[4] = false;
            }
        }

        private void ege_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flags[5] == true)
            {
                ege.Text = null;
                ege.Foreground = Brushes.Black;
                flags[5] = false;
            }
        }

        private void d_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flags[6] == true)
            {
                d.Foreground = Brushes.Black;
                flags[6] = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG)| *.BMP; *.JPG; *.GIF; *.PNG | All files(*.*) | *.* ";
            if ((bool)openFileDialog.ShowDialog())
            {
                try
                {
                    this.im = File.ReadAllBytes(openFileDialog.FileName);
                    photo.Text = "Успешно загружено";
                }
                catch
                {
                    photo.Text = "Ошибка";
                }
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void im1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            im1.Width = 0;
            im1.Visibility = Visibility.Hidden;
            im2.Width = 30;
            im2.Visibility = Visibility.Visible;
            pas1.Text = pas.Password;
            pas.Visibility = Visibility.Hidden;
            pas.Width = 0;
            pas1.Visibility = Visibility.Visible;
            pas1.Width = 480;
            pas1.Foreground = Brushes.Black;
            pas1.SelectionStart = pas1.Text.Length;
            pas1.Focus();
        }

        private void im2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            im2.Width = 0;
            im2.Visibility = Visibility.Hidden;
            im1.Width = 30;
            im1.Visibility = Visibility.Visible;
            pas1.Visibility = Visibility.Hidden;
            pas1.Width = 0;
            pas.Visibility = Visibility.Visible;
            pas.Width = 480;
            pas.Password = pas1.Text;
        }

        private void log_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flags[7] == true)
            {
                log.Text = null;
                log.Foreground = Brushes.Black;
                flags[7] = false;
            }
        }

        private void pas1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flags[8] == true)
            {
                pas1.Text = null;
                pas1.Foreground = Brushes.Black;
                flags[8] = false;
                pas.Foreground = Brushes.Black;
                pas.Visibility = Visibility.Visible;
                pas.Width = 480;
                pas1.Width = 0;
                pas.Focus();
            }
        }
        public bool AddUser(User user)
        {
            using(var db = new PCEntities1())
            {
                    db.User.Add(user);
                    db.SaveChanges();
                    return true;
            }
        }
        public bool DeleteUser(Entrant user)
        {
            Entrant u1 = null;
            using (var db = new PCEntities1())
            {
                foreach (var u in db.Entrant)
                {
                    if(u.IDEntrant == user.IDEntrant)
                    {
                        u1 = db.Entrant.Find(u.IDEntrant);
                        break;
                    }
                }
                db.Entrant.Remove(u1);
                db.SaveChanges();
                return true;
            }
        }
        public bool UpdateUser(Entrant user)
        {
            Entrant u1 = null;
            using (var db = new PCEntities1())
            {
                foreach (var u in db.Entrant)
                {
                    if (u.IDEntrant == user.IDEntrant)
                    {
                        u1 = db.Entrant.Find(u.IDEntrant);
                        break;
                    }
                }
                u1.Point = 300;
                db.SaveChanges();
                return true;
            }
        }
        public Entrant EnterUser(int id)
        {
            Entrant u1 = null;
            using (var db = new PCEntities1())
            {
                foreach (var u in db.Entrant)
                {
                    if (u.IDEntrant == id)
                    {
                        u1 = db.Entrant.Find(u.IDEntrant);
                        break;
                    }
                }
                return u1;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (pas.Visibility == Visibility.Hidden)
            {
                pas.Password = pas1.Text;
            }
            if(pas2.Visibility == Visibility.Hidden)
            {
                pas2.Password = pas3.Text;
            }
            if(log.Text.Trim() != "" && log.Text != "Введите логин" && pas.Password.Trim() != "" && pas2.Password.Trim() != "" && f.Text.Trim() != "" && f.Text != "Фамилия" && i.Text.Trim() != "" &&
                    i.Text.Trim() != "Имя" && o.Text.Trim() != "" && o.Text != "Отчество" && d.SelectedDate != null && p.Text.Trim() != "" && p.Text != "Паспортные данные" && ege.Text.Trim() != ""
                    && ege.Text != "Сумма баллов ЕГЭ" && im != null && int.Parse(ege.Text.Trim()) > 0 && int.Parse(ege.Text.Trim()) < 500)
            {
                 if(pas.Password == pas2.Password)
                 {
                     if(d.SelectedDate < DateTime.ParseExact("01.01.2010".ToString(), "dd.mm.yyyy", System.Globalization.CultureInfo.InvariantCulture) && d.SelectedDate > DateTime.ParseExact("01.01.1923".ToString(), "dd.mm.yyyy", System.Globalization.CultureInfo.InvariantCulture))
                     {
                        try
                        {
                            using (PCEntities1 db = new PCEntities1())
                            {
                                User user = new User()
                                {
                                    Login = log.Text.Trim(),
                                    Password = pas.Password.Trim(),
                                    Role = "Абитуриент"
                                };
                                db.User.Add(user);
                                db.SaveChanges();
                                Entrant entrant = new Entrant()
                                {
                                    User = user,
                                    LastName = f.Text.Trim(),
                                    FirstName = i.Text.Trim(),
                                    FatherName = o.Text.Trim(),
                                    DateBirthday = d.SelectedDate,
                                    PersonalyData = p.Text.Trim(),
                                    Point = int.Parse(ege.Text.Trim()),
                                    Photo = im,
                                    IDUser = user.IDUser
                                };
                                db.Entrant.Add(entrant);
                                db.SaveChanges();
                                MessageBox.Show("Пользователь успешно зарегистрирован");
                                MainWindow mainWindow = new MainWindow();
                                mainWindow.Show();
                                this.Close();
                            }
                         }
                        catch
                        {
                            MessageBox.Show("Неверно введены данные");
                        }
                     }
                     else
                     {
                         MessageBox.Show("Неверная дата рождения");
                     }
                 }
                 else
                 {
                     MessageBox.Show("Введенные пароли не совпадают");
                 }
            }
            else
            {
                 MessageBox.Show("Не все поля заполнены");
            }
        }
    }
}
