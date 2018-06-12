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
	public partial class ListProducto : ContentPage
	{
        private const string UrlRoot = "https://camiapifarmingapp.herokuapp.com/";
        private const string UrlListProducto = UrlRoot + "producto";
        private const string UrlDeleteProducto = UrlRoot + "producto";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Produc> _produc;

        public ListProducto ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.Properties.ContainsKey("id_user"))
            {
                ListDataProductos();
            }
            else
            {
                showWindowMainPage();
            }
        }

        // Metodo para listar todos los Productos
        async public void ListDataProductos()
        {
            string content = await client.GetStringAsync(UrlListProducto);
            List<Produc> produc = JsonConvert.DeserializeObject<List<Produc>>(content);
            _produc = new ObservableCollection<Produc>(produc);
            listViewProducto.ItemsSource = _produc;
        }

        // Metodo para Eliminar Producto

        async public void DeleteProducto(string position)
        {
            HttpResponseMessage response = null;
            response = await client.DeleteAsync(UrlDeleteProducto + "/" + position);

            ListDataProductos();
        }

        //Actualizar Profucto

        //public void ClickUpdateContact(object sender, EventArgs e)
        //{
        //    var mi = sender as MenuItem;
        //    var item = mi.BindingContext as Produc;

        //    Produc produc = new Produc()
        //    {
        //        Id = item.Id,
        //        Name = item.Name,
        //        Valor = item.Valor,
        //        Cantidad = item.Cantidad,
        //        Descripcion = item.Descripcion,
        //        Image = item.Image
        //    };

        //    //Produc(produc);
        //}

        //async public void Produc(Produc produc)
        //{
        //    await Navigation.PushModalAsync(new UpdateProducto(produc));
        //}

        async public void showWindowMainPage()
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        async public void ClickUpdateContact(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new UpdateProducto());
        }

        async private void CrearProducto(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CreateProducto());
        }


    }
}