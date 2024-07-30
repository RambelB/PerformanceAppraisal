using AppraisalBussiness;
using AppraisalBussiness.Interfaces;
using AppraisalBussiness.Repositories;
using AppraisalWeb.Services;
namespace AppraisalWeb.Configurations
{
    public static class ConfigureBussinessService
    {
        public static IServiceCollection AddBussinessService(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRekapitulasiRepository, RekapitulasiRepository>();
            services.AddScoped<IIndikatorUtamaRepository, IndikatorUtamaRepository>();
            services.AddScoped<IIndikatorAreaRepository, IndikatorAreaRepository>();
            services.AddScoped<IKompetensiDasarRepository, KompetensiDasarRepository>();
            services.AddScoped<IPerubahanNilaiRepository, PerubahanNilaiRepository>();
            services.AddScoped<IKpiRepository, KpiRepository>();
            services.AddScoped<AuthService>();
            services.AddScoped<TestService>();
            services.AddScoped<HomeService>();
            services.AddScoped<PenilaianService>();
            return services;
        }
    }
}
