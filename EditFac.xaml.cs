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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace Приемная_комиссия
{
    /// <summary>
    /// Логика взаимодействия для EditFac.xaml
    /// </summary>
    public partial class EditFac : Window
    {
        Faculty faculty;
        AdminFac admin;
        public EditFac(Faculty faculty, AdminFac admin)
        {
            InitializeComponent();
            this.faculty = faculty;
            this.admin = admin;
            nam.Text = faculty.Name;
            des.Text = faculty.Description;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = (MessageBoxResult)System.Windows.MessageBox.Show("Вы точно хотите удалить этот факультет?", "Уведомление", (MessageBoxButton)(MessageBoxButtons)MessageBoxButton.YesNo);
            if (r == MessageBoxResult.Yes)
            {
                using (PCEntities1 db = new PCEntities1())
                {
                    Faculty f = null;
                    foreach (var en in db.Faculty)
                    {
                        if (en.IDFac == this.faculty.IDFac)
                        {
                            f = db.Faculty.Find(en.IDFac);
                            break;
                        }
                    }
                    Spaciality spaciality = null;
                    foreach(var sp in db.Spaciality)
                    {
                        if(sp.IDFac == f.IDFac)
                        {
                            spaciality = db.Spaciality.Find(sp.IDSpec);
                            foreach (var l in db.List)
                            {
                                List list = null;
                                if (l.IDSpec == spaciality.IDSpec)
                                {
                                    list = db.List.Find(l.IDList);
                                    db.List.Remove(list);
                                }
                            }
                            db.Spaciality.Remove(spaciality);
                        }
                    }
                    db.Faculty.Remove(f);
                    db.SaveChanges();
                    System.Windows.MessageBox.Show("Успешно удалено");
                    admin.NewData();
                    this.Close();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (nam.Text.Trim() != "" && des.Text.Trim() != "")
            {
                using (PCEntities1 db = new PCEntities1())
                {
                    try
                    {
                        Faculty f = null;
                        foreach (var en in db.Faculty)
                        {
                            if (en.IDFac == this.faculty.IDFac)
                            {
                                f = db.Faculty.Find(en.IDFac);
                                break;
                            }
                        }
                        f.Name = nam.Text;
                        f.Description = des.Text;
                        db.SaveChanges();
                        MessageBox.Show("Сохранено");
                        admin.NewData();
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Неверно введены данные");
                    }
                }
            }
            else
                MessageBox.Show("Не все поля заполнены");
        }

        private void nam_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
