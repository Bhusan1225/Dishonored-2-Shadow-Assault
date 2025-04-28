
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Character Info")]
    public float movingSpeed;
    public float runningSpeed;
    public float currentMovingSpeed;
    public float turningSpeed = 300f;
    public float stopSpeed = 1f;


    [Header("Destination var")]
    public Vector3 destination;
    public bool destinationReached;


    [Header("EnemyAI")]
    public GameObject playerBody;
    public LayerMask playerLayer;
    public float visionRadious;
    public bool playerInvisionRadius;


    [Header("Player detect")]
    [SerializeField] float visionRadius;
    [SerializeField] bool isPlayerinVisionRadius;
    [SerializeField] float attackRadius;
    [SerializeField] float speed = 4f;

    [Header("Attack on Player")]
    [SerializeField] int attackVal;
    [SerializeField] float giveDamage;
    [SerializeField] float timeBtwAttack;
    [SerializeField] bool previouslyAttack;

    [Header("Attack Areas")]
    [SerializeField] float attackingRadius;
    [SerializeField] Transform attackArea;
    [SerializeField] bool isPlayerinAttackRadius;
   
    [SerializeField] Collider[] hitPlayer;
    [SerializeField] PlayerHealth playerHealth;


    [Header("Alive/Dead")]
    [SerializeField] bool isEnemyDead;

    [SerializeField] Animator animator;
    private void Start()
    {
        currentMovingSpeed = movingSpeed;
        
    }


    public bool setEnemyDeath(bool _isEnemyDeath)
    {
        return isEnemyDead = _isEnemyDeath;
    }
    private void Update()
    {
        playerInvisionRadius = Physics.CheckSphere(transform.position, visionRadious, playerLayer);
        isPlayerinAttackRadius = Physics.CheckSphere(transform.position, attackRadius, playerLayer);
        if (!isPlayerinVisionRadius && !isPlayerinAttackRadius && !isEnemyDead)
        {
            Walk();
        }
        if (playerInvisionRadius == true && !isPlayerinAttackRadius  && !isEnemyDead)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Run", true);
            chasePlayer();
        }

        if (playerInvisionRadius == true && isPlayerinAttackRadius == true && !isEnemyDead)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
            AttackModes();
        }

        //if (isEnemyDead == true)
        //{
        //    Debug.Log(" the enemy is dead");
        //    animator.SetTrigger("Dead");
        //    animator.SetBool("Run", false);
        //    animator.SetBool("Idle", false);
            
            
        //}
    }
    private void AttackModes()
    {
        if (!previouslyAttack)
        {

            attackVal = Random.Range(1, 3);

            if (attackVal == 1)
            {
                StartCoroutine(Attack1());
                Attack();

            }
            else if (attackVal == 2)
            {

                StartCoroutine(Attack2());
                Attack();
            }
           

        }
    }
    void Attack()
    {
        Debug.Log("Player hit by Elder Goblin");
        hitPlayer = Physics.OverlapSphere(attackArea.position, attackingRadius, playerLayer);
        foreach (Collider hit in hitPlayer)
        {
            PlayerHealth playerHealth = hit.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                Debug.Log("Player hit by Elder Goblin");
                playerHealth.TakeDamage(0.08f);
            }
        }

        previouslyAttack = true;
        Invoke(nameof(ActiveAttack), timeBtwAttack);
    }

    private void ActiveAttack()
    {
        previouslyAttack = false;
    }


    IEnumerator Attack1()
    {
        animator.SetBool("Attack1", true);
        currentMovingSpeed = 0f;
        yield return new WaitForSeconds(3f);
        animator.SetBool("Attack1", false);
        currentMovingSpeed = 2f;
    }


    IEnumerator Attack2()
    {
        animator.SetBool("Attack2", true);
        currentMovingSpeed = 0f;
        yield return new WaitForSeconds(3f);
        animator.SetBool("Attack2", false);
        currentMovingSpeed = 2f;
    }



   

    private void chasePlayer()
    {
        currentMovingSpeed = runningSpeed;
        transform.position += transform.forward * currentMovingSpeed * Time.deltaTime;
        transform.LookAt(playerBody.transform);
    }

    public void Walk()
    {
        currentMovingSpeed = movingSpeed;
        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= stopSpeed)
            {
                destinationReached = false;
                Quaternion targetRotaion = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotaion, turningSpeed * Time.deltaTime);

                //Moving AI
                transform.Translate(Vector3.forward * currentMovingSpeed * Time.deltaTime);
            }
            else
            {
                destinationReached = true;
            }
        }
    }

    public void LocateDestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
    }

    private void OnDrawGizmosSelected()
    {

        if (attackArea == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackArea.position, attackingRadius);
    }
}
