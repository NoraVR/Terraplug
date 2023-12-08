using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraplug.Config;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.Player;

namespace Terraplug
{
    internal class VibrationModule : ModPlayer
    {
           public bool RespondToAttacks(Player player)
        {
            return ModContent.GetInstance<TerraplugConfig>().RespondToAttacks;
        }
            public bool RespondToHits(Player player)
        {
            return ModContent.GetInstance<TerraplugConfig>().RespondToHits;
        }
            public bool RespondToDeath(Player player)
        {
            return ModContent.GetInstance<TerraplugConfig>().RespondToDeath;
        }


        public override void OnEnterWorld()
        {
            Task.Run(() => VibrationController.ConnectAsync());
            Terraria.Main.NewText("Terraplug has connected! enjoy~ >:3", 255, 180, 234);
        }
        
    public override void OnHitAnything(float x, float y, Entity victim)
    {
        int time = ModContent.GetInstance<TerraplugConfig>().AttackDuration;
        float strength = ModContent.GetInstance<TerraplugConfig>().AttackStrength;

        if (ModContent.GetInstance<TerraplugConfig>().RespondToAttacks)
        {
            Task.Run(() => VibrationController.Vibrate(strength, time));
        }
    }

        public override void OnHurt(HurtInfo info)
        {
            int time = ModContent.GetInstance<TerraplugConfig>().HitDuration;
            float strength = ModContent.GetInstance<TerraplugConfig>().HitStrength;

            if (ModContent.GetInstance<TerraplugConfig>().RespondToHits)
            {
                Task.Run(() => VibrationController.Vibrate(strength, time));
            }
        }



        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            int time = ModContent.GetInstance<TerraplugConfig>().DeathDuration;
            float strength = ModContent.GetInstance<TerraplugConfig>().deathStrength;

            if (ModContent.GetInstance<TerraplugConfig>().RespondToDeath)
            {
                Task.Run(() => VibrationController.Vibrate(strength, time));
            }

        }

        public override void PreSavePlayer()
            => Task.Run(VibrationController.DisconnectAsync);

    }
    

}
