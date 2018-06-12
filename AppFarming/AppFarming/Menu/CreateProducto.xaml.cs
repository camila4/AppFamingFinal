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

namespace AppFarming.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateProducto : ContentPage
	{
        private const string UrlRoot = "https://camiapifarmingapp.herokuapp.com/";
        private const string UrlCreateProducto = UrlRoot + "producto";
        private readonly HttpClient client = new HttpClient();


        public CreateProducto ()
		{
			InitializeComponent ();
		}

        public void IngresarProducto(object sender, EventArgs e)
        {
            CreateNewProducto();
        }

        async public void CreateNewProducto()
        {
            Produc produc = new Produc()
            {
                Name = entryNameCc.Text,
                Valor = entryValorCc.Text,
                Cantidad= entryCantidadCc.Text,
                Descripcion = entryDescripcionCc.Text
            };

            var json = JsonConvert.SerializeObject(produc);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(UrlCreateProducto, content);
            string message = await response.Content.ReadAsStringAsync();

            await Navigation.PushModalAsync(new Inicio());
        }
    }
}