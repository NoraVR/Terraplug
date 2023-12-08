using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;


namespace Terraplug.Config
{
    public class TerraplugConfig : ModConfig

    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "Terraplug.json");
        static Preferences Configuration = new Preferences(ConfigPath);

        [Header("Responses")]
        [DefaultValue(true)]
        [Label("Attacking Enemies")]
        public bool RespondToAttacks;

        [Label("Getting Hit")]
        [DefaultValue(true)]
        public bool RespondToHits;

        [Label("Geting Killed")]
        [DefaultValue(true)]
        public bool RespondToDeath;

        [Header("Durations")]
        [Label("Duration for Attacking")]
        [Range(100, 3000)]
        [DefaultValue(350)]
        public int AttackDuration;

        [Label("Duration for Getting hit")]
        [Range(100, 3000)]
        [DefaultValue(500)]
        public int HitDuration;
        
        [Label("Duration for Dying")]
        [Range(100, 10000)]
        [DefaultValue(5000)]
        public int DeathDuration;

        [Header("Strengths")]

        [Label("Strength for Attacking")]
        [Range(0, 1)]
        [DefaultValue(0.25)]
        public float AttackStrength;

        [Label("Strength for Getting hit")]
        [Range(0, 1)]
        [DefaultValue(0.5)]
        public float HitStrength;

        [Label("Strength for Dying")]
        [Range(0, 1)]
        [DefaultValue(0.75)]
        public float deathStrength;




    }
}
