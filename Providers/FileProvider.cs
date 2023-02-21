using Plugin;
using System;
using System.IO;
using System.Linq;

namespace Providers
{
    public class FileProvider : ICustomConfigurationProvider
    {
        private readonly string _filePath = "..\\..\\..\\..\\Reflection\\bin\\Debug\\net6.0\\appsettings.txt";

        public ConfigurationProviderType ConfigurationProviderType => ConfigurationProviderType.File;

        public string Read(string key)
        {
            var lines = File.ReadAllLines(_filePath);
            var line = lines.First(x => x.StartsWith($"\"{key}\""));
            var value = line.Split(": ", StringSplitOptions.RemoveEmptyEntries)[1]
                .Trim().Trim('\"');

            return value;
        }

        public void Write<TInput>(string key, TInput value)
        {
            var lines = File.ReadAllLines(_filePath).ToList();
            var line = lines.First(x => x.StartsWith($"\"{key}\""));
            var index = lines.IndexOf(line);

            var oldValue = line.Split(": ", StringSplitOptions.RemoveEmptyEntries)[1].Trim();
            line = line.Replace(oldValue, $"\"{value}\"");
            lines[index] = line;
            File.WriteAllLines(_filePath, lines);
        }
    }
}
