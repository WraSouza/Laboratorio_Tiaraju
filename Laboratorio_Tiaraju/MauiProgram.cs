using CommunityToolkit.Maui;
using Laboratorio_Tiaraju.View.COMERCIAL;
using Laboratorio_Tiaraju.ViewModel;
using Laboratorio_Tiaraju.ViewModel.Login;
using Laboratorio_Tiaraju.Repositories.Interfaces.IReadServices;
using Microsoft.Extensions.Logging;
using UraniumUI;
using Laboratorio_Tiaraju.Repositories.Interfaces.IReadServices.IReadItemsServices;
using Laboratorio_Tiaraju.Repositories.Implementations.ReadServices.ReadItemsSAPServices;
using Laboratorio_Tiaraju.Repositories.Implementations.WriteServices.WriteBPRepository;
using Laboratorio_Tiaraju.Repositories.Interfaces.IWriteServices.IWriteBPRepository;

namespace Laboratorio_Tiaraju
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseUraniumUI()
.UseUraniumUIMaterial()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
                    fonts.AddFont("Montserrat-Medium.ttf", "MontserratMedium");
                    fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                    fonts.AddFont("Montserrat-SemiBold.ttf", "MontserratSemibold");
                });

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<DepartmentsViewModel>();
            builder.Services.AddTransient<ItemSAPViewModel>();
            builder.Services.AddTransient<InsertBusinessPartnerViewModel>();

            builder.Services.AddScoped<IRItemSAPServices, RItemsSAPServices>();           

            builder.Services.AddTransient<ItemSAPView>();
            builder.Services.AddTransient<InsertBusinessPartnerView>();

            builder.Services.AddScoped<BPRepository>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
