using AppFarming.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFarming
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private const string UrlRoot = "https://camiapifarmingapp.herokuapp.com/";
        private const string UrlValidarUser = UrlRoot + "validateUsers";
        private readonly HttpClient client = new HttpClient();

        public Login ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.Properties.ContainsKey("id_user"))
            {
                ShowWindowListContacts();
            }
        }

        async private void ClickButtonSignIn(object sender, EventArgs e)
        {
            User user = new User() { Username = entryUser.Text, Password = entryPass.Text };

            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(UrlValidarUser, content);
            string message = await response.Content.ReadAsStringAsync();
            List<User> users = JsonConvert.DeserializeObject<List<User>>(message);

            if (users[0].Success)
            {
                Application.Current.Properties["id_user"] = users[0].Id;
                ShowWindowListContacts();
            }
            else
            {
                await DisplayAlert("Error", "El usuario no existe", "OK");
            }
        }

        async private void ClickButtonCreateUser(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CreateUser());
        }

        async private void ShowWindowListContacts()
        {
            await Navigation.PushModalAsync(new Inicio());
        }

    }
}