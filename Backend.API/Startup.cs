using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Backend.Storage.EntityFrameworkCore;
using Backend.Storage;
using Backend.Foundation;

using Common.Currency;
using Common.Currency.Fixer;
using Common.Utils.DateTime;

namespace Backend.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<ExpensesContext>(options => options.UseSqlServer("name=ConnectionStrings:ExpensesDatabase"));
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IUnitOfWork, ExpensesUnitOfWork>();
            services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();
            services.AddSingleton<DummyFixerCurrencyRatesProvider>();
            services.AddSingleton<ICurrencyRatesProvider>(provider => new CachingCurrencyRatesProvider(provider.GetRequiredService<DummyFixerCurrencyRatesProvider>()));
            services.AddSingleton<ICurrencyExchangeService, CurrencyExchangeService>();
            services.AddScoped<IExpenseManagementService, ExpenseManagementService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvc();
        }
    }
}
