using RouteLocalization.Mvc;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using RouteLocalization.Mvc.Setup;
using RouteLocalizationInMVC.Controllers;

namespace RouteLocalizationInMVC
{
    public class RouteConfig
    {
        const string DefaultCulture = "tr";
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes(Localization.LocalizationDirectRouteProvider);

            ISet<string> acceptedCultures = new HashSet<string>() { "en", "fr", "tr" };

            var configuration = new Configuration
            {
                DefaultCulture = DefaultCulture,
                AcceptedCultures = acceptedCultures,
                AttributeRouteProcessing = AttributeRouteProcessing.AddAsNeutralAndDefaultCultureRoute,
                AddCultureAsRoutePrefix = true,
                AddTranslationToSimiliarUrls = true,
            };
            var localization = new Localization(configuration);

            localization.TranslateInitialAttributeRoutes();

            localization.ForCulture("en")
                .ForController<DefaultController>()
                .ForAction(c => c.Index()).AddTranslation("mainpage")
                .ForAction(c=> c.About()).AddTranslation("about")
                .ForAction(c=> c.Contact()).AddTranslation("contact");

            localization.ForCulture("fr")
                .ForController<DefaultController>()
                .ForAction(c => c.Index()).AddTranslation("pagedaccueil")
                .ForAction(c => c.About()).AddTranslation("àpropos")
                .ForAction(c => c.Contact()).AddTranslation("contact");


            CultureSensitiveHttpModule.GetCultureFromHttpContextDelegate = Localization.DetectCultureFromBrowserUserLanguages(acceptedCultures, DefaultCulture);
        }
    }
}

