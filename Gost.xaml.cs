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
    /// Логика взаимодействия для Gost.xaml
    /// </summary>
    public partial class Gost : Window
    {
        public Gost()
        {
            InitializeComponent();
            using (PCEntities db = new PCEntities())
            {
                for (int i = 0; i < db.Faculty.Count(); i++)
                {
                    inst.Items.Add(db.Faculty.ToList()[i].Name);
                }
                db.SaveChanges();
            }
        }

        private void inst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = 0;
            table.Items.Clear();
            int index = inst.SelectedIndex;
            using (var db = new PCEntities())
            {
                foreach (var item in db.Spaciality)
                {
                    if (item.IDFac == index + 1)
                    {
                        table.Items.Add(new TestData
                        {
                            Column1 = item.Code,
                            Column2 = item.Name,
                            Column3 = (int)item.PlaceBudget,
                            Column4 = (int)item.PlaceCommerce,
                            Column5 = (int)item.Duration,
                            Column6 = (int)item.Mark,
                            Column7 = (int)item.Cost
                        });
                        n++;
                    }
                }
                num.Text = n.ToString();
                if (n == 1 || n == 21)
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

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
