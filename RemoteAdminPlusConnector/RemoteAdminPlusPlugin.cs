using LabApi.Events.CustomHandlers;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;

namespace RemoteAdminPlusConnector
{
    public sealed class RemoteAdminPlusPlugin : Plugin<RemoteAdminPlusConfig>
    {
        public static RemoteAdminPlusPlugin Instance { get; private set; }

        public static RemoteAdminPlusConfig Cfg => Instance?.Config;
        
        public override string Name => "RemoteAdminPlus";
        public override string Description => "Syncs various things to web panel";
        public override string Author => "Lara The Protogen";
        public override Version Version => GetType().Assembly.GetName().Version;
        public override Version RequiredApiVersion { get; } = new (LabApiProperties.CompiledVersion);
        public override bool IsTransparent => true;
        
        public override void Enable()
        {
            Instance = this;
            CustomHandlersManager.RegisterEventsHandler(ServerEvents);
            CustomHandlersManager.RegisterEventsHandler(PlayerEvents);
            Logger.Info("RemoteAdminPlus Connector started.");
        }

        public override void Disable() => Logger.Info("RemoteAdminPlus Connector stopped.");
    }
}