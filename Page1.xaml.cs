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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private BookSystemEntities books = new BookSystemEntities();
        public Page1()
        {
            InitializeComponent();
            dg_BD_books.ItemsSource = books.Books.ToList();
        }

        private void DeleteBooks_Click(object sender, RoutedEventArgs e)
        {
            if (dg_BD_books.SelectedItem != null)
            {
                books.Books.Remove(dg_BD_books.SelectedItem as Books);
                books.SaveChanges();
                dg_BD_books.ItemsSource = books.Books.ToList();
            }
        }

        private void UpdateBooks_Click(object sender, RoutedEventArgs e)
        {
            if (dg_BD_books.SelectedItem != null)
            {
                var selected = dg_BD_books.SelectedItem as Books;
                selected.Title = pole1.Text;
                selected.Author_ID = Convert.ToInt32(pole2.Text);
                selected.Genre_ID = Convert.ToInt32(pole3.Text);
                selected.PublishDate = pole4.Text;
                books.SaveChanges();
                dg_BD_books.ItemsSource = books.Books.ToList();
            }
        }

        private void AddBooks_Click(object sender, RoutedEventArgs e)
        {
            Books b = new Books();
            b.Title = pole1.Text;
            b.Author_ID = Convert.ToInt32(pole2.Text);
            b.Genre_ID = Convert.ToInt32(pole3.Text);
            b.PublishDate = pole4.Text;
            books.Books.Add(b);
            books.SaveChanges();
            dg_BD_books.ItemsSource = books.Books.ToList();
        }

        private void next_page_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page2();
            dg_BD_books.Visibility = Visibility.Hidden;
            bookstxt.Text = "";
            pole1.Visibility = Visibility.Hidden;
            pole2.Visibility = Visibility.Hidden;
            pole3.Visibility = Visibility.Hidden;
            pole4.Visibility = Visibility.Hidden;
            pole5.Visibility = Visibility.Hidden;
            next_page.Visibility = Visibility.Hidden;

        }

        private void dg_BD_books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_BD_books.SelectedItem != null)
            {
                var selected = dg_BD_books.SelectedItem as Books;

                pole1.Text = selected.Title.ToString();
                pole2.Text = selected.Author_ID.ToString();
                pole3.Text = selected.Genre_ID.ToString();
                pole4.Text = selected.PublishDate.ToString();


                books.SaveChanges();
                dg_BD_books.ItemsSource = books.Books.ToList();
            }
        }
    }
}
