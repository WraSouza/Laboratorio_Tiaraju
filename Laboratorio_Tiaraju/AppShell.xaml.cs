using Laboratorio_Tiaraju.View.MainViews;

namespace Laboratorio_Tiaraju
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
        }
    }
}
