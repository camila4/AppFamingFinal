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

        //Pagina Cerar Sesion
        public void ClickButtonSignOff(object sender, EventArgs e)
        {
            Application.Current.Properties.Clear();
            showWindowMainPage();
        }


        async public void showWindowMainPage()
        {
            await Navigation.PushModalAsync(new Login());
        }

        //Pagina para Listar un producto 
        async private void ListarProductos()
        {
            await Navigation.PushModalAsync(new ListProducto());
        }

        //Ver Pagina de Perfil
        async private void VerPerfil(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Perfil());
        }
        //Pagina para crear un producto
        async private void CrearProducto(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CreateProducto());
        }


        async private void actualizar(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new UpdateProducto());
        }

        //Pagina para Listar un producto 
        async private void ListarUsuarios()
        {
            await Navigation.PushModalAsync(new ListUsuario());
        }

        async private void inicioc()
        {
            await Navigation.PushModalAsync(new Inicio());
        }
        

    }
}