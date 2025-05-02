using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace WeatherElectric.OBSBridge;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal new static ManualLogSource Logger;
    internal static Preferences Preferences;

    private void Awake()
    {
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

        Preferences = new Preferences(Config);

        LoadAssemblies(out var result);

        if (!result) return;
        ObsBridge.InitHooks();
        ObsBridge.Connect();
    }

    private static void LoadAssemblies(out bool result)
    {
        var obsAssemblyPath = Path.Combine(Paths.PluginPath, "obs-websocket-dotnet.dll");
        var websocketAssemblyPath = Path.Combine(Paths.PluginPath, "Websocket.Client.dll");

        result = true;
        
        try
        {
            Assembly.LoadFrom(obsAssemblyPath);
            Assembly.LoadFrom(websocketAssemblyPath);
        }
        catch (FileNotFoundException e)
        {
            Logger.LogError($"Failed to load assemblies: {e.Message}");
            result = false;
            
        }
        catch (Exception e)
        {
            Logger.LogError($"Failed to load assemblies: {e.Message}");
            result = false;
        }
    }
}