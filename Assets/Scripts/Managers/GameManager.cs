using UnityEngine;
using Unity.Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }



    public void SwitchCamera(string cameraName)
    {
        var allVCams = FindObjectsByType<CinemachineCamera>(FindObjectsSortMode.None);
        foreach (var vcam in allVCams)
        {
            if (vcam.name == cameraName)
                vcam.Priority = 10; // Ativa esta
            else
                vcam.Priority = 0;  // Desativa as outras
        }
    }

    public void MoveNPC(string npcName, Vector3 position)
    {
        var npc = GameObject.Find(npcName);
        if (npc != null)
            npc.transform.position = position;
    }


}
