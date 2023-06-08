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
    /// Логика взаимодействия для AdminFac.xaml
    /// </summary>
    public partial class AdminFac : Window
    {
        Admin admin;
        public AdminFac(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            NewData();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            admin.Visibility = Visibility.Visible;
            this.Close();
        }

        private void table_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Faculty path = table.SelectedItem as Faculty;
            if (path != null)
            {
                EditFac edit = new EditFac(path, this);
                edit.Show();
            }
        }
        public void NewData()
        {
            int n = 0;
            table.Items.Clear();
            using(var db = new PCEntities1())
            {
                foreach(var f in db.Faculty)
                {
                    table.Items.Add(new Faculty { IDFac = f.IDFac, Name = f.Name, Description = f.Description });
                    n++;
                }
                num.Text = n.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewFac fac = new NewFac(this);
            fac.Show();
        }
    }
}
