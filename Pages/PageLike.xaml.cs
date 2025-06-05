using library.ApplicationData;
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

namespace library.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageLike.xaml
    /// </summary>
    public partial class PageLike : Page
    {
        private List<books> books;
        public PageLike()
        {
            InitializeComponent();
            UpdateLikeBooks();
        }
        private void UpdateLikeBooks()
        {
            var likeBook = AppConnect.model02.favourites.Where(x => x.ID_us == AppConnect.ID_us).Select(x => x.ID_bk).ToList();
            books = AppConnect.model02.books.Where(x => likeBook.Contains(x.ID_bk)).ToList();
            listBooks.ItemsSource = books;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DataOutput());
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить книгу из избранного?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var button = sender as Button;
                var book = (books)button.DataContext;
                var itemToRemove = AppConnect.model02.favourites.FirstOrDefault(b => b.ID_bk == books.ID_bk && AppConnect.ID_us == b.ID_us);
                AppConnect.model02.favourites.Remove(itemToRemove);
                AppConnect.model02.SaveChanges();
                UpdateLikeRecipes();
                MessageBox.Show("Книга удалена из избранного!");
            }
        }

        private void btnWord_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
