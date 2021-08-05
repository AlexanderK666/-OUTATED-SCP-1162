namespace SCP_1162
{
    using System.Collections.Generic;
    using System.Linq;

    using Exiled.API.Enums;
    using Exiled.Events.EventArgs;

    static class PlayerHandler
    {
        internal static void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            if (Plugin.Instance.PlayersWithoutHands.Contains(ev.Player.UserId))
            {
                ev.IsAllowed = false;
                if (!Plugin.Instance.Config.PlayerInteractWithoutHandsBroadcastEnable)
                    return;
                ev.Player.ClearBroadcasts();
                ev.Player.Broadcast(Plugin.Instance.Config.PlayerInteractWithoutHandsBroadcastDuration, Plugin.Instance.Config.PlayerInteractWithoutHandsBroadcastMessage);
                return;
            }
            if (ev.Pickup.gameObject.GetComponent<SCP_1162_Component>() == null)
                return;

            ev.IsAllowed = false;
            if (ev.Player.Items.Count < 1 && Plugin.Instance.Config.KillPlayerWithoutItems)
            {
                ev.Player.Handcuff(null);
                ev.Player.DropItems();
                ev.Player.EnableEffect(EffectType.Amnesia);
                ev.Player.EnableEffect(EffectType.SinkHole);
                Plugin.Instance.PlayersWithoutHands.Add(ev.Player.UserId);
                return;
            }
            List<ItemType> newItems = new List<ItemType>();
            foreach (ItemType itemType in ev.Player.Items.Select(x => x.id))
            {
                newItems.Add(Plugin.CalculateItem());
            }
            ev.Player.ResetInventory(newItems);
        }

        internal static void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            if (!Plugin.Instance.PlayersWithoutHands.Contains(ev.Player.UserId))
                return;
            ev.IsAllowed = false;
            if (!Plugin.Instance.Config.PlayerInteractWithoutHandsBroadcastEnable)
                return;
            ev.Player.ClearBroadcasts();
            ev.Player.Broadcast(Plugin.Instance.Config.PlayerInteractWithoutHandsBroadcastDuration, Plugin.Instance.Config.PlayerInteractWithoutHandsBroadcastMessage);
        }

        internal static void OnChangedRole(ChangedRoleEventArgs ev)
        {
            if(Plugin.Instance.PlayersWithoutHands.Contains(ev.Player.UserId))
                Plugin.Instance.PlayersWithoutHands.Remove(ev.Player.UserId);
        }
    }
}
