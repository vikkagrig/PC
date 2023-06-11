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
    /// Логика взаимодействия для NewSpec.xaml
    /// </summary>
    public partial class NewSpec : Window
    {
        bool[] flags;
        AdminSpec admin;
        int idf;
        public NewSpec(AdminSpec admin, int idf)
        {
            InitializeComponent();
            flags = new bool[7] { true, true, true, true, true, true, true };
            this.admin = admin;
            this.idf = idf;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (code.Text.Trim() != "" && name.Text.Trim() != "" && but.Text.Trim() != "" && comm.Text.Trim() != "" && dur.Text.Trim() != "" && mark.Text.Trim() != "" &&
                cost.Text.Trim() != "" && int.Parse(but.Text.Trim()) > 0 && int.Parse(but.Text.Trim()) < 10000 && int.Parse(comm.Text.Trim()) > 0 &&
                int.Parse(comm.Text.Trim()) < 1000 && int.Parse(dur.Text.Trim()) > 0 && int.Parse(dur.Text.Trim()) < 50 && int.Parse(mark.Text.Trim()) > 0 && int.Parse(mark.Text.Trim()) < 500 && int.Parse(cost.Text.Trim()) > 0)
                {
                    using (PCEntities1 db = new PCEntities1())
                    {
                        try
                        {
                            Spaciality spaciality = new Spaciality()
                            {
                                Name = name.Text,
                                Code = code.Text,
                                PlaceBudget = int.Parse(but.Text),
                                PlaceCommerce = int.Parse(comm.Text),
                                Duration = int.Parse(dur.Text),
                                Mark = int.Parse(mark.Text),
                                Cost = int.Parse(cost.Text),
                                IDFac = idf
                            };
                            db.Spaciality.Add(spaciality);
                            db.SaveChanges();
                            MessageBox.Show("Успешно добавлено");
                            admin.NewSpec(admin.inst.SelectedIndex);
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Неверно введены даннеые");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены");
                }
            }
            catch
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void name_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flags[0] == true)
            {
                name.Text = null;
                flags[0] = false;
                name.Foreground = Brushes.Black;
            }
        }

        private void code_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flags[1] == true)
            {
                code.Text = null;
                flags[1] = false;
                code.Foreground = Brushes.Black;
            }
        }

        private void but_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flags[2] == true)
            {
                but.Text = null;
                flags[2] = false;
                but.Foreground = Brushes.Black;
            }
        }

        private void comm_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flags[3] == true)
            {
                comm.Text = null;
                flags[3] = false;
                comm.Foreground = Brushes.Black;
            }
        }

        private void dur_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flags[4] == true)
            {
                dur.Text = null;
                flags[4] = false;
                dur.Foreground = Brushes.Black;
            }
        }

        private void mark_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flags[5] == true)
            {
                mark.Text = null;
                flags[5] = false;
                mark.Foreground = Brushes.Black;
            }
        }

        private void cost_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flags[6] == true)
            {
                cost.Text = null;
                flags[6] = false;
                cost.Foreground = Brushes.Black;
            }
        }

        private void code_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789.".IndexOf(e.Text) < 0;
        }

        private void but_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
