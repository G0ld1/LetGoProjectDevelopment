using UnityEngine;

public class CameraSwitchTrigger : MonoBehaviour
{
    [SerializeField] public string cameraNameRight; 
    [SerializeField] public string cameraNameLeft;  

    private Vector3 lastPlayerPos;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

     
        // Guarda a posição do jogador ao entrar
        lastPlayerPos = other.transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Vector3 currentPos = other.transform.position;
        float delta = currentPos.z - lastPlayerPos.z;

        Debug.Log("Delta: " + delta);

        if (delta > 0.1f && !string.IsNullOrEmpty(cameraNameRight))
        {
            Debug.Log("A mudar para camara da direita");
            GameManager.Instance.SwitchCamera(cameraNameRight);
        }
        else if (delta < -0.1f && !string.IsNullOrEmpty(cameraNameLeft))
        {
            Debug.Log("A mudar para camara da esquerda");
            GameManager.Instance.SwitchCamera(cameraNameLeft);
        }
    }
}
