using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace Приемная_комиссия
{
    /// <summary>
    /// Логика взаимодействия для EditSpec.xaml
    /// </summary>
    public partial class EditSpec : Window
    {
        Spaciality spaciality;
        AdminSpec adminSpec;
        public EditSpec(Spaciality spaciality, AdminSpec adminSpec)
        {
            InitializeComponent();
            this.spaciality = spaciality;
            this.adminSpec = adminSpec;
            code.Text = spaciality.Code;
            name.Text = spaciality.Name;
            but.Text = spaciality.PlaceBudget.ToString();
            comm.Text = spaciality.PlaceCommerce.ToString();
            dur.Text = spaciality.Duration.ToString();
            mark.Text = spaciality.Mark.ToString();
            cost.Text = spaciality.Cost.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (code.Text != "" && name.Text != "" && but.Text != "" && comm.Text != "" && dur.Text != "" && mark.Text != "" && cost.Text != "")
            {
                using (PCEntities db = new PCEntities())
                {
                    Spaciality sp = null;
                    foreach (var s in db.Spaciality)
                    {
                        if (s.IDSpec == this.spaciality.IDSpec)
                        {
                            sp = db.Spaciality.Find(s.IDSpec);
                            break;
                        }
                    }
                    sp.Code = code.Text;
                    sp.Name = name.Text;
                    sp.PlaceBudget = int.Parse(but.Text);
                    sp.PlaceCommerce = int.Parse(comm.Text);
                    sp.Duration = int.Parse(dur.Text);
                    sp.Mark = int.Parse(mark.Text);
                    sp.Cost = int.Parse(cost.Text);
                    db.SaveChanges();
                    System.Windows.MessageBox.Show("Сохранено");
                    adminSpec.NewSpec(adminSpec.inst.SelectedIndex);
                    this.Close();
                }
            }
            else
                MessageBox.Show("Не все поля заполнены");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = (MessageBoxResult)System.Windows.MessageBox.Show("Вы точно хотите удалить эту специальность?", "Уведомление", (MessageBoxButton)(MessageBoxButtons)MessageBoxButton.YesNo);
            if (r == MessageBoxResult.Yes)
            {
                using (PCEntities db = new PCEntities())
                {
                    Spaciality spfrdlt = null;
                    foreach (var sp in db.Spaciality)
                    {
                        if (sp.IDSpec == this.spaciality.IDSpec)
                        {
                            spfrdlt = db.Spaciality.Find(sp.IDSpec);
                            break;
                        }
                    }
                    foreach (var l in db.List)
                    {
                        List list = null;
                        if (l.IDSpec == spfrdlt.IDSpec)
                        {
                            list = db.List.Find(l.IDList);
                            db.List.Remove(list);
                        }
                    }
                    db.Spaciality.Remove(spfrdlt);
                    db.SaveChanges();
                    System.Windows.MessageBox.Show("Успешно удалено");
                    adminSpec.NewSpec(adminSpec.inst.SelectedIndex);
                    this.Close();
                }
            }
        }
    }
}
