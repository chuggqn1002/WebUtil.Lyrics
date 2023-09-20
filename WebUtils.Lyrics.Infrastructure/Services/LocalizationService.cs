using System.Collections;
using WebUtil.Lyrics.Application.Common.Interfaces.Services;

namespace WebUtil.Lyrics.Infrastructure.Services
{
    public class LocalizationService : ILocalizationService
    {
        public string? GetLocalizedString(string key, string culture)
        {
            // Implement logic to fetch localized strings from resources
            // based on the provided culture and key.
            // This might involve accessing resource files, a database, or other sources.
            //solution: get string from caching with _key?

            string[] cached = new string[]{"1", "2", "3" };
            Hashtable hashtable = new Hashtable() { {"key1", "value1"},{"key2", "value2"} };

            return hashtable[key] ==null? "": hashtable[key].ToString(); // Replace with actual logic
        }
    }
}
