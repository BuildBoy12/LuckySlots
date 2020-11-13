namespace LuckySlots
{
    using Exiled.API.Interfaces;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Time in seconds between each automatic roll.")]
        public int Timer { get; private set; } = 300;

        [Description("Percent chance to receive an item from the item list.")]
        public int Chance { get; private set; } = 30;

        [Description(
            "A pool of items that can be given to players. If you want an item to have a higher chance than others, include it multiple times.")]
        public List<ItemType> Items { get; private set; } = new List<ItemType>
        {
            ItemType.Coin,
            ItemType.Coin,
            ItemType.GrenadeFrag
        };

        [Description(
            "A list of roles that cannot receive items. The plugin has already blacklisted SCPs and Spectators.")]
        public List<RoleType> BlacklistedRoles { get; private set; } = new List<RoleType>
        {
            RoleType.Tutorial
        };

        [Description("Message to be played when the slot machine rolls.")]
        public string Rolling { get; private set; } = "The Lucky Slots are rolling!";

        [Description(
            "Message to be played when the player receives an item. \"$ITEM\" will be replaced with the item's name.")]
        public string Lucky { get; private set; } = "You got lucky and received a $ITEM!";

        [Description("Message to be played when the player is eligable for an item but did not receive one.")]
        public string Unlucky { get; private set; } = "Aww, better luck next time!";
    }
}