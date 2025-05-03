using WeatherElectric.OBSControl.OBS;

namespace WeatherElectric.OBSBridge;

/// <inheritdoc />
public class Main : MelonMod
{
    internal const string Name = "OBSBridge";
    internal const string Description = "Bridge between Unity and OBS";
    internal const string Author = "Mabel Amber";
    internal const string Company = "Weather Electric";
    internal const string Version = "1.0.0";
    internal const string DownloadLink = null;

    /// <inheritdoc />
    public override void OnInitializeMelon()
    {
        ModConsole.Setup(LoggerInstance);
        Preferences.Setup();
        
        ObsBridge.InitHooks();
        ObsBridge.Connect();
    }

    /// <inheritdoc />
    public override void OnApplicationQuit()
    {
        ObsBridge.Disconnect();
    }
}