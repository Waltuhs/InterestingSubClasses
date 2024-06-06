using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Exiled.API.Features;
using HarmonyLib;
using PlayerRoles;
using PlayerRoles.PlayableScps.Scp173;
using ExiledEvents = Exiled.Events.Events;

namespace InterestingSubClasses.Patches
{
    [HarmonyPatch(typeof(Scp173ObserversTracker), nameof(Scp173ObserversTracker.UpdateObserver))]
    public static class Scp999lookingAtScp173Patch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            List<CodeInstruction> newInstructions = new List<CodeInstruction>(instructions);

            Label continueLabel = generator.DefineLabel();
            Label skipLabel = generator.DefineLabel();

            MethodInfo helpMethod = typeof(Scp999lookingAtScp173Patch).GetMethod(nameof(HelpMePlease), BindingFlags.Static | BindingFlags.NonPublic);
            FieldInfo observersField = typeof(Scp173ObserversTracker).GetField("Observers", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo removeMethod = typeof(HashSet<ReferenceHub>).GetMethod(nameof(HashSet<ReferenceHub>.Remove));

            newInstructions.InsertRange(0, new CodeInstruction[]
            {
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldarg_1),
                new CodeInstruction(OpCodes.Call, helpMethod),

                new CodeInstruction(OpCodes.Brfalse_S, continueLabel),

                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldfld, observersField),
                new CodeInstruction(OpCodes.Ldarg_1),
                new CodeInstruction(OpCodes.Callvirt, removeMethod),
                new CodeInstruction(OpCodes.Brtrue_S, skipLabel),

                new CodeInstruction(OpCodes.Ldc_I4_0),
                new CodeInstruction(OpCodes.Ret),

                new CodeInstruction(OpCodes.Ldc_I4_M1).WithLabels(skipLabel),
                new CodeInstruction(OpCodes.Ret),

                new CodeInstruction(OpCodes.Nop).WithLabels(continueLabel),
            });

            foreach (var instruction in newInstructions)
            {
                yield return instruction;
            }
        }

        private static bool HelpMePlease(Scp173ObserversTracker instance, ReferenceHub targetHub)
        {
            var player = Player.Get(targetHub);
            return player != null &&
                   Plugin.Instance.customRoles.TryGetValue(player, out string role) &&
                   role == Plugin.Instance.Translation.SCP999RoleName &&
                   instance.IsObservedBy(targetHub, Scp173ObserversTracker.WidthMultiplier);
        }
    }
}
