using library.ApplicationData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для DataOutput.xaml
    /// </summary>
    public partial class DataOutput : Page
    {
        private List<books> allBooks;
        private books selectedBooks;
        public DataOutput()
        {
            InitializeComponent();
            ComboFilter.SelectedIndex = 0;
            ComboSort.SelectedIndex = 0;

            allBooks = AppConnect.model01.books.ToList();
            listBooks.ItemsSource = allBooks;

            var genres = AppConnect.model01.genres.ToList();
            foreach (var genre in genres)
            {
                //ComboFilter.Items.Add(new ComboBoxItem { Content = genres.name });
            }
            UpdateFoundCount(allBooks.Count);
        }
        private void listBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBooks = listBooks.SelectedItem as books;
            if (selectedBooks != null)
            {
                Debug.WriteLine($"Выбрана книга: {selectedBooks.name}");
            }
        }
        private void ComboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateBooksList();
        }
        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateBooksList();
        }
        private void ApplySearch_Click(object sender, RoutedEventArgs e)
        {
            UpdateBooksList();
        }
        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateBooksList();
        }
        private void ResetSearch_Click(object sender, RoutedEventArgs e)
        {
            TextSearch.Text = string.Empty;
            ComboFilter.SelectedIndex = 0;
            UpdateBooksList();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBooks.SelectedItem is books selectedBooks)
            {
                //EditBooks editPage = new EditBook(selectedBooks);
                //editPage.BooksUpdated += UpdateBooksList;
                //NavigationService.Navigate(editPage);
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            books newBook = new books();
            EditBook editPage = new EditBook(newBook);
            editPage.BooksUpdated += UpdateBooksList;
            NavigationService.Navigate(editPage);
        }
        private void UpdateBooksList()
        {
            string searchText = TextSearch.Text.ToLower();
            string selectedBooks = (ComboFilter.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (allBooks == null)
            {
                UpdateFoundCount(0);
                return;
            }
            var filteredBooks = allBooks.Where(books =>
                books != null &&
                books.name != null &&
                books.name.ToLower().Contains(searchText) &&
                (selectedBooks == "Жанр" ||
                 (books.genres != null && books.genres.name == selectedBooks)))
                .ToList();

            List<books> sortedBooks;
            if (ComboSort.SelectedItem is ComboBoxItem selectedItem)
            {
                string sortBy = selectedItem.Content.ToString();
                switch (sortBy)
                {
                    case "Сортировать от А до Я":
                        sortedBooks = filteredBooks.OrderBy(books => books.name).ToList();
                        break;
                    case "Сортировать от Я до А":
                        sortedBooks = filteredBooks.OrderBy(books => books.name).ToList();
                        break;
                    case "Не сортировать":
                    default:
                        sortedBooks = filteredBooks;
                        break;
                }
            }
            else
            {
                sortedBooks = filteredBooks;
            }
            listBooks.ItemsSource = sortedBooks;
            UpdateFoundCount(sortedBooks.Count);
        }
        private void UpdateFoundCount(int count)
        {
            TextFoundCount.Text = $"Найдено: {count}";
        }
        private void AddToFavoritesButton_Click(object sender, RoutedEventArgs e)
        {
            selectedBooks = listBooks.SelectedItem as books;

            if (selectedBooks == null)
            {
                MessageBox.Show("Выберите книгу!");
                return;
            }

            try
            {
                int currentUserId = AppConnect.ID_us;

                var existingLike = AppConnect.model01.favourites
                    .FirstOrDefault(l => l.ID_us == currentUserId
                                       && l.ID_us == selectedBooks.ID_bk);
                if (existingLike != null)
                {
                    MessageBox.Show("Эта книга уже в избранном!");
                    return;
                }

                var newLike = new favourites
                {
                    ID_us = currentUserId,
                    ID_bk = selectedBooks.ID_bk
                };

                AppConnect.model01.favourites.Add(newLike);
                //AppConnect.model01.SaveChanges();
                MessageBox.Show("Книга добавлена в избранное!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex}\n{ex.StackTrace}");
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        private void ViewFavoritesButton_Click(object sender, RoutedEventArgs e)
        {
            var favoritesPage = new PageLike();
            NavigationService.Navigate(favoritesPage);
        }
    }
}
