using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace App.Configurations
{
    public static class GlobalizationsConfig
    {
        public static IApplicationBuilder UseGlobalizationConfig(this IApplicationBuilder app)
        {
            //definindo a cultura do projeto para lingua portuguesa - definido pela gente
            var defaultCulture = new CultureInfo("pt-br");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };
            app.UseRequestLocalization(localizationOptions);


            return app;
        }

    }

}
