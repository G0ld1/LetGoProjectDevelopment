using UnityEngine;
using Unity.Cinemachine;

[RequireComponent(typeof(CinemachineCamera))]
public class CinemachineEdgeLook : MonoBehaviour
{
    public Transform player;
    public float lookRange = 3f;   // Distância máxima do centro antes de começar a olhar
    public float maxLookAngle = 10f; // Máximo de graus para rodar para cada lado
    public float smooth = 5f;

    private Quaternion defaultRotation;

    void Start()
    {
        defaultRotation = transform.rotation;
    }

    void LateUpdate()
    {
        if (player == null)
            return;

        // Calcula a diferença no eixo X entre jogador e câmara
        float dx = player.position.z - transform.position.z;
        float t = Mathf.Clamp(dx, -lookRange, lookRange) / lookRange;
        float targetAngle = t * maxLookAngle;

        // Rotação apenas no eixo Y (olhar para a esquerda/direita)
        Quaternion targetRot = defaultRotation * Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * smooth);
    }
}
