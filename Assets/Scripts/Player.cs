using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator animator;
    private Vector3 rotation;
    public float speed=5;
    private Rigidbody2D rb;
    public float jump=8;
    private bool isgrounded = false;
    public Transform attackPoint;
    public float attackRange=0.5f;
    public LayerMask enemyLayers;
    public int attackDamage=40;
    public float attackRate=2f;
    float nextAttackTime=0f;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
         animator = GetComponent<Animator>();
                 rotation = transform.eulerAngles;
    }

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        if (direction != 0) {
                    animator.SetBool("IsRunning" , true);
                } else {
                    animator.SetBool("IsRunning" , false);
                }

                if (direction < 0) {
                    transform.eulerAngles = rotation - new Vector3(0,180,0);
                    transform.Translate(Vector2.right * speed * -direction * Time.deltaTime);
                }
                if (direction > 0) {
                    transform.eulerAngles = rotation;
                    transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
                }

         if (isgrounded == false) {
            animator.SetBool("IsJumping", true);
                                  
        } else {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded) {
                   // PlayJumpSound();
                   // FindObjectOfType<AudioManager>().Play("jump");
                    rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                    isgrounded = false;
               }

        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                 Attack();
                 nextAttackTime= Time.time+1f/attackRate;
            }
        }
        
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        // Detect enemies in range of attack
        Collider2D[]hitEnemies=Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);

        // Damage theme
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemey>().TakeDamage(attackDamage);
        }
    }

     private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "ground") {
            isgrounded = true;
        }
     }

     void OnDrawGizmosSelected(){

         if(attackPoint==null)
             return;
         
         Gizmos.DrawSphere(attackPoint.position,attackRange);
     }
}
