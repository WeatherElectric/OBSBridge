using WeatherElectric.OBSControl.OBS;

namespace WeatherElectric.OBSBridge;

public class Main : MelonMod
{
    internal const string Name = "OBSBridge";
    internal const string Description = "Bridge between Unity and OBS";
    internal const string Author = "Mabel Amber";
    internal const string Company = "Weather Electric";
    internal const string Version = "1.0.0";
    internal const string DownloadLink = null;

    public override void OnInitializeMelon()
    {
        ModConsole.Setup(LoggerInstance);
        Preferences.Setup();
        
        ObsBridge.InitHooks();
        ObsBridge.Connect();
    }

    public override void OnApplicationQuit()
    {
        ObsBridge.Disconnect();
    }
}