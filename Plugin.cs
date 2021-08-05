namespace SCP_1162
{
    using System;
    using System.Collections.Generic;

    using Exiled.API.Features;
    using ServerH = Exiled.Events.Handlers.Server;
    using PlayerH = Exiled.Events.Handlers.Player;

    class Plugin : Plugin<Config>
    {

        public override string Author => "AlexanderK";
        public override string Name => "SCP-1162";
        public override string Prefix => "scp1162";
        public override Version Version => new Version(1, 0, 0);

        public static Plugin Instance { get; private set; }

        public List<string> PlayersWithoutHands;

        public override void OnEnabled()
        {
            Instance = this;
            PlayersWithoutHands = new List<string>();
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            PlayersWithoutHands = null;
            Instance = null;
            UnregisterEvents();
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            ServerH.RoundStarted += RoundHandler.OnRoundStarted;

            PlayerH.PickingUpItem += PlayerHandler.OnPickingUpItem;
            PlayerH.InteractingDoor += PlayerHandler.OnInteractingDoor;
            PlayerH.ChangedRole += PlayerHandler.OnChangedRole;
        }

        private void UnregisterEvents()
        {
            ServerH.RoundStarted -= RoundHandler.OnRoundStarted;

            PlayerH.PickingUpItem -= PlayerHandler.OnPickingUpItem;
            PlayerH.InteractingDoor -= PlayerHandler.OnInteractingDoor;
            PlayerH.ChangedRole -= PlayerHandler.OnChangedRole;
        }

        public static ItemType CalculateItem()
        {
            return Instance.Config.Items[UnityEngine.Random.Range(0, Instance.Config.Items.Count - 1)];
        }
    }
}
