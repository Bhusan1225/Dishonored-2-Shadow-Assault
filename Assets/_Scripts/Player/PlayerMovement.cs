using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    float speed;
    public float runningSpeed;
    public float rotationSpeed = 600f;
    public Quaternion requiredRotaion;
    public CameraController cameraController;
    Vector3 playerMoveDirection;
    Vector3 cameraMoveDirection;

    [Header("Animation")]
    public Animator animator;
    public bool isRunning;


    [Header("Player Collision & Gravity")]
    public CharacterController controller; //collision
    
    float surfaceCheckRadius = 0.1f;
    public Vector3 surfaceCheckOffset;
    public LayerMask surfaceLayer;
    bool onSurface;
    float fallingSpeed;


    bool isGhostmode;
    // Update is called once per frame
    void Update()
    {
        if (onSurface)
        {
            fallingSpeed = 0;
        }
        else
        {
            fallingSpeed += Physics.gravity.y * Time.deltaTime;
        }
        var velocity = playerMoveDirection * speed;
        velocity.y = fallingSpeed;

        PlayerLocomotion();
        SurfaceCheck();
        //Debug.Log("Player on Surface" + onSurface);

        Animation();
    }
    void SurfaceCheck()
    {
        onSurface = Physics.CheckSphere(transform.TransformPoint(surfaceCheckOffset), surfaceCheckRadius, surfaceLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.TransformPoint(surfaceCheckOffset), surfaceCheckRadius);
    }

    void PlayerLocomotion()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");


        float movement = Mathf.Clamp01(Mathf.Abs(moveX) + Mathf.Abs(moveZ));

        playerMoveDirection = new Vector3(moveX, 0, moveZ).normalized;

        cameraMoveDirection = cameraController.flatRotaion * playerMoveDirection;

        if (movement > 0)
        {
            //transform.position += cameraMoveDirection * speed * Time.deltaTime;
            controller.Move(cameraMoveDirection * speed * Time.deltaTime); 
            //rb.velocity = cameraMoveDirection * speed;
            requiredRotaion = Quaternion.LookRotation(cameraMoveDirection);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, requiredRotaion, rotationSpeed * Time.deltaTime);
        animator.SetFloat("move", movement);



        if (Input.GetKey(KeyCode.LeftShift))
        {
                speed = runningSpeed;
                animator.SetBool("isRunning", true);
        }
        else
        {
                speed = 3f; // reset speed
                animator.SetBool("isRunning", false);
        }

    }

    void Animation()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isGhostmode = !isGhostmode;
            if (isGhostmode)
            {
                animator.SetBool("isCrawling", true);
            }
            else
            {

                animator.SetBool("isCrawling", false);
            }
        }


    }

}

