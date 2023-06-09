﻿using System;
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
            if (code.Text.Trim() != "" && name.Text.Trim() != "" && but.Text.Trim() != "" && comm.Text.Trim() != "" && dur.Text.Trim() != "" && mark.Text.Trim() != "" && 
                cost.Text.Trim() != "" && int.Parse(but.Text.Trim()) > 0 && int.Parse(but.Text.Trim()) < 10000 && int.Parse(comm.Text.Trim()) > 0 && 
                int.Parse(comm.Text.Trim()) < 1000 && int.Parse(dur.Text.Trim()) > 0 && int.Parse(dur.Text.Trim()) < 50 && int.Parse(mark.Text.Trim()) > 0 && int.Parse(mark.Text.Trim()) < 500 && int.Parse(cost.Text.Trim()) > 0)
            {
                using (PCEntities1 db = new PCEntities1())
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
                    try
                    {
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
                    catch
                    {
                        MessageBox.Show("Неверно введены данные");
                    }
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
                using (PCEntities1 db = new PCEntities1())
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

        private void code_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void code_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789.".IndexOf(e.Text) < 0;
        }
    }
}
