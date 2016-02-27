using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ViewManagement;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.ApplicationModel.Contacts;
using System.Threading.Tasks;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Ferest_Messenger
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ShortcutVisible.Visibility = Visibility.Collapsed;

            Messages.Visibility = Visibility.Collapsed;

            MessageMenu.Visibility = Visibility.Collapsed;
        }

        private async void MessageBox(string msg)
        {
            MessageDialog msgbox = new MessageDialog(msg);
            await msgbox.ShowAsync();

        }

        private async Task SearchContactscheck()
        {
            var contactsStore = await ContactManager.RequestStoreAsync();
            IReadOnlyList<Contact> contacts = await contactsStore.FindContactsAsync();
            List<Contact> people = contacts.ToList();
            MessageBox(contacts.Count.ToString());
                
            ContactsList.ItemsSource = people;
        }

        private async void SearchContacts_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await SearchContactscheck();
        }

        private void ShortcutCollapsed_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (ShortcutVisible.Visibility == Visibility.Collapsed)
            {
                ShortcutVisible.Visibility = Visibility.Visible;
            }
            else { ShortcutVisible.Visibility = Visibility.Collapsed; }
            
        }

        private void ShortcutCollapsed_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (ShortcutVisible.Visibility == Visibility.Collapsed)
            {
                ShortcutVisible.Visibility = Visibility.Visible;
                MoveFirstelement.Begin();
                MoveSecondelement.Begin();
                MoveThirdelement.Begin();
                MoveHolderelement.Begin();
            }
            else { HideHolderelement.Begin(); ShortcutVisible.Visibility = Visibility.Collapsed; }
        }

        int k = 0;

        private void Menu2txtblk_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Menu1txtblk_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (MenuSelect.Margin == new Thickness(144, 77, 0, 0) || MenuSelect.Margin == new Thickness(271, 77, 0, 0))
            {
                FloatSelect1.Begin();
                MenuSelect.Margin = new Thickness(26, 77, 0, 0);
            }

            if (seters.Width == 10)
            {
                if (MenuSelect.Margin == new Thickness(132, 63, 0, 0) || MenuSelect.Margin == new Thickness(240, 63, 0, 0))
                {
                    FloatSelect1.Begin();
                    MenuSelect.Margin = new Thickness(18, 63, 0, 0);

                }
            }

            Messages.Visibility = Visibility.Visible;
            Contacts.Visibility = Visibility.Collapsed;
            
        }

        private void Menu2txtblk_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (MenuSelect.Margin == new Thickness(271, 77, 0, 0))
            {
                FloatSelect1.Begin();
                MenuSelect.Margin = new Thickness(144, 77, 0, 0);
               
            }

            if(MenuSelect.Margin == new Thickness(26, 77, 0, 0))
            {
                FloatSelect2.Begin();
                MenuSelect.Margin = new Thickness(144, 77, 0, 0);
                
            }

            if (seters.Width == 10)
            {
                if (MenuSelect.Margin == new Thickness(240, 63, 0, 0))
                {
                    FloatSelect1.Begin();
                    MenuSelect.Margin = new Thickness(132, 63, 0, 0);
                    
                }

                if (MenuSelect.Margin == new Thickness(18, 63, 0, 0))
                {
                    FloatSelect2.Begin();
                    MenuSelect.Margin = new Thickness(132, 63, 0, 0);

                }
            }

            Messages.Visibility = Visibility.Collapsed;
            MessageMenu.Visibility = Visibility.Collapsed;
            Contacts.Visibility = Visibility.Visible;
        }

        private void Menu3txtblk_Tapped(object sender, TappedRoutedEventArgs e)
        {

            if (MenuSelect.Margin == new Thickness(26, 77, 0, 0) || MenuSelect.Margin == new Thickness(144, 77, 0, 0))
            {
                FloatSelect2.Begin();
                MenuSelect.Margin = new Thickness(271, 77, 0, 0);
                
            }

            if (seters.Width == 10)
            {
                if (MenuSelect.Margin == new Thickness(18, 63, 0, 0) || MenuSelect.Margin == new Thickness(132, 63, 0, 0))
                {
                    FloatSelect2.Begin();
                    MenuSelect.Margin = new Thickness(240, 63, 0, 0);

                }
            }

            Messages.Visibility = Visibility.Collapsed;
            MessageMenu.Visibility = Visibility.Collapsed;
            Contacts.Visibility = Visibility.Collapsed;
        }

        private void Message_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SolidColorBrush scbg = new SolidColorBrush();
            SolidColorBrush scbw = new SolidColorBrush();
            scbg.Color = Color.FromArgb(255, 216, 235, 230);
            scbw.Color = Color.FromArgb(255, 255, 255, 255);

            if (MessageMenu.Visibility == Visibility.Collapsed)
            { ShowMessageMenu.Begin(); }
            if (seters.Width == 50 || seters.Width == 80)
            {
                MessageMenu.Visibility = Visibility.Visible;
                MainMenu.Visibility = Visibility.Visible;
                
            }
            else {
                MainMenu.Visibility = Visibility.Collapsed;
                MessageMenu.Visibility = Visibility.Visible;
            }

            ShowMessageMenu.Completed += ShowMessageMenu_Completed;
        }

        private void ShowMessageMenu_Completed(object sender, object e)
        {
        }

        int h = 1;

        private void Backbtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HideMessageMenu.Begin();
            HideMessageMenu.Completed += HideMessageMenu_Completed;

            if (h == 1)
            {
                MessageMenu.Visibility = Visibility.Collapsed;
            }

            MainMenu.Visibility = Visibility.Visible;
        }

        private void HideMessageMenu_Completed(object sender, object e)
        {
            h = 1;
            
        }

        
    }
}
