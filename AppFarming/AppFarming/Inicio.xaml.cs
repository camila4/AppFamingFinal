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
	public partial class Inicio : MasterDetailPage
    {
		public Inicio ()
		{
			InitializeComponent ();
            this.Master = new Master();
            this.Detail = new NavigationPage(new Detail());
            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}