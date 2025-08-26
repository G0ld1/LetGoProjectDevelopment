using UnityEngine;
using Yarn.Unity;

public class YarnGameCommands : MonoBehaviour
{
   


    [YarnCommand("switch_camera")]
    public static void SwitchCamera(string cameraName)
    {
        GameManager.Instance.SwitchCamera(cameraName);
    }

    [YarnCommand("move_npc")]
    public static void MoveNPC(string npcName, float x, float y, float z)
    {
        GameManager.Instance.MoveNPC(npcName, new Vector3(x, y, z));
    }

   
}
