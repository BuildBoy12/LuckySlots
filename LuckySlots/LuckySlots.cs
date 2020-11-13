namespace LuckySlots
{
    using Exiled.API.Features;
    using Handlers;
    using ServerEvents = Exiled.Events.Handlers.Server;
    
    public class LuckySlots : Plugin<Config>
    {
        internal static LuckySlots Instance;
        internal readonly Methods Methods = new Methods();
        private readonly ServerHandlers _serverHandlers = new ServerHandlers();
        
        public override void OnEnabled()
        {
            Instance = this;
            ServerEvents.WaitingForPlayers += _serverHandlers.OnWaitingForPlayers;
            ServerEvents.RoundStarted += _serverHandlers.OnRoundStart;
            ServerEvents.RoundEnded += _serverHandlers.OnRoundEnded;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            ServerEvents.WaitingForPlayers -= _serverHandlers.OnWaitingForPlayers;
            ServerEvents.RoundStarted -= _serverHandlers.OnRoundStart;
            ServerEvents.RoundEnded -= _serverHandlers.OnRoundEnded;
            Instance = null;
            base.OnDisabled();
        }
    }
}