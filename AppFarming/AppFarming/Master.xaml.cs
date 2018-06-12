using AppFarming.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFarming
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : ContentPage
	{
		public Master ()
		{
			InitializeComponent ();
		}

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    if (Application.Current.Properties.ContainsKey("id_user"))
        //    {
        //        ListarProductos();
        //    }
        //    else
        //    {
        //        showWindowMainPage();
        //    }
        //}


        public void ClickButtonSignOff(object sender, EventArgs e)
        {
            Application.Current.Properties.Clear();
            showWindowMainPage();
        }


        async public void showWindowMainPage()
        {
            await Navigation.PushModalAsync(new Login());
        }
        
     
        async private void ListarProductos()
        {
            await Navigation.PushModalAsync(new ListProducto());
        }


        //*******************
        //async private void ListarProductos(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new ListProducto());
        //}

        //**************************+
        //async public void showWindowMainPage()
        //{
        //    await Navigation.PushModalAsync(new MainPage());
        //}

        async private void VerPerfil(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Perfil());
        }

        async private void CrearProducto(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CreateProducto());
        }
    }
}