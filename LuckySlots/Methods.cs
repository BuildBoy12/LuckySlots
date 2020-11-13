namespace LuckySlots
{
    using Exiled.API.Features;
    using MEC;
    using System;
    using System.Collections.Generic;
    using static LuckySlots;

    public class Methods
    {
        private readonly Random _random = new Random();
        
        public IEnumerator<float> RunSlotsTimer()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(Instance.Config.Timer);
                Timing.RunCoroutine(RunSlots());
            }
        }

        public IEnumerator<float> RunSlots()
        {
            Map.Broadcast(2, Instance.Config.Rolling);
            yield return Timing.WaitForSeconds(3f);
            foreach (Player ply in Player.List)
            {
                if (ply.Team == Team.SCP || ply.Role == RoleType.Spectator || Instance.Config.BlacklistedRoles.Contains(ply.Role))
                    continue;

                if (_random.Next(100) < Instance.Config.Chance)
                {
                    int i = _random.Next(Instance.Config.Items.Count);
                    ply.AddItem(Instance.Config.Items[i]);
                    ply.Broadcast(5, Instance.Config.Lucky.Replace("$ITEM", Instance.Config.Items[i].ToString()));
                }
                else
                    ply.Broadcast(5, Instance.Config.Unlucky);
            }
        }
    }
}