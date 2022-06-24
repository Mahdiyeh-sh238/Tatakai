using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Animator animator;
    private Vector3 rotation;
    private Rigidbody2D rb;
    private bool isgrounded = false;
    public Transform attackPoint;
    public LayerMask enemyLayers,BoxLayers;
    public float nextAttackTime=0f, attackRate=2f,attackRange=0.5f, jump=8, speed=5,direction;
    public GameObject thorn, Camera,Flag,grid,goldbox,Enemy,heart0,heart1,heart2,heart3,WinImage;
    public int LevelNumber,numberOfHit=0,lifeTime=3,attackDamage=40;
   // public Text goldtext;
    ScoreManager2 scoreManager;

    void Start()
    {
        LevelNumber=SceneManager.GetActiveScene().buildIndex;
        		scoreManager = FindObjectOfType <ScoreManager2> ();

        rb=GetComponent<Rigidbody2D>();
         animator = GetComponent<Animator>();
                 rotation = transform.eulerAngles;

        heart3.SetActive(true);
    }

    void Update()
    {
         Camera.transform.position=new Vector3(transform.position.x+7,0,-10);
         direction = Input.GetAxis("Horizontal");
         Running();
         Jumping();
         Falling();

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

    
     private void OnCollisionEnter2D(Collision2D collision) {

        if(collision.gameObject.tag== "enemy" && this.enabled==true)
        {
                animator.SetTrigger("hurt");
                FindObjectOfType<AudioManager>().Play("shortHit");
                numberOfHit++;
                //emtiaz
        }

        if(numberOfHit==1)
        {
            heart2.SetActive(true);
            heart3.SetActive(false);
            heart1.SetActive(false);
            heart0.SetActive(false);
        }
            

        if(numberOfHit==2)
        {
            heart2.SetActive(false);
            heart3.SetActive(false);
            heart1.SetActive(true);
            heart0.SetActive(false);
        }
            

        if(numberOfHit==3)
        {
            heart2.SetActive(false);
            heart3.SetActive(false);
            heart1.SetActive(false);
            heart0.SetActive(true);
            scoreManager.SaveCoin();
             scoreManager.ShowResult();
             if(PlayerPrefs.GetInt("MaxLevel")==LevelNumber)
            PlayerPrefs.SetInt("MaxLevel",PlayerPrefs.GetInt("MaxLevel")+1);
            //WinImage.SetActive(true);
            playerDeath();
            //showPanel();
        }
            
        if (collision.gameObject.tag == "ground") {
            isgrounded = true;
        }

        if (collision.gameObject.tag =="thorn") {
           /* scoreManager.ShowResult();
             if(PlayerPrefs.GetInt("MaxLevel")==LevelNumber)
            PlayerPrefs.SetInt("MaxLevel",PlayerPrefs.GetInt("MaxLevel")+1);*/
            playerDeath();

        }

         if(collision.gameObject.tag== "Flag")
         {
            scoreManager.ShowResult();
             if(PlayerPrefs.GetInt("MaxLevel")==LevelNumber)
            PlayerPrefs.SetInt("MaxLevel",PlayerPrefs.GetInt("MaxLevel")+1);
            WinImage.SetActive(true);
            //showPanel();
         }
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
     }

    private void showPanel()
    {
           // panel.SetActive(true);
           /* Destroy(gameObject);
            Destroy(Flag);
            Destroy(grid);
            Destroy(goldbox);
            Destroy(Enemy);*/
            WinImage.SetActive(true);

    }

    void playerDeath()
    {
            animator.SetBool("is Dead",true);
            FindObjectOfType<AudioManager>().Play("enemy-hit");
            GetComponent<Collider2D>().enabled=false;
            rb.gravityScale=0;
            this.enabled=false;
            Invoke("showPanel",2);
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
            scoreManager.SaveCoin();
        }
    }
     void Running()
        {
             if (direction != 0) {
                    animator.SetBool("IsRunning" , true);
                } else {
                    animator.SetBool("IsRunning" , false);
                }

                if (direction < 0) {
                           // Camera.transform.position=new Vector3(transform.position.x+7,0,-10);
                    transform.eulerAngles = rotation - new Vector3(0,180,0);
                    transform.Translate(Vector2.right * speed * -direction * Time.deltaTime);
                }
                if (direction > 0) {
                                              //  Camera.transform.position=new Vector3(transform.position.x+7,0,-10);

                    transform.eulerAngles = rotation;
                    transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
                }
        }
    
    void Jumping()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isgrounded) {
                    FindObjectOfType<AudioManager>().Play("jump");
                    rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                    isgrounded = false;
               }

            if (isgrounded == false) {
            animator.SetBool("IsJumping", true);
                                  
        } 
            else
            {
                animator.SetBool("IsJumping", false);
            }
        }

         void Falling()
        {
                if(rb.velocity.y<0 && isgrounded == false)
            {
                animator.SetBool("IsFalling",true);
            }else
                animator.SetBool("IsFalling",false);
          
        }
    void OnDrawGizmosSelected(){

         if(attackPoint==null)
             return;
         
         Gizmos.DrawSphere(attackPoint.position,attackRange);
     }
     
}
