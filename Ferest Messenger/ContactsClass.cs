using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Ferest_Messenger
{
    class ContactsClass
    {

        public ContactsClass()
        {

        }

        private async void MessageBox(string msg)
        {
            MessageDialog msgbox = new MessageDialog(msg);
            await msgbox.ShowAsync();

        }

        public async Task SearchContactsCheck()
        {
            var contactsStore = await ContactManager.RequestStoreAsync();
            IReadOnlyList<Contact> contacts = await contactsStore.FindContactsAsync();
            List<Contact> people = contacts.ToList();
            MessageBox(contacts.Count.ToString());

           
        }
    }
}
