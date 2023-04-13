using Laboratorio_Tiaraju.View;

namespace Laboratorio_Tiaraju;

public partial class AppShell : Shell
{
	public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(CalendarioCQDetailView), typeof(CalendarioCQDetailView));

        Routing.RegisterRoute(nameof(PrincipalView), typeof(PrincipalView));

        Routing.RegisterRoute(nameof(CalendarioCQView), typeof(CalendarioCQView));

        Routing.RegisterRoute(nameof(CalendarioCQExcluidosView), typeof(CalendarioCQExcluidosView));

        Routing.RegisterRoute(nameof(CalendarioCQFinalizadosView), typeof(CalendarioCQFinalizadosView));

        Routing.RegisterRoute(nameof(CadastroCalendarioCQView), typeof(CadastroCalendarioCQView));
    }
}
