using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Exiled.API.Features;
using HarmonyLib;
using PlayerRoles;
using PlayerRoles.PlayableScps.Scp079;

namespace InterestingSubClasses.Patches
{
    [HarmonyPatch(typeof(Scp079ScannerTracker), nameof(Scp079ScannerTracker.AddTarget))]
    internal static class Scp999Scp079ScanPatch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            List<CodeInstruction> newInstructions = new List<CodeInstruction>(instructions);

            Label returnLabel = generator.DefineLabel();
            Label skip = generator.DefineLabel();

            newInstructions.InsertRange(
                0,
                new[]
                {
                    new CodeInstruction(OpCodes.Ldarg_1),
                    new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Player), nameof(Player.Get), new[] { typeof(ReferenceHub) })),
                    new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Scp999Scp079ScanPatch), nameof(IsScp999))),
                    new CodeInstruction(OpCodes.Brfalse_S, skip),
                    new CodeInstruction(OpCodes.Br_S, returnLabel)
                });

            newInstructions[newInstructions.Count - 1].WithLabels(returnLabel);
            newInstructions[2].labels.Add(skip);
            foreach (var instruction in newInstructions)
                yield return instruction;
        }

        private static bool IsScp999(Player player)
        {
            if (player == null) return false;

            if (Plugin.Instance.customRoles.TryGetValue(player, out string role))
            {
                return role == Plugin.Instance._translations.SCP999RoleName;
            }

            return false;
        }
    }
}
