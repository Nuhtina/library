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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = ApplicationData.AppConnect.model02.user.FirstOrDefault(x => x.email == TBemail.Text && x.password == PBpassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show($"Здравствуйте, {userObj.name}!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information); 
                    AppConnect.ID_us = userObj.ID_us;
                    // Проверка роли пользователя и перенаправление
                    switch (userObj.ID_r)
                    {
                        case 1: // Администратор
                            NavigationService.Navigate(new Journal());
                            break;
                        case 2: // Обычный пользователь
                            NavigationService.Navigate(new DataOutput());
                            break;
                        default:
                            MessageBox.Show("Неизвестный тип пользователя", "Ошибка",
                                          MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message.ToString(), "Критическая ошибка приложения", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ButtonRegistr_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }

    }
}
