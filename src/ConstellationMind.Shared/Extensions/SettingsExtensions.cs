using Microsoft.Extensions.Configuration;

namespace ConstellationMind.Shared.Extensions
{
    public static class SettingsExtensions
    {
        public static TModel GetSettings<TModel>(this IConfiguration configuration, string section = "") where TModel : new()
        {
            if (!section.IsEmpty())
            {
                var model = new TModel();
                configuration.GetSection(section).Bind(model);

                return model;
            }

            return default(TModel);
        }
    }
}
