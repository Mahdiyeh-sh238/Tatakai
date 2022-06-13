using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public LayerMask BoxLayers;

    public int attackDamage=40;
    public float attackRate=2f;
    float nextAttackTime=0f;
    public GameObject Camera;
    public GameObject Flag;
    public GameObject panel;
    public GameObject grid;
    public GameObject goldbox;
    public int LevelNumber;
    ScoreManager sc;



    void Start()
    {
        LevelNumber=SceneManager.GetActiveScene().buildIndex;
        		sc = FindObjectOfType <ScoreManager > ();

        rb=GetComponent<Rigidbody2D>();
         animator = GetComponent<Animator>();
                 rotation = transform.eulerAngles;
    }

    void Update()
    {
        Camera.transform.position=new Vector3(transform.position.x,0,-10);
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

        if(rb.velocity.y<0 && isgrounded == false)
        {
            animator.SetBool("IsFalling",true);
        }else
        animator.SetBool("IsFalling",false);


        if (Input.GetKeyDown(KeyCode.Space) && isgrounded) {
                    FindObjectOfType<AudioManager>().Play("jump");
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
        
         if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                 Attack2();
                 nextAttackTime= Time.time+1f/attackRate;
            }
        }
        
    }

    void Attack2()
    {
        animator.SetTrigger("Attack2");

        // Detect enemies in range of attack
        Collider2D[]hitEnemies=Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        FindObjectOfType<AudioManager>().Play("shortWind");

        // Damage theme
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemey>().TakeDamage(attackDamage);
            FindObjectOfType<AudioManager>().Play("sword");
        }
    }

    void Attack()
    {
         animator.SetTrigger("Attack");

        // Detect enemies in range of attack
        Collider2D[]hitBox=Physics2D.OverlapCircleAll(attackPoint.position,attackRange,BoxLayers);
        FindObjectOfType<AudioManager>().Play("shortWind");

        // Damage theme
        foreach(Collider2D goldBox in hitBox)
        {
            goldBox.GetComponent<GoldBox>().Open();
             FindObjectOfType<AudioManager>().Play("wooden-box");
        }
    }

     private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "ground") {
            isgrounded = true;
        }

       if (collision.gameObject.tag =="GoldBox") {
           sc.SaveCoin();
            
            // emtiaz
          //  FindObjectOfType<AudioManager>().Play("Coin");

        }

         if(collision.gameObject.tag== "Flag")
         {
             sc.SaveRecord();
             if(PlayerPrefs.GetInt("MaxLevel")==LevelNumber)
            PlayerPrefs.SetInt("MaxLevel",PlayerPrefs.GetInt("MaxLevel")+1);
            panel.SetActive(true);
            Destroy(gameObject);
            Destroy(Flag);
            Destroy(grid);
            Destroy(goldbox);
         }
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
     }

     void OnDrawGizmosSelected(){

         if(attackPoint==null)
             return;
         
         Gizmos.DrawSphere(attackPoint.position,attackRange);
     }
     
}
