using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using static System.Net.Mime.MediaTypeNames;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Приемная_комиссия
{
    /// <summary>
    /// Логика взаимодействия для My.xaml
    /// </summary>
    public class TestData3
    {
        public int Column11 { get; set; }
        public string Column22 { get; set; }
        public int Column33 { get; set; }
        public string Column44 { get; set; }
    }
    public partial class My : Window
    {
        User user;
        Entrant entrant;
        public My(User user)
        {
            InitializeComponent();
            this.user = user;
            using (var db = new PCEntities1())
            {
                foreach (var n in db.Entrant)
                {
                    if(n.IDUser == user.IDUser)
                    {
                        entrant = n;
                        break;
                    }
                }
            }
            NewTable();
        }

        public void NewTable()
        {
            table.Items.Clear();
            using(PCEntities1 db = new PCEntities1())
            {
                foreach (var item in db.List)
                {
                    if (item.IDEntrant == entrant.IDEntrant)
                    {
                        Spaciality spaciality = null;
                        foreach (var spe in db.Spaciality)
                        {
                            if (item.IDSpec == spe.IDSpec)
                            {
                                spaciality = spe;
                                break;
                            }
                        }
                        table.Items.Add(new TestData3
                        {
                            Column11 = (int)item.IDList,
                            Column22 = spaciality.Name,
                            Column33 = (int)item.Priority,
                            Column44 = item.FormStudy
                        });
                    }
                }
            }
        }
        private void table_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TestData3 path = table.SelectedItem as TestData3;
            if (path != null)
            {
                MessageBoxResult r = (MessageBoxResult)MessageBox.Show("Вы точно хотите удалить это заявление?", "Уведомление", (MessageBoxButtons)MessageBoxButton.YesNo);
                if(r == MessageBoxResult.Yes) 
                {
                    using(PCEntities1 db = new PCEntities1())
                    {
                        List list = null;
                        foreach(var i in db.List)
                        {
                            if(i.IDList == path.Column11)
                            {
                                list = i;
                                break;
                            }
                        }
                        db.List.Remove(list);
                        db.SaveChanges();
                        MessageBox.Show("Успешно удалено");
                        NewTable();
                    }
                }
            }
        }
    }
}
