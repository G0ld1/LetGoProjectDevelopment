using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController controller;
    private InputSystem_Actions inputActions; 

    public Transform playerMesh;

    public bool movementLocked = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        inputActions = new InputSystem_Actions();
        inputActions.Player.Enable();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void Update()
    {
        if (movementLocked)
            return;
        Vector2 moveInput = inputActions.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(-moveInput.y, 0, moveInput.x) * speed * Time.deltaTime;
        controller.Move(move);

     
        Vector3 moveDir = new Vector3(-moveInput.y, 0, moveInput.x);
        if (moveDir.sqrMagnitude > 0.01f)
        {
            playerMesh.rotation = Quaternion.LookRotation(moveDir, Vector3.up);
        }
    }
}
