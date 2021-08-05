namespace SCP_1162
{
    using System.Linq;
    using UnityEngine;
    using Mirror;
    using Exiled.API.Features;

    static class RoundHandler
    {
        internal static void OnRoundStarted()
        {
            Server.Host.GameObject.AddComponent<HurtingPlayersWithouHands_Component>();
            Plugin.Instance.PlayersWithoutHands.Clear();

            GameObject scp1162_obj = Exiled.API.Extensions.Item.Spawn(ItemType.WeaponManagerTablet, 0, Vector3.zero).gameObject;
            NetworkServer.UnSpawn(scp1162_obj);

            scp1162_obj.AddComponent<SCP_1162_Component>();
            scp1162_obj.GetComponent<Rigidbody>().useGravity = false;

            scp1162_obj.transform.parent = Map.Rooms.First(x => x.Type == Exiled.API.Enums.RoomType.Lcz012).Doors.First(x => x.name == "LCZ PortallessBreakableDoor (1)").transform;
            scp1162_obj.transform.localPosition = new Vector3(-5.3f, 1.5f, -4f);
            scp1162_obj.transform.localRotation = Quaternion.Euler(0, 270, 0);
            scp1162_obj.transform.localScale = new Vector3(10, 1, 1);

            NetworkServer.Spawn(scp1162_obj);
        }
    }
}
