namespace SCP_1162
{
    using Exiled.API.Features;
    using UnityEngine;

    class HurtingPlayersWithouHands_Component : MonoBehaviour
    {
        public void Update()
        {
            foreach (var id in Plugin.Instance.PlayersWithoutHands)
            {
                Player p = Player.Get(id);

                p.Hurt(Time.deltaTime*10, DamageTypes.Bleeding);
            }
        }
    }
}
