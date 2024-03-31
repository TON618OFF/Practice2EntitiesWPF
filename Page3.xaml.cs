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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {

        private BookSystemEntities genres = new BookSystemEntities();
        public Page3()
        {
            InitializeComponent();
            dg_BD_genres.ItemsSource = genres.Genres.ToList();
        }

        private void next_page_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page4();
            dg_BD_genres.Visibility = Visibility.Hidden;
            genrestxt.Text = "";
            pole1.Visibility = Visibility.Hidden;
            pole2.Visibility = Visibility.Hidden;
            pole3.Visibility = Visibility.Hidden;
            pole4.Visibility = Visibility.Hidden;
            pole5.Visibility = Visibility.Hidden;
            next_page.Visibility = Visibility.Hidden;
        }

        private void DeleteBooks_Click(object sender, RoutedEventArgs e)
        {
            if (dg_BD_genres.SelectedItem != null)
            {
                genres.Genres.Remove(dg_BD_genres.SelectedItem as Genres);
                genres.SaveChanges();
                dg_BD_genres.ItemsSource = genres.Genres.ToList();
            }
        }

        private void UpdateBooks_Click(object sender, RoutedEventArgs e)
        {
            if (dg_BD_genres.SelectedItem != null)
            {
                var selected = dg_BD_genres.SelectedItem as Genres;
                selected.Genre = pole1.Text;
                genres.SaveChanges();
                dg_BD_genres.ItemsSource = genres.Genres.ToList();
            }
        }

        private void AddBooks_Click(object sender, RoutedEventArgs e)
        {
            Genres g = new Genres();
            g.Genre = pole1.Text;
            genres.Genres.Add(g);
            genres.SaveChanges();
            dg_BD_genres.ItemsSource = genres.Genres.ToList();
        }

        private void dg_BD_genres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_BD_genres.SelectedItem != null)
            {
                var selected = dg_BD_genres.SelectedItem as Genres;

                pole1.Text = selected.Genre.ToString();

                genres.SaveChanges();
                dg_BD_genres.ItemsSource = genres.Genres.ToList();
            }
        }
    }
}
