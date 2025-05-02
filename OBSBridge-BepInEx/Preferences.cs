using BepInEx.Configuration;

namespace WeatherElectric.OBSBridge;

internal class Preferences
{
    private readonly ConfigFile _config;
    
    public ConfigEntry<string> WebsocketURL;
    public ConfigEntry<string> WebsocketPassword;

    public Preferences(ConfigFile config)
    {
        _config = config;
        Initialize();
    }

    private void Initialize()
    {
        WebsocketURL = _config.Bind("Authentication", "WebsocketURL", "ws://127.0.0.1:4455",
            "The URL to use for the websocket connection. Usually don't have to change this.");
        WebsocketPassword = _config.Bind("Authentication", "WebsocketPassword", "REPLACEME",
            "The password to use for the websocket connection. Change this to the password you set in OBS.");
    }
}