
using UnityEngine;
using MelonLoader;
using static CheatBase.CheatBase;


namespace DmmCheatMod.functions
{
    public static class Godmode
    {

        public static bool godmode = false;
        private static bool patched = false;


        public static void Patch()
        {
            PatchPost(godmode, typeof(TSKBattleNote), "GetDamageRateValue", typeof(Godmode), nameof(GetDamageRateValue));
        }

        private static long GetDamageRateValue(long damage, TSKBattleAttack.AttackType kind, bool isCharge, TSKBattleNote attacker, ref long __result)
        {
            if (godmode && patched && attacker.Team.Type == TSKBattleTeam.TeamType.Enemy)
            {
                __result = 0;
                return __result;
            }
            return __result;
        }

        private static long GetDamageCutValue(long damage, TSKBattleAttack.AttackType kind, bool isCharge, TSKBattleNote attacker, ref long __result)
        {
            if (godmode && patched && attacker.Team.Type == TSKBattleTeam.TeamType.Enemy)
            {
                __result = 0;
                return __result;
            }
            return __result;
        }

    }
}
