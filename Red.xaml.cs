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
    /// Логика взаимодействия для Red.xaml
    /// </summary>
    public partial class Red : Window
    {
        User user;
        Profile profile;
        byte[] im = null;
        public Red(Profile pr, User user)
        {
            InitializeComponent();
            this.user = user;
            this.profile = pr;
            using (PCEntities1 db = new PCEntities1())
            {
                foreach (var e in db.Entrant)
                {
                    if (e.IDUser == user.IDUser)
                    {
                        f.Text = e.LastName;
                        i.Text = e.FirstName;
                        o.Text = e.FatherName;
                        d.SelectedDate = e.DateBirthday;
                        p.Text = e.PersonalyData;
                        ege.Text = e.Point.ToString();
                    }
                }
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(photo.Text == "Успешно загружено")
            {
                Entrant entrant = null;
                using (var db = new PCEntities1())
                {
                    foreach (var en in db.Entrant)
                    {
                        if (en.IDUser == this.user.IDUser)
                        {
                            entrant = db.Entrant.Find(en.IDEntrant);
                            break;
                        }
                    }
                    if(f.Text.Trim() != "" && i.Text.Trim() != "" && o.Text.Trim() != "" && p.Text.Trim() != "" && ege.Text.Trim() != "" && int.Parse(ege.Text.Trim()) > 0 && int.Parse(ege.Text.Trim()) < 500)
                    { 
                        try
                        {
                            if (d.SelectedDate < DateTime.ParseExact("01.01.2010".ToString(), "dd.mm.yyyy", System.Globalization.CultureInfo.InvariantCulture) && d.SelectedDate > DateTime.ParseExact("01.01.1923".ToString(), "dd.mm.yyyy", System.Globalization.CultureInfo.InvariantCulture))
                            {
                                entrant.LastName = f.Text;
                                entrant.FirstName = i.Text;
                                entrant.FatherName = o.Text;
                                entrant.DateBirthday = d.SelectedDate;
                                entrant.PersonalyData = p.Text;
                                entrant.Point = int.Parse(ege.Text);
                                entrant.Photo = im;
                                db.SaveChanges();
                                MessageBox.Show("Успешно изменено");
                            }
                            else
                            {
                                MessageBox.Show("Неверная дата рождения");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Неверно введены данные");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверно введены данные");
                    }
                }
            }
            else
            {
                Entrant entrant = null;
                using (var db = new PCEntities1())
                {
                    foreach (var en in db.Entrant)
                    {
                        if (en.IDUser == this.user.IDUser)
                        {
                            entrant = db.Entrant.Find(en.IDEntrant);
                            break;
                        }
                    }
                    if (f.Text.Trim() != "" && i.Text.Trim() != "" && o.Text.Trim() != "" && p.Text.Trim() != "" && ege.Text.Trim() != "" && int.Parse(ege.Text.Trim()) > 0 && int.Parse(ege.Text.Trim()) < 500)
                    {
                        try
                        {
                            if (d.SelectedDate < DateTime.ParseExact("01.01.2010".ToString(), "dd.mm.yyyy", System.Globalization.CultureInfo.InvariantCulture) && d.SelectedDate > DateTime.ParseExact("01.01.1923".ToString(), "dd.mm.yyyy", System.Globalization.CultureInfo.InvariantCulture))
                            {
                                entrant.LastName = f.Text;
                                entrant.FirstName = i.Text;
                                entrant.FatherName = o.Text;
                                entrant.DateBirthday = d.SelectedDate;
                                entrant.PersonalyData = p.Text;
                                entrant.Point = int.Parse(ege.Text);
                                db.SaveChanges();
                                MessageBox.Show("Успешно изменено");
                            }
                            else
                            {
                                MessageBox.Show("Неверная дата рождения");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Неверно введены данные");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверно введены данные");
                    }
                }
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            profile.NewData();
            profile.Visibility = Visibility.Visible;
            this.Close();
        }

        private void f_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void ege_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void f_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
