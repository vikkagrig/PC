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

namespace Приемная_комиссия
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool flag, flag1, isClosed;
        public MainWindow()
        {
            InitializeComponent();
            flag = false;
            flag1 = false;
            isClosed = false;
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Reg reg = new Reg();
            reg.Show();
            this.Close();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Вход успешен");
            Gost gost = new Gost();
            gost.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pas.Visibility == Visibility.Hidden)
            {
                pas.Password = pas1.Text;
            }
            if (log.Text != "" && log.Text != "Логин" && pas.Password != "")
            {
                using (PCEntities db = new PCEntities())
                {
                    foreach (User user in db.User)
                    {
                        if (user.Login == log.Text && user.Password == pas.Password && user.Role == "Абитуриент")
                        {
                            MessageBox.Show("Вход успешен");
                            Profile profile = new Profile(user);
                            profile.Show();
                            this.Close();
                            log.Text = "";
                            pas.Password = "";
                            pas1.Text = "";
                            isClosed = true;
                            break;
                        }
                        else if (user.Login == log.Text && user.Password == pas.Password && user.Role == "Администратор")
                        {
                            MessageBox.Show("Вход успешен");
                            Admin admin = new Admin(user);
                            admin.Show();
                            this.Close();
                            log.Text = "";
                            pas.Password = "";
                            pas1.Text = "";
                            isClosed = true;
                            break;
                        }
                    }
                    if (isClosed == false)
                    {
                        MessageBox.Show("Логин или пароль введены неверно");
                    }
                }
            }
            else
                MessageBox.Show("Не все поля заполнены");
        }
        private void log_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flag == false)
            {
                log.Text = null;
                flag = true;
                log.Foreground = Brushes.Black;
            }   
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //показать
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

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            //скрыть
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

        private void pas1_GotFocus(object sender, RoutedEventArgs e)
        {
            if(flag1 == false)
            {
                pas1.Visibility = Visibility.Hidden;
                pas1.Text = null;
                flag1 = true;
                pas.Foreground = Brushes.Black;
                pas.Visibility = Visibility.Visible;
                pas.Width = 480;
                pas1.Width = 0;
                pas.Focus();
            }
        }
    }
}
