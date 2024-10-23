
using UnityEngine;
using MelonLoader;
using static CheatBase.CheatBase;


namespace DmmCheatMod.functions
{
    public static class DemageHack
    {

        public static bool demagehack = false;
        private static bool patched = false;
        public static int rate =1;


        //public static void Patch()
        //{
        //    PatchPost(demagehack, typeof(TSKBattleNote), "GetDamageCutValue", typeof(DemageHack), nameof(GetDamageCutValue));
        //    MelonLogger.Msg($"DemageHack: {demagehack}");   

        //}



        //private static long GetDamageCutValue(long damage, TSKBattleAttack.AttackType kind, bool isCharge, TSKBattleNote attacker, ref long __result)
        //{
        //    if (demagehack && patched && attacker.Team.Type == TSKBattleTeam.TeamType.Enemy)
        //    {
        //        __result *= rate;
        //        return __result;
        //    }
        //    return __result;
        //}

    }
}
