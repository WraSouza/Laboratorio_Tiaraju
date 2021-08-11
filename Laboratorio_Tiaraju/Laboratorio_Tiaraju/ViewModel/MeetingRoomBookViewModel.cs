using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Laboratorio_Tiaraju.ViewModel
{
    public class MeetingRoomBookViewModel : BaseViewModel
    {
        public Command ExitCommand { get; set; }

        public MeetingRoomBookViewModel()
        {
            ExitCommand = new Command( () => OpenMainView());
        }

        private void OpenMainView()
        {
            App.Current.MainPage = new View.AppShell();
        }
    }
}
