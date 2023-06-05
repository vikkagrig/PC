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
    public class TestData2
    {
        public int ColumnF { get; set; }
        public int ColumnS { get; set; }
        public int ColumnTh { get; set; }
        public int ColumnFo { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для Spiski.xaml
    /// </summary>
    public partial class Spiski : Window
    {
        User user;
        Profile profile;
        Entrant entrant;
        public Spiski(User user, Profile profile)
        {
            InitializeComponent();
            this.user = user;
            this.profile = profile;
            using (PCEntities db = new PCEntities())
            {
                foreach (var i in db.Entrant)
                {
                    if (i.IDUser == user.IDUser)
                    {
                        entrant = i;
                        break;
                    }
                }
                for (int i = 0; i < db.Faculty.Count(); i++)
                {
                    inst.Items.Add(db.Faculty.ToList()[i].Name);
                }
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            profile.Visibility = Visibility.Visible;
            this.Close();
        }

        private void inst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            num.Text = "0";
            table.Items.Clear();
            spec.Items.Clear();
            spec.SelectedIndex = -1;
            form.SelectedIndex = -1;
            using (PCEntities db = new PCEntities())
            {
                Faculty faculty = null;
                foreach(var f in db.Faculty)
                {
                    if (f.Name == inst.SelectedItem.ToString())
                        faculty = f;
                }
                for (int i = 0; i < db.Spaciality.Count(); i++)
                {
                    if (db.Spaciality.ToList()[i].IDFac == faculty.IDFac)
                    {
                        spec.Items.Add(db.Spaciality.ToList()[i].Name);
                    }
                }
            }
        }

        private void spec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            num.Text = "0";
            table.Items.Clear();
            form.SelectedIndex = -1;
        }

        private void for_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            num.Text = "0";
            table.Items.Clear();
            int n = 0;
            if (form.SelectedIndex == 0)
            {
                using(PCEntities db = new PCEntities())
                {
                    Spaciality spaciality = null;
                    foreach(var sp in db.Spaciality)
                    {
                        if (sp.Name == spec.SelectedItem.ToString())
                        {
                            spaciality = sp;
                            break;
                        } 
                    }
                    foreach(var l in db.List)
                    {
                        if(l.IDSpec == spaciality.IDSpec && l.FormStudy == "Бюджет")
                        {
                            table.Items.Add(new TestData2 { ColumnF = (int)l.IDList, ColumnS = (int)l.IDEntrant, ColumnTh = (int)l.Priority, ColumnFo = (int)entrant.Point });
                            n++;
                        }
                    }
                    num.Text = n.ToString();
                }
            }
            else if (form.SelectedIndex == 1)
            {
                using (PCEntities db = new PCEntities())
                {
                    Spaciality spaciality = null;
                    foreach (var sp in db.Spaciality)
                    {
                        if (sp.Name == spec.SelectedItem.ToString())
                        {
                            spaciality = sp;
                            break;
                        }
                    }
                    foreach (var l in db.List)
                    {
                        if (l.IDSpec == spaciality.IDSpec && l.FormStudy == "Платная форма")
                        {
                            table.Items.Add(new TestData2 { ColumnF = (int)l.IDList, ColumnS = (int)l.IDEntrant, ColumnTh = (int)l.Priority, ColumnFo = (int)entrant.Point });
                            n++;
                        }
                    }
                    num.Text = n.ToString();
                }
            }
        }
    }
}
