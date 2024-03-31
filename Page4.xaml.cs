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
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {

        private BookSystemEntities bookloans = new BookSystemEntities();
        public Page4()
        {
            InitializeComponent();
            dg_BD_bookloans.ItemsSource = bookloans.BookLoans.ToList();
        }

        private void DeleteBooks_Click(object sender, RoutedEventArgs e)
        {
            if (dg_BD_bookloans.SelectedItem != null)
            {
                bookloans.BookLoans.Remove(dg_BD_bookloans.SelectedItem as BookLoans);
                bookloans.SaveChanges();
                dg_BD_bookloans.ItemsSource = bookloans.BookLoans.ToList();
            }
        }

        private void UpdateBooks_Click(object sender, RoutedEventArgs e)
        {
            if (dg_BD_bookloans.SelectedItem != null)
            {
                var selected = dg_BD_bookloans.SelectedItem as BookLoans;
                selected.Book_ID = Convert.ToInt32(pole1.Text);
                selected.Reader_ID = Convert.ToInt32(pole2.Text);
                selected.LoanDate = pole3.Text;
                selected.ReturnDate = pole4.Text;
                bookloans.SaveChanges();
                dg_BD_bookloans.ItemsSource = bookloans.BookLoans.ToList();
            }
        }

        private void AddBooks_Click(object sender, RoutedEventArgs e)
        {
            BookLoans bl = new BookLoans();
            bl.Book_ID = Convert.ToInt32(pole1.Text);
            bl.Reader_ID = Convert.ToInt32(pole2.Text);
            bl.LoanDate = pole3.Text;
            bl.ReturnDate = pole4.Text;
            bookloans.BookLoans.Add(bl);
            bookloans.SaveChanges();
            dg_BD_bookloans.ItemsSource = bookloans.BookLoans.ToList();
        }

        private void dg_BD_bookloans_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_BD_bookloans.SelectedItem != null)
            {
                var selected = dg_BD_bookloans.SelectedItem as BookLoans;

                pole1.Text = selected.Book_ID.ToString();
                pole2.Text = selected.Reader_ID.ToString();
                pole3.Text = selected.LoanDate.ToString();
                pole4.Text = selected.ReturnDate.ToString();

                bookloans.SaveChanges();
                dg_BD_bookloans.ItemsSource = bookloans.BookLoans.ToList();
            }
        }
    }
}
