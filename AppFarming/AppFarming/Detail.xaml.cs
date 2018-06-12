using AppFarming.Items;
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
	public partial class Detail : TabbedPage
    {
        public Detail()
        {
            InitializeComponent();

            Children.Add(new Page1());
            Children.Add(new Page2());
            Children.Add(new Page3());
        }

        async private void Carrito(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Carrito());
        }
    }
}