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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
            ButtonRegist.IsEnabled = false;
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PBpassword.Password != TBpass.Text)
            {
                ButtonRegist.IsEnabled = false;
                PBpassword.Background = Brushes.LightCoral;
                PBpassword.BorderBrush = Brushes.Red;
            }
            else
            {
                ButtonRegist.IsEnabled = true;
                PBpassword.Background = Brushes.LightGreen;
                PBpassword.BorderBrush = Brushes.Green;
            }
        }

        private void ButtonRegist_Click(object sender, RoutedEventArgs e)
        {
            string surname = TBsurname.Text;
            string name = TBname.Text;
            string patronymic = TBpatronymic.Text;
            string email = TBemail.Text;
            string password = TBpass.Text;
            string passwordRepeat = PBpassword.Password;

            if (string.IsNullOrWhiteSpace(surname) ||
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(patronymic) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(passwordRepeat))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (ApplicationData.AppConnect.model02.user.Count(x => x.email == TBemail.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже существует!", "Уведомление",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                user userObj = new user
                {
                    surname = surname,
                    name = name,
                    patronymic = patronymic,
                    email = email,
                    password = password,
                    ID_r = 2
                };
                AppConnect.model02.user.Add(userObj);
                AppConnect.model02.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);  
                TBsurname.Clear();
                TBname.Clear();
                TBpatronymic.Clear();
                TBemail.Clear();
                TBpass.Clear();
                PBpassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении данных: " + ex.Message, "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
