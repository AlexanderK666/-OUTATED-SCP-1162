namespace SCP_1162
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using Exiled.API.Interfaces;

    class Config : IConfig
    {
        [Description("Enable SCP-1162?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Kill players when using SCP-1162 without items in the inventory?")]
        public bool KillPlayerWithoutItems { get; set; } = true;

        public bool PlayerInteractWithoutHandsBroadcastEnable { get; set; } = true;
        public ushort PlayerInteractWithoutHandsBroadcastDuration { get; set; } = 6;
        public string PlayerInteractWithoutHandsBroadcastMessage { get; set; } = "\n<size=50><color=#EC3535>You don't have the hands to do it</color></size>";

        [Description("Items that can be obtained from SCP-1162.")]
        public List<ItemType> Items { get; set; } = new List<ItemType>()
        {
            ItemType.KeycardO5,
            ItemType.SCP500,
            ItemType.MicroHID,
            ItemType.KeycardNTFCommander,
            ItemType.KeycardContainmentEngineer,
            ItemType.SCP268,
            ItemType.GunCOM15,
            ItemType.GrenadeFrag,
            ItemType.SCP207,
            ItemType.Adrenaline,
            ItemType.GunUSP,
            ItemType.KeycardFacilityManager,
            ItemType.Medkit,
            ItemType.KeycardNTFLieutenant,
            ItemType.KeycardSeniorGuard,
            ItemType.Disarmer,
            ItemType.KeycardZoneManager,
            ItemType.KeycardScientistMajor,
            ItemType.KeycardGuard,
            ItemType.Radio,
            ItemType.Ammo556,
            ItemType.Ammo762,
            ItemType.Ammo9mm,
            ItemType.GrenadeFlash,
            ItemType.WeaponManagerTablet,
            ItemType.KeycardScientist,
            ItemType.KeycardJanitor,
            ItemType.Coin,
            ItemType.Flashlight
        };
    }
}
