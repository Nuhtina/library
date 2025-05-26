using library.ApplicationData;
using Microsoft.Win32;
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
    /// Логика взаимодействия для EditBook.xaml
    /// </summary>
    public partial class EditBook : Page
    {
        private books book;
        public event Action BooksUpdated;
        public EditBook(books book)
        {
            InitializeComponent();
            this.book = book ?? throw new ArgumentNullException(nameof(book));

            EditBookName.Text = books.name;
            EditDescription.Text = books.DescriptionN;
            EditCookingTime.Text = books.CookingTime ?? "0";

            LoadAuthors();
            LoadCategories();

            //EditAuthor.SelectedItem = recipe.Authors;
            //EditCategory.SelectedItem = recipe.Categories;
        }

        public EditBook()
        {
            InitializeComponent();
            book = new books();

            LoadAuthors();
            LoadCategories();
        }

        private void LoadAuthors()
        {
            //var authors = AppConnect.model01.Authors.ToList();
            //EditAuthor.ItemsSource = authors;
            //EditAuthor.DisplayMemberPath = "AuthorName";
        }

        private void LoadCategories()
        {
            //var categories = AppConnect.model01.Categories.ToList();
            //EditCategory.ItemsSource = categories;
            //EditCategory.DisplayMemberPath = "CategoryName";
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            //recipe.RecipeName = EditRecipeName.Text;
            //recipe.DescriptionN = EditDescription.Text;
            //recipe.Authors = (Authors)EditAuthor.SelectedItem;
            //recipe.Categories = (Categories)EditCategory.SelectedItem;

            //if (!int.TryParse(EditCookingTime.Text, out int cookingTime) || cookingTime <= 0)
            //{
            //    MessageBox.Show("Пожалуйста, введите корректное время приготовления.");
            //    return;
            //}
            //recipe.CookingTime = cookingTime.ToString();
            //if (recipe.RecipeID == 0)
            //{
            //    AppConnect.model01.Recipes.Add(recipe);
            //}
            //else
            //{
            //    AppConnect.model01.Entry(recipe).State = EntityState.Modified;
            //}
            //AppConnect.model01.SaveChanges();
            //RecipeUpdated?.Invoke();
            //NavigationService.GoBack();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //if (NavigationService != null)
            //{
            //    NavigationService.Navigate(new DataOutput());
            //}
            //else
            //{
            //    MessageBox.Show("Не удалось выполнить навигацию. Попробуйте еще раз.");
            //}
        }
        private void LoadImageButton(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    var dialog = new OpenFileDialog();
            //    dialog.InitialDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Images"));

            //    dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
            //    dialog.Title = "Выберите изображение";

            //    if (dialog.ShowDialog() == true)
            //    {
            //        string photoName = System.IO.Path.GetFileName(dialog.FileName);
            //        recipe.ImageE = photoName;
            //        MessageBox.Show("Изображение загружено: " + photoName, "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Изображение не выбрано.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }
    }
}
