using Laboratorio_Tiaraju.View.COMERCIAL;
using Laboratorio_Tiaraju.View.MainViews;

namespace Laboratorio_Tiaraju
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
            Routing.RegisterRoute(nameof(DepartmentsView), typeof(DepartmentsView));
            Routing.RegisterRoute(nameof(ComercialView), typeof(ComercialView));
            Routing.RegisterRoute(nameof(ItemSAPView), typeof(ItemSAPView));
            Routing.RegisterRoute(nameof(InsertBusinessPartnerView), typeof(InsertBusinessPartnerView));
        }
    }
}
