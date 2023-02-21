namespace Plugin
{
    public interface ICustomConfigurationProvider
    {
        ConfigurationProviderType ConfigurationProviderType { get; }

        string Read(string key);

        void Write<TInput>(string key, TInput value);
    }
}