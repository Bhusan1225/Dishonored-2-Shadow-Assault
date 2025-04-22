using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    AnimationManager animationManager;

    public Vector2 movementInput;
    private float moveAmout;
    public float verticalInput;
    public float horizontalInput;

    private void OnEnable()
    {
        if (playerControls == null) 
        { 
            playerControls  = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        
        }
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Awake()
    {
        animationManager = GetComponent<AnimationManager>();    
    }
    public void HandleAllInput()
    {
        HandleMovementInputs();
    }
    private void HandleMovementInputs()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmout = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
      
         animationManager.UpdateAnimationValue(0, moveAmout);
    }
}


