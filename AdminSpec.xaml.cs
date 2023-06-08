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
    /// Логика взаимодействия для AdminSpec.xaml
    /// </summary>
    public partial class AdminSpec : Window
    {
        Admin admin;
        public AdminSpec(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            using (PCEntities1 db = new PCEntities1())
            {
                for (int i = 0; i < db.Faculty.Count(); i++)
                {
                    inst.Items.Add(db.Faculty.ToList()[i].Name);
                }
                db.SaveChanges();
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            admin.Visibility = Visibility.Visible;
            this.Close();
        }

        public void NewSpec(int i)
        {
            int n = 0;
            table.Items.Clear();
            int index = i;
            using (var db = new PCEntities1())
            {
                foreach (var item in db.Spaciality)
                {
                    if (item.IDFac == index + 1)
                    {
                        table.Items.Add(new Spaciality
                        {
                            IDSpec = item.IDSpec,
                            Code = item.Code,
                            Name = item.Name,
                            PlaceBudget = (int)item.PlaceBudget,
                            PlaceCommerce = (int)item.PlaceCommerce,
                            Duration = (int)item.Duration,
                            Mark = (int)item.Mark,
                            Cost = (int)item.Cost
                        });
                        n++;
                    }
                }
                num.Text = n.ToString();
                if (n == 1)
                {
                    text.Text = " специальность";
                }
                else if (n == 2 || n == 3 || n == 4)
                {
                    text.Text = " специальности";
                }
                else
                    text.Text = " специальностей";
            }
        }

        private void inst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NewSpec(inst.SelectedIndex);
        }

        private void table_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Spaciality path = table.SelectedItem as Spaciality;
            if (path != null)
            {
                EditSpec edit = new EditSpec(path, this);
                edit.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(inst.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите факультет");
            }
            else
            {
                NewSpec spec = new NewSpec(this, inst.SelectedIndex + 1);
                spec.Show();
            }
        }
    }
}
