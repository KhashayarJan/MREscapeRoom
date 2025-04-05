using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementValue;
    
    private float movementSpeed;
    
    public CharacterController controller;
        
    public void Move(InputAction.CallbackContext ctx)
    {
        movementValue = ctx.ReadValue<Vector2>();
        
        movementValue = transform.right * movementValue.x + transform.forward * movementValue.y;
        
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementValue = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move( Time.deltaTime * movementValue );
    }
}
