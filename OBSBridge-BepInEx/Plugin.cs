using System.IO;
using System.Reflection;
using UnityEngine.SceneManagement;

namespace WeatherElectric.OBSBridge;

[BepInPlugin(PluginInfo.PluginGuid, PluginInfo.PluginName, PluginInfo.PluginVersion)]
public class Plugin : BaseUnityPlugin
{
    internal new static ManualLogSource Logger;
    internal static Preferences Preferences;

    private void Awake()
    {
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {PluginInfo.PluginGuid} is loaded!");

        Preferences = new Preferences(Config);
        
        LoadAssembly();
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private static void OnSceneLoaded(Scene arg0, LoadSceneMode loadSceneMode)
    {
        if (ObsBridge.Connected) return;
        ObsBridge.InitHooks();
        ObsBridge.Connect();
    }

    private static void LoadAssembly()
    {
        var pathtoassembly = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var depsPath = Path.Combine(pathtoassembly!, "deps");

        var files = Directory.GetFiles(depsPath, "*.dll", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            var assembly = Assembly.LoadFrom(file);
            Logger.LogInfo($"Loaded assembly: {assembly.FullName}");
        }
    }
}