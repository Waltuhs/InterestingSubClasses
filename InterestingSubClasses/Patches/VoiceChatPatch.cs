using HarmonyLib;
using PlayerRoles.Voice;
using PlayerRoles;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using VoiceChat.Networking;
using VoiceChat;
using Exiled.API.Features;

namespace InterestingSubClasses.Patches
{
    [HarmonyPatch(typeof(VoiceTransceiver), nameof(VoiceTransceiver.ServerReceiveMessage))]
    public static class VoiceChatPatch
    {
        private static VoiceChatChannel SCP999HearSCPS(VoiceChatChannel channel, ReferenceHub speaker, ReferenceHub listener)
        {
            if (Plugin.Instance.customRoles.TryGetValue(Player.Get(listener), out string role) && role == $"{Plugin.Instance.Translation.SCP999RoleName}" && speaker.IsSCP())
            {
                return VoiceChatChannel.ScpChat;
            }
            return channel;
        }

        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var newInstructions = new List<CodeInstruction>(instructions);
            var method = AccessTools.Method(typeof(VoiceModuleBase), nameof(VoiceModuleBase.ValidateReceive));

            int index = newInstructions.FindIndex(instruction =>
                instruction.opcode == OpCodes.Callvirt && (MethodInfo)instruction.operand == method);

            if (index != -1)
            {
                index += 1;

                newInstructions.InsertRange(index, new[]
                {
                    new CodeInstruction(OpCodes.Ldarg_1),
                    new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(VoiceMessage), nameof(VoiceMessage.Speaker))), 
                    new CodeInstruction(OpCodes.Ldloc_3),
                    new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(VoiceChatPatch), nameof(SCP999HearSCPS))) 
                });
            }
            return newInstructions;
        }
    }
}
