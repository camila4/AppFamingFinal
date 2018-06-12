using AppFarming.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFarming.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListUsuario : ContentPage
	{
        private const string UrlRoot = "https://camiapifarmingapp.herokuapp.com/";
        private const string UrlListUsuario = UrlRoot + "users";
        private const string UrlListDeleteUsuario = UrlRoot + "users";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<User> _user;



        public ListUsuario ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.Properties.ContainsKey("id_user"))
            {
                ListDataUsuarios();
            }
            else
            {
                showWindowMainPage();
            }
        }

        // Metodo para listar todos los Usuarios
        async public void ListDataUsuarios()
        {
            string content = await client.GetStringAsync(UrlListUsuario);
            List<User> user = JsonConvert.DeserializeObject<List<User>>(content);
            _user = new ObservableCollection<User>(user);
            listViewUsuario.ItemsSource = _user;
        }


        // Metodo para Eliminar Usuario

        public void ClickDeleteContact(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DeleteUsuario(mi.CommandParameter.ToString());
        }

        async public void DeleteUsuario(string position)
        {
            HttpResponseMessage response = null;
            response = await client.DeleteAsync(UrlListDeleteUsuario + "/" + position);

            ListDataUsuarios();
        }


        async public void showWindowMainPage()
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        async public void Volver()
        {
            await Navigation.PushModalAsync(new Inicio());
        }
    }
}