using Laboratorio_Tiaraju.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laboratorio_Tiaraju.View.Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : FlyoutPage
    {
        public MenuView()
        {
            InitializeComponent();

            BindingContext = new MenuViewModel(Navigation);
        }

        private void OpenSchedulesView(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new View.Master.MeetingRoomSchedulesView());
            IsPresented = false;
        }

        private void OpenBookView(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new View.Master.MeetingRoomBookView());
            IsPresented = false;
        }
    }
}