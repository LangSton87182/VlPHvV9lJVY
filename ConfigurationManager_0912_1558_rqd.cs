// 代码生成时间: 2025-09-12 15:58:57
using System;
using System.IO;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace XamarinApp
{
    /// <summary>
    /// A class responsible for managing configuration files in the application.
    /// </summary>
    public class ConfigurationManager
    {
        private const string DefaultConfigFileName = "appsettings.json";
        private readonly string configFilePath;

        /// <summary>
        /// Initializes a new instance of the ConfigurationManager class.
        /// </summary>
        /// <param name="configFilePath">The file path for the configuration file.</param>
        public ConfigurationManager(string configFilePath = DefaultConfigFileName)
        {
            // Use the provided file path or the default config file name
            this.configFilePath = configFilePath;
        }

        /// <summary>
        /// Loads the configuration settings from the file.
        /// </summary>
        /// <typeparam name="T">The type of the configuration settings.</typeparam>
        /// <returns>The deserialized configuration settings.</returns>
        public T LoadConfiguration<T>() where T : class, new()
        {
            try
            {
                // Check if the file exists before attempting to read
                if (!File.Exists(configFilePath))
                {
                    throw new FileNotFoundException("Configuration file not found.", configFilePath);
                }

                // Read the contents of the file
                string configContent = File.ReadAllText(configFilePath);

                // Deserialize the JSON content into the specified type
                return JsonConvert.DeserializeObject<T>(configContent);
            }
            catch (Exception ex)
            {
                // Handle exceptions that occur during file reading or deserialization
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return null;
            }
        }

        /// <summary>
        /// Saves the configuration settings to the file.
        /// </summary>
        /// <typeparam name="T">The type of the configuration settings.</typeparam>
        /// <param name="config">The configuration settings to save.</param>
        public void SaveConfiguration<T>(T config) where T : class
        {
            try
            {
                // Serialize the configuration settings into a JSON string
                string configContent = JsonConvert.SerializeObject(config, Formatting.Indented);

                // Write the JSON content to the file
                File.WriteAllText(configFilePath, configContent);
            }
            catch (Exception ex)
            {
                // Handle exceptions that occur during serialization or file writing
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}