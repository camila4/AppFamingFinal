using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFarming
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async private void Crear(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateUser());
        }
        async private void Entrar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}