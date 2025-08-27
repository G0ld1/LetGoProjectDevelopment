using UnityEngine;
using Unity.Cinemachine;

public class CameraLookAtTarget : MonoBehaviour
{
    public Transform targetToLookAt;
    public float maxLookAngle = 20f;
    public float smooth = 5f;

    private Quaternion defaultRotation;
    private bool following = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultRotation = transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (following && targetToLookAt != null)
        {
            // Calcula direção para o alvo no plano XZ
            Vector3 toTarget = targetToLookAt.position - transform.position;
            float angle = Mathf.Atan2(toTarget.x, toTarget.z) * Mathf.Rad2Deg;
            angle = Mathf.Clamp(angle, -maxLookAngle, maxLookAngle);

            Quaternion targetRot = defaultRotation * Quaternion.Euler(0, angle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * smooth);
        }
        else
        {
            // Volta à rotação original
            transform.rotation = Quaternion.Slerp(transform.rotation, defaultRotation, Time.deltaTime * smooth);
        }
    }

    public void StartFollowing(Transform target)
    {
        targetToLookAt = target;
        following = true;
    }

    public void StopFollowing()
    {
        following = false;
    }
}
