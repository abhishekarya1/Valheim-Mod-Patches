using BepInEx;
using HarmonyLib;
using UnityEngine;
using BepInEx.Configuration;

namespace TestMod
{
    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    [BepInProcess("valheim.exe")]
    public class TestMod: BaseUnityPlugin
    {
        const string pluginGUID = "com.aa1.testmod";
        const string pluginName = "TestMod by aa1";
        const string pluginVersion = "0.0.1";

        private readonly Harmony harmony = new Harmony(pluginGUID);
        private static ConfigEntry<float> m_baseHP;

        void Awake()
        {
            m_baseHP = Config.Bind<float>("General", "m_baseHP", 100f, "HP Value");
            Debug.Log("Initialized config and debugging");

            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(CraftingStation), "Start")]
        class Crafting_Patches
        {
            [HarmonyPrefix]
            static void setCraftingPatch(ref bool ___m_craftRequireRoof, ref bool ___m_craftRequireFire)
            {
                ___m_craftRequireRoof = false;
                ___m_craftRequireFire = false;
            }
        }

        [HarmonyPatch]
        class Bed_Patches
        {
            [HarmonyPrefix]
            [HarmonyPatch(typeof(Bed), "CheckFire")]
            static bool setCheckFire(ref bool __result)
            {
                __result= true;
                return false;
            }
            [HarmonyPrefix]
            [HarmonyPatch(typeof(Bed), "CheckExposure")]
            static bool setCheckExposure(ref bool __result)
            {
                __result = true;
                return false;
            }
            [HarmonyPrefix]
            [HarmonyPatch(typeof(Bed), "CheckWet")]
            static bool setCheckWet(ref bool __result)
            {
                __result = true;
                return false;
            }
        }

        [HarmonyPatch]
        class Portal_Patch
        {
            [HarmonyPrefix]
            [HarmonyPatch(typeof(Inventory), "IsTeleportable")]
            static bool setIsTelepotable(ref bool __result)
            {
                __result = true;
                return false;
            }
        }

        [HarmonyPatch(typeof(Player), "Awake")]
        static class HP_Patch
        {
            static void Postfix(ref float ___m_baseHP)
            {
                Debug.Log($"Old HP: {m_baseHP}");
                ___m_baseHP = m_baseHP.Value;
                Debug.Log($"New HP: {___m_baseHP}");
            }
        }

    }
}
