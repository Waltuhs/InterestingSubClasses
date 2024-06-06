using HarmonyLib;
using PlayerRoles;
using System.Collections.Generic;
using System.Reflection.Emit;
using Exiled.API.Features.Pools;
using Exiled.API.Features;
using PlayerRoles.PlayableScps.Scp096;

namespace InterestingSubClasses.Patches
{
    [HarmonyPatch(typeof(Scp096TargetsTracker), nameof(Scp096TargetsTracker.AddTarget))]
    public static class Scp999LookingAtScp096Patch
    {
        private static bool IsScp999(Player observer)
        {
            if (Plugin.Instance.customRoles.TryGetValue(observer, out string role))
            {
                return role == Plugin.Instance.Translation.SCP999RoleName;
            }
            else
            {
                return false;
            }
        }

        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            List<CodeInstruction> newInstructions = ListPool<CodeInstruction>.Pool.Get(instructions);

            Label continueLabel = generator.DefineLabel();
            newInstructions[0].WithLabels(continueLabel);

            newInstructions.InsertRange(
                0,
                new[]
                {
                    new CodeInstruction(OpCodes.Ldarg_1), 
                    new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Player), nameof(Player.Get), new[] { typeof(ReferenceHub) })),
                    new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Scp999LookingAtScp096Patch), nameof(IsScp999))),
                    new CodeInstruction(OpCodes.Brfalse_S, continueLabel), 

                    new CodeInstruction(OpCodes.Ldc_I4_0), 
                    new CodeInstruction(OpCodes.Ret) 
                });

            foreach (var instruction in newInstructions)
            {
                yield return instruction;
            }

            ListPool<CodeInstruction>.Pool.Return(newInstructions);
        }
    }
}