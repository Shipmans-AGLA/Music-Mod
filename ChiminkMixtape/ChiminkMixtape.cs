using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.IO;
namespace ChiminkMixtape
{
	public class ChiminkMixtape : Mod
	{
        public static bool checkForBoss() {
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.boss && npc.active)
                {
                    return true;
                }
            }
            return false;
        }
        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");
            object sulphurObj;
            object cragsObj;
            object astralObj;
            object sunkenseaObj;
            object abyssObj;
            bool crags = false;
            bool astral = false;
            bool sunkensea = false;
            bool abyss = false;
            bool sulphur = false;
            if (calamity != null)
            {
                sulphurObj = calamity.Call("GetInZone", Main.LocalPlayer, "sulphursea");
                if (sulphurObj is bool fard) // the fard variables are just to check if an object is true because calamity calls return an object and not a bool, the name fard means nothing
                {
                    if (fard)
                    {
                        sulphur = true;
                    }
                }
                cragsObj = calamity.Call("GetInZone", Main.LocalPlayer, "crags");
                if (cragsObj is bool fard1)
                {
                    if (fard1)
                    {
                         crags = true;
                    }
                }
                astralObj = calamity.Call("GetInZone", Main.LocalPlayer, "astral");
                if (astralObj is bool fard2)
                {
                    if (fard2)
                    {
                        astral = true;
                    }
                }
                sunkenseaObj = calamity.Call("GetInZone", Main.LocalPlayer, "sunkensea");
                if (sunkenseaObj is bool fard3)
                {
                    if (fard3)
                    {
                        sunkensea = true;
                    }
                }
                abyssObj = calamity.Call("GetInZone", Main.LocalPlayer, "abyss");
                if (abyssObj is bool fard4)
                {
                    if (fard4)
                    {
                        abyss = true;
                    }
                }
            }
            // Note i didnt feel like renaming file names of most of the music files, hence most names are just Music_34, etc and a couple are smthn like "Greenpath"
            // bosshigh is the highest music priority, yet it fails to replace frost/pumpkin moon music. MusicPriority.BossHigh + 1 doesnt work!
            // this giant if else if chain is basically the priority, ones on top play over others (e.g. pillar music is on top, it will always play instead of  everything else if conditions are met)
            if (!checkForBoss() && !crags && !astral && !abyss && !sulphur && !abyss && !sunkensea)
            {
                if (Main.LocalPlayer.ZoneTowerNebula || Main.LocalPlayer.ZoneTowerSolar || Main.LocalPlayer.ZoneTowerStardust || Main.LocalPlayer.ZoneTowerVortex)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_34");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneOverworldHeight && Main.pumpkinMoon)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_30");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneOverworldHeight && Main.snowMoon)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_32");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneOverworldHeight && Main.eclipse)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_27");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneOldOneArmy)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_41");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneSandstorm)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_40");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneDungeon)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_23");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.tile[(int)(Main.LocalPlayer.Center.X / 16f), (int)(Main.LocalPlayer.Center.Y / 16f)].wall == WallID.LihzahrdBrickUnsafe)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_26");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneOverworldHeight && (Main.bloodMoon || Main.LocalPlayer.ZoneMeteor))
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Corpse");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneGlowshroom)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_29");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneOverworldHeight && Main.LocalPlayer.ZoneCorrupt) // triggers under the jungle even though its up here
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Darkroom");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneOverworldHeight && Main.LocalPlayer.ZoneCrimson) // triggers as intended (over jungle) even though above doesnt
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Crimson");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneOverworldHeight && Main.LocalPlayer.ZoneBeach) // doesnt trigger
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_43");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneOverworldHeight && Main.LocalPlayer.ZoneJungle && Main.dayTime) // triggers at night & over thr corruption
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Gardens");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneOverworldHeight && Main.LocalPlayer.ZoneJungle && !Main.dayTime) // doesnt trigger b/c above triggers
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_55");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneOverworldHeight && Main.LocalPlayer.ZoneSnow)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Kingdomsedge");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneOverworldHeight && Main.LocalPlayer.ZoneRain)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_19");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneOverworldHeight && Main.LocalPlayer.ZoneHoly && Main.dayTime)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Whitepalace");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneOverworldHeight && Main.LocalPlayer.ZoneDesert)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_21");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneOverworldHeight && Main.dayTime)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Greenpath");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneOverworldHeight && !Main.dayTime)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Crossroads");
                    priority = MusicPriority.BossHigh;
                }
                else if ((Main.LocalPlayer.ZoneDirtLayerHeight || Main.LocalPlayer.ZoneRockLayerHeight) && Main.LocalPlayer.ZoneCorrupt)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Bluewomb");
                    priority = MusicPriority.BossHigh;
                }
                else if ((Main.LocalPlayer.ZoneDirtLayerHeight || Main.LocalPlayer.ZoneRockLayerHeight) && Main.LocalPlayer.ZoneCrimson)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_33");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneUndergroundDesert)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_61");
                    priority = MusicPriority.BossHigh;
                }
                else if ((Main.LocalPlayer.ZoneDirtLayerHeight || Main.LocalPlayer.ZoneRockLayerHeight) && Main.LocalPlayer.ZoneJungle)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_54");
                    priority = MusicPriority.BossHigh;
                }
                else if ((Main.LocalPlayer.ZoneDirtLayerHeight || Main.LocalPlayer.ZoneRockLayerHeight) && Main.LocalPlayer.ZoneSnow)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_20");
                    priority = MusicPriority.BossHigh;
                }
                else if ((Main.LocalPlayer.ZoneDirtLayerHeight || Main.LocalPlayer.ZoneRockLayerHeight) && Main.LocalPlayer.ZoneHoly)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Shatteredillusion");
                    priority = MusicPriority.BossHigh;
                }
                else if ((Main.LocalPlayer.ZoneDirtLayerHeight || Main.LocalPlayer.ZoneRockLayerHeight))
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/underground");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneUnderworldHeight)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_36");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneSkyHeight && Main.dayTime)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_42");
                    priority = MusicPriority.BossHigh;
                }
                else if (Main.LocalPlayer.ZoneSkyHeight && !Main.dayTime)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Planetarium");
                    priority = MusicPriority.BossHigh;
                }
            }
            // iterates through all alive npcs, then asks if they are a certain boss to replace music with a certain song
            // note that this music plays globally and will not go away if you're far away like vanilla does, since idk how to do that
            // this also takes priority over biome music because its not in the else if chain and is after it
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active)
                {
                    if (npc.type == NPCID.KingSlime || npc.type == NPCID.EyeofCthulhu || npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.SkeletronHead || npc.type == NPCID.SkeletronPrime)
                    {
                        music = GetSoundSlot(SoundType.Music, "Sounds/Music/Hush");
                        priority = MusicPriority.BossHigh;
                    }
                    if (npc.type == NPCID.Spazmatism || npc.type == NPCID.Retinazer || npc.type == NPCID.WallofFlesh)
                    {
                        music = GetSoundSlot(SoundType.Music, "Sounds/Music/Delirium");
                        priority = MusicPriority.BossHigh;
                    }
                    if (npc.type == NPCID.BrainofCthulhu || npc.type == NPCID.TheDestroyer)
                    {
                        music = GetSoundSlot(SoundType.Music, "Sounds/Music/Mom");
                        priority = MusicPriority.BossHigh;
                    }
                    if (npc.type == NPCID.Golem || npc.type == NPCID.CultistBoss)
                    {
                        music = GetSoundSlot(SoundType.Music, "Sounds/Music/Golem");
                        priority = MusicPriority.BossHigh;
                    }
                    if (npc.type == NPCID.QueenBee)
                    {
                        music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_25");
                        priority = MusicPriority.BossHigh;
                    }
                    if (npc.type == NPCID.Plantera)
                    {
                        music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_24");
                        priority = MusicPriority.BossHigh;
                    }
                    if (npc.type == NPCID.DukeFishron)
                    {
                        music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_58");
                        priority = MusicPriority.BossHigh;
                    }
                    if (npc.type == NPCID.MoonLordCore)
                    {
                        music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_38");
                        priority = MusicPriority.BossHigh;
                    }
                    if (npc.type == NPCID.GoblinArcher || npc.type == NPCID.GoblinPeon || npc.type == NPCID.GoblinWarrior || npc.type == NPCID.GoblinSorcerer || npc.type == NPCID.GoblinSummoner || npc.type == NPCID.GoblinThief)
                    {
                        music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_39");
                        priority = MusicPriority.BossHigh;
                    }
                    if (npc.type == NPCID.PirateCaptain || npc.type == NPCID.PirateCorsair || npc.type == NPCID.PirateCrossbower || npc.type == NPCID.PirateDeadeye || npc.type == NPCID.PirateDeckhand || npc.type == NPCID.PirateShip)
                    {
                        music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_35");
                        priority = MusicPriority.BossHigh;
                    }
                    if (npc.type == NPCID.MartianDrone || npc.type == NPCID.MartianEngineer || npc.type == NPCID.MartianOfficer || npc.type == NPCID.MartianSaucer || npc.type == NPCID.GrayGrunt || npc.type == NPCID.Scutlix || npc.type == NPCID.RayGunner || npc.type == NPCID.MartianWalker)
                    {
                        music = GetSoundSlot(SoundType.Music, "Sounds/Music/Music_37");
                        priority = MusicPriority.BossHigh;
                    }
                }
            }

        }
    }
}