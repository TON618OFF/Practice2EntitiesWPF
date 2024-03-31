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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace practice_2_entities
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private BookSystemEntities authors = new BookSystemEntities();
        public Page2()
        {
            InitializeComponent();
            dg_BD_authors.ItemsSource = authors.Authors.ToList();

        }

        private void next_page_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page3();
            dg_BD_authors.Visibility = Visibility.Hidden;
            authorstxt.Text = "";
            pole1.Visibility = Visibility.Hidden;
            pole2.Visibility = Visibility.Hidden;
            pole3.Visibility = Visibility.Hidden;
            pole4.Visibility = Visibility.Hidden;
            pole5.Visibility = Visibility.Hidden;
            next_page.Visibility = Visibility.Hidden;

        }

        private void DeleteBooks_Click(object sender, RoutedEventArgs e)
        {
            if (dg_BD_authors.SelectedItem != null)
            {
                authors.Authors.Remove(dg_BD_authors.SelectedItem as Authors);
                authors.SaveChanges();
                dg_BD_authors.ItemsSource = authors.Authors.ToList();
            }
        }

        private void UpdateBooks_Click(object sender, RoutedEventArgs e)
        {
            if (dg_BD_authors.SelectedItem != null)
            {
                var selected = dg_BD_authors.SelectedItem as Authors;
                selected.AuthorSurname = pole1.Text;
                selected.AuthorName = pole2.Text;
                selected.AuthorMiddleName = pole3.Text;
                authors.SaveChanges();
                dg_BD_authors.ItemsSource = authors.Authors.ToList();
            }
        }

        private void AddBooks_Click(object sender, RoutedEventArgs e)
        {
            Authors aut = new Authors();
            aut.AuthorSurname = pole1.Text;
            aut.AuthorName = pole2.Text;
            aut.AuthorMiddleName = pole3.Text;
            authors.Authors.Add(aut);
            authors.SaveChanges();
            dg_BD_authors.ItemsSource = authors.Authors.ToList();
        }

        private void dg_BD_authors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_BD_authors.SelectedItem != null)
            {
                var selected = dg_BD_authors.SelectedItem as Authors;
                    
                pole1.Text = selected.AuthorSurname.ToString();
                pole2.Text = selected.AuthorName.ToString();
                pole3.Text = selected.AuthorMiddleName.ToString();

                authors.SaveChanges();
                dg_BD_authors.ItemsSource = authors.Authors.ToList();
            }
        }
    }
}
