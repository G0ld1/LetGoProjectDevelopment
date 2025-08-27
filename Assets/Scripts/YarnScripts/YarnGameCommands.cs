using UnityEngine;
using Yarn.Unity;

public class YarnGameCommands : MonoBehaviour
{
    [YarnCommand("switch_camera")]
    public static void SwitchCamera(string cameraName)
    {
        GameManager.Instance.SwitchCamera(cameraName);
    }



    [YarnCommand("lock_player")]
    public static void LockPlayer()
    {
        FindFirstObjectByType<GameManager>().LockPlayerMovement(true);
    }

    [YarnCommand("unlock_player")]
    public static void UnlockPlayer()
    {
        FindFirstObjectByType<GameManager>().LockPlayerMovement(false);
    }

   

    [YarnCommand("move_npc_to")]
    public static void MoveNPCTo(string npcName, float x, float y, float z)
    {
        var npc = GameObject.Find(npcName);
        if (npc == null) return;

        var mover = npc.GetComponent<NPCMover>();
        if (mover == null) return;

        mover.MoveTo(new Vector3(x, y, z));
    }

    [YarnCommand("camera_look_at")]
    public static void CameraLookAt(string targetName)
    {
        var target = GameObject.Find(targetName);
        if (target == null) return;

        var camFollow = FindFirstObjectByType<CameraLookAtTarget>();
        if (camFollow == null) return;

        camFollow.StartFollowing(target.transform);
    }

    [YarnCommand("camera_stop_look")]
    public static void CameraStopLook()
    {
        var camFollow = FindFirstObjectByType<CameraLookAtTarget>();
        if (camFollow == null) return;

        camFollow.StopFollowing();
    }
}


