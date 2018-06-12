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
	public partial class UpdateProducto : ContentPage
	{
        private const string UrlRoot = "https://camiapifarmingapp.herokuapp.com/";
        private const string UrlUpdateProducto = UrlRoot + "producto";
        private readonly HttpClient client = new HttpClient();
        private Produc produc;



        public UpdateProducto()

        {
            InitializeComponent();
       
        }

  //      public UpdateProducto (Produc produc)

		//{
		//	InitializeComponent ();
  //          this.Produc = produc;
  //          BindingContext = produc;
  //      }              
       

        // Metodo para actualizar un contacto
        async public void ClickButtonUpdateContact(object sender, EventArgs e)
        {
            produc.Name = entryNameUc.Text;
            produc.Valor = entryValorUc.Text;
            produc.Cantidad = entryCantidadUc.Text;
            produc.Descripcion = entryDescripcionUc.Text;

            var json = JsonConvert.SerializeObject(produc);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PutAsync(UrlUpdateProducto + "/" + produc.Id, content);

            await Navigation.PushModalAsync(new Inicio());
        }

    }
}