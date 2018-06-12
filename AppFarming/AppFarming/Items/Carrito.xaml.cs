using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFarming.Items
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Carrito : ContentPage
	{
		public Carrito ()
		{
			InitializeComponent ();
		}
        async private void Regresar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Inicio());
        }
        	}
}