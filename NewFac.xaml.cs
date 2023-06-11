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
    /// Логика взаимодействия для NewFac.xaml
    /// </summary>
    public partial class NewFac : Window
    {
        bool flag, flag1;
        AdminFac admin;
        public NewFac(AdminFac admin)
        {
            InitializeComponent();
            flag1 = true;
            flag = true;
            this.admin = admin;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (PCEntities1 db = new PCEntities1())
                {
                    if (nam.Text.Trim() != "" && nam.Text != "Название" && des.Text.Trim() != "" && des.Text != "Описание")
                    {
                        try
                        {
                            Faculty faculty = new Faculty()
                            {
                                Name = nam.Text,
                                Description = des.Text
                            };
                            db.Faculty.Add(faculty);
                            db.SaveChanges();
                            MessageBox.Show("Успешно добавлено");
                            admin.NewData();
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Неверно введены данные");
                        }
                    }
                    else
                        MessageBox.Show("Не все поля заполнены");
                }
            }
            catch
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                nam.Text = null;
                flag = false;
                nam.Foreground = Brushes.Black;
            }
        }

        private void nam_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            if (flag1 == true)
            {
                des.Text = null;
                flag1 = false;
                des.Foreground = Brushes.Black;
            }
        }
    }
}
