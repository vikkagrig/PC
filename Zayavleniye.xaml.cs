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
    /// Логика взаимодействия для Zayavleniye.xaml
    /// </summary>
    public partial class Zayavleniye : Window
    {
        User user;
        Entrant entrant;
        TestData testData;
        public Zayavleniye(User user, TestData testData)
        {
            InitializeComponent();
            this.user = user;
            this.testData = testData;
            code.Text = testData.Column1;
            name.Text = testData.Column2;
            b.Text = testData.Column3.ToString();
            p.Text = testData.Column4.ToString();
            sr.Text = testData.Column5.ToString();
            ege.Text = testData.Column6.ToString();
            cost.Text = testData.Column7.ToString();
            using(PCEntities1 db = new PCEntities1())
            {
                foreach(var i in db.Entrant)
                {
                    if(i.IDUser == user.IDUser)
                    {
                        entrant = i;
                        break;
                    }
                }
                foreach(var i in db.List)
                {
                    if(i.IDEntrant == entrant.IDEntrant)
                    {
                        foreach(ComboBoxItem c in prior.Items)
                        {
                            if (int.Parse(c.Tag.ToString()) == i.Priority)
                            {
                                prior.Items.Remove(c);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(form.SelectedIndex == -1 || form.SelectedIndex == 0)
            {
                MessageBox.Show("Выберите форму обучения");
            }
            else if((prior.SelectedIndex == -1 || prior.SelectedIndex == 0) && prior.Items.Count > 1)
            {
                MessageBox.Show("Выберите приоритет");
            }
            else if(prior.Items.Count == 1)
            {
                MessageBox.Show("Вы уже подали максимальное количество заявлений");
            }
            else
            {
                bool flag = true;
                using(PCEntities1 db = new PCEntities1())
                {
                    int id = 0;
                    foreach(var i in db.Spaciality)
                    {
                        if (i.Code == code.Text)
                            id = i.IDSpec;
                    }
                    foreach(var l in db.List)
                    {
                        if(l.IDSpec == id && l.IDEntrant == entrant.IDEntrant)
                        {
                            MessageBox.Show("Вы уже подали заявление на эту специальность");
                            flag = false;
                            break;
                        }
                    }
                    if(flag == true)
                    {
                        List list = new List()
                        {
                            FormStudy = form.Text.ToString(),
                            Priority = int.Parse(prior.Text.ToString()),
                            IDSpec = id,
                            IDEntrant = entrant.IDEntrant
                        };
                        db.List.Add(list);
                        db.SaveChanges();
                        MessageBox.Show("Заявление успешно подано");
                        this.Close();
                    }
                }
            }
        }
    }
}
