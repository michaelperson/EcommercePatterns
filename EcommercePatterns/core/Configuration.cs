using EcommercePatterns.core.Exceptions;
using EcommercePatterns.core.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.core
{
    // Pattern Singleton
    public sealed class Configuration : IConfiguration
    {
        private static readonly Configuration instance = new Configuration();
        private readonly string configPath = "appsettings.json";
        private JObject configData ;
        private readonly object lockObject = new object();
        private bool isInitialized;

        private Configuration() { }

        public static Configuration Instance
        {
            get { return instance; }
        }

        public void LoadConfiguration()
        {
            if (isInitialized) return;

            lock (lockObject)
            {
                if (isInitialized) return;

                try
                {
                    string jsonContent = File.ReadAllText(configPath);
                    configData = JObject.Parse(jsonContent);
                    isInitialized = true;
                }
                catch (Exception ex)
                {
                    throw new ConfigurationException("Erreur lors du chargement de la configuration", ex);
                }
            }
        }

        public T GetSection<T>(string sectionName) where T : class, new()
        {
            EnsureInitialized();

            try
            {
                var section = configData[sectionName];
                if (section == null)
                    throw new ConfigurationException($"Section '{sectionName}' non trouvée dans la configuration");

                return section.ToObject<T>();
            }
            catch (Exception ex)
            {
                throw new ConfigurationException($"Erreur lors de la récupération de la section '{sectionName}'", ex);
            }
        }

        public string GetValue(string key)
        {
            EnsureInitialized();

            try
            {
                var token = configData.SelectToken(key);
                return token?.ToString();
            }
            catch (Exception ex)
            {
                throw new ConfigurationException($"Erreur lors de la récupération de la valeur '{key}'", ex);
            }
        }

        private void EnsureInitialized()
        {
            if (!isInitialized)
                throw new ConfigurationException("La configuration n'a pas été chargée. Appelez LoadConfiguration() d'abord.");
        }
    }
}
