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
using static System.Net.Mime.MediaTypeNames;

namespace Приемная_комиссия
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        User user;
        public Profile(User user)
        {
            InitializeComponent();
            this.user = user;
            NewData();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Red red = new Red(this, user);
            red.Show();
            this.Visibility = Visibility.Hidden;
        }

        public void NewData()
        {
            using (PCEntities db = new PCEntities())
            {
                foreach (var e in db.Entrant)
                {
                    if (e.IDUser == user.IDUser)
                    {
                        lastname.Text = e.LastName;
                        firstname.Text = e.FirstName;
                        fathname.Text = e.FatherName;
                        hb.Text = e.DateBirthday.ToString().Substring(0, 10);
                        pasp.Text = e.PersonalyData;
                        ege.Text = e.Point.ToString();
                        MemoryStream stream = new MemoryStream(e.Photo);
                        ph.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }
                }
            }
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Spec spec = new Spec(user, this);
            spec.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Spiski spiski = new Spiski(user, this);
            spiski.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            My my = new My(user);
            my.Show();
        }
    }
}
