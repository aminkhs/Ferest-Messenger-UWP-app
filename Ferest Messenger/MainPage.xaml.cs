using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

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
            MainMenu.Visibility = Visibility.Visible;
            ContactDetailsGrid.Visibility = Visibility.Collapsed;
            ContactDetailsGrid.Opacity = 0;

            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {

                var statusBar = StatusBar.GetForCurrentView();
                if (statusBar != null)
                {
                    statusBar.BackgroundOpacity = 1;
                    statusBar.BackgroundColor = Color.FromArgb(1, 37, 162, 131);
                    statusBar.ForegroundColor = Colors.White;
                }
            }

            ContactNametxtblk.Tapped += ContactNametxtblk_Tapped;
            ContactNametxtblk.PointerMoved += ContactNametxtblk_PointerMoved;
            ContactNametxtblk.PointerExited += ContactNametxtblk_PointerExited;
        }

        private void BackPopUpTransblack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BackBlackPopHide.Begin();
            ContactDetailsPopHide.Begin();
            BackBlackPopHide.Completed += BackBlackPopHide_Completed;
        }

        private void BackBlackPopHide_Completed(object sender, object e)
        {
            BackPopUpTransblack.Visibility = Visibility.Collapsed;
            ContactDetailsGrid.Visibility = Visibility.Collapsed;
        }

        private void ContactNametxtblk_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContactDetailsGrid.Visibility = Visibility.Visible;
            BackPopUpTransblack.Visibility = Visibility.Visible;
            BackBlackPopShow.Begin();
            ContactDetailsPopShow.Begin();
        }

        private void App_BackRequested(object sender,BackRequestedEventArgs e)
        {
            
            // Navigate back if possible, and if the event has not 
            // already been handled .
            
            HideMessageMenu.Begin();
            MessageMenu.Margin = new Thickness(100000, 0, 0, 0);
            HideMessageMenu.Completed += HideMessageMenu_Completed1;
            
            
        }

        private void HideMessageMenu_Completed1(object sender, object e)
        {
            MessageMenu.Visibility = Visibility.Collapsed;
            MessageMenu.Margin = new Thickness( 0, 0, 0, 0);
        }

        private async void MessageBox(string msg)
        {
            MessageDialog msgbox = new MessageDialog(msg);
            await msgbox.ShowAsync();

        }

        //Contacts
        #region
        private async Task SearchContactscheck()
        {
            var contactsStore = await ContactManager.RequestStoreAsync();
            IReadOnlyList<Contact> contacts = await contactsStore.FindContactsAsync();
            
            List<Contact> people = contacts.ToList();
            MessageBox(contacts.Count.ToString());

            for(int i = 0; i < people.Count; i++)
            {
                ContactsList.Items.Add(contacts[i]);
            }

           // ContactsList.ItemsSource = people;
        }

        private async void SearchContacts_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await SearchContactscheck();
        }
        #endregion

        //ShortCuts
        #region
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
        #endregion
        int k = 0;
        //Top Menu txtblk
        #region
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
        #endregion

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

        double t = 0;

        private void Sendbtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Add a Message Holder
            NewMessageClass msg = new NewMessageClass();

            double m = 1000;
            m = MSGHolder2Contents.Margin.Bottom;
            m += 60;
            t = MSGHolder2Contents.Margin.Bottom - 60;

            Grid MSGHolder2Contents2 = new Grid();
            MSGHolder2Contents2.Width = MSGHolder2Contents.Width;
            MSGHolder2Contents2.Height = MSGHolder2Contents.Height;
            MSGHolder2Contents2.Margin = MSGHolder2Contents.Margin;
            MSGHolder2Contents2.VerticalAlignment = MSGHolder2Contents.VerticalAlignment;
            MSGHolder2Contents2.HorizontalAlignment = MSGHolder2Contents.HorizontalAlignment;
            if (t <= 40)
                MSGHolder2Contents2.Visibility = Visibility.Collapsed;
            if (!msg.recivemsg)
            {
                //if u r send a message
                msg.msgtext.IsTextSelectionEnabled = true;
                msg.msgtext.TextWrapping = TextWrapping.Wrap;
                msg.msgtext.Foreground = MSG2.Foreground;
                msg.msgtext.Text = MessagetxtBox.Text;
                msg.msgtext.FontSize = MSG2.FontSize;
                msg.msgtext.Width = MSG2.Width;
                msg.msgtext.Height = MSG2.Height;
                msg.msgtext.VerticalAlignment = VerticalAlignment.Bottom;
                msg.msgtext.HorizontalAlignment = HorizontalAlignment.Right;
                msg.msgtext.Margin = MSG2.Margin;

                msg.time.IsTextSelectionEnabled = true;
                msg.time.TextWrapping = TextWrapping.Wrap;
                //msg.time.Text = "12:00";
                msg.time.Foreground = MSGTime2.Foreground;
                msg.time.FontSize = MSGTime2.FontSize;
                msg.time.Width = MSGTime2.Width;
                msg.time.Height = MSGTime2.Height;
                msg.time.VerticalAlignment = VerticalAlignment.Bottom;
                msg.time.HorizontalAlignment = HorizontalAlignment.Right;
                msg.time.Margin = MSGTime2.Margin;

                msg.rectangle.Height = MessageHolder2.Height;
                msg.rectangle.Width = MessageHolder2.Width;
                msg.rectangle.Fill = MessageHolder2.Fill;
                msg.rectangle.RadiusX = MessageHolder2.RadiusX;
                msg.rectangle.RadiusY = MessageHolder2.RadiusY;
                msg.rectangle.VerticalAlignment = VerticalAlignment.Bottom;
                msg.rectangle.HorizontalAlignment = HorizontalAlignment.Right;
                msg.rectangle.Margin = MessageHolder2.Margin;
                msg.rectangle.Stroke = MessageHolder2.Stroke;

                MSGHolder2Contents.Margin = new Thickness(0, 0, 0, m);

                msg.AddMsgAnimate();
                MoveUpmsg.Begin();

                MessageBox("Message Sent");
            }

            else {
                //if u r receive a message
                msg.msgtext.IsTextSelectionEnabled = true;
                msg.msgtext.TextWrapping = TextWrapping.Wrap;
                msg.msgtext.Foreground = MSG1.Foreground;
                msg.msgtext.Text = MessagetxtBox.Text;
                msg.msgtext.FontSize = MSG1.FontSize;
                msg.msgtext.Width = MSG1.Width;
                msg.msgtext.Height = MSG1.Height;
                msg.msgtext.VerticalAlignment = VerticalAlignment.Bottom;
                msg.msgtext.HorizontalAlignment = HorizontalAlignment.Left;
                msg.msgtext.Margin = MSG1.Margin;

                msg.time.IsTextSelectionEnabled = true;
                msg.time.TextWrapping = TextWrapping.Wrap;
                //msg.time.Text = "12:00";
                msg.time.Foreground = MSGTime1.Foreground;
                msg.time.FontSize = MSGTime1.FontSize;
                msg.time.Width = MSGTime1.Width;
                msg.time.Height = MSGTime1.Height;
                msg.time.VerticalAlignment = VerticalAlignment.Bottom;
                msg.time.HorizontalAlignment = HorizontalAlignment.Left ;
                msg.time.Margin = MSGTime1.Margin;

                msg.rectangle.Height = MessageHolder1.Height;
                msg.rectangle.Width = MessageHolder1.Width;
                msg.rectangle.Fill = MessageHolder1.Fill;
                msg.rectangle.RadiusX = MessageHolder1.RadiusX;
                msg.rectangle.RadiusY = MessageHolder1.RadiusY;
                msg.rectangle.VerticalAlignment = VerticalAlignment.Bottom;
                msg.rectangle.HorizontalAlignment = HorizontalAlignment.Left;
                msg.rectangle.Margin = MessageHolder1.Margin;
                msg.rectangle.Stroke = MessageHolder1.Stroke;

                MSGHolder2Contents.Margin = new Thickness(0, 0, 0, m-10);

                msg.AddMsgAnimate();
                MoveUpmsg.Begin();

                MessageBox("Message Recieved");
            }

            

            MSGHolder2Contents2.Children.Add(msg.rectangle);
            MSGHolder2Contents2.Children.Add(msg.time);
            MSGHolder2Contents2.Children.Add(msg.msgtext);

            MessageMenu.Children.Add(MSGHolder2Contents2);
                        
            MSGHolder2Contents2.Margin = new Thickness(0, 0, 0, t);
            
        }
        //change pointers
        #region

        private void ContactNametxtblk_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Arrow, 1);
        }

        private void ContactNametxtblk_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Hand, 1);
        }

        private void Backbtn_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Hand, 1);
        }

        private void Backbtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Arrow, 1);
        }

        private void ContactImage_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Hand, 1);
        }

        private void ContactImage_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Arrow, 1);
        }
        #endregion
    }
}
