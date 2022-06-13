using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemey : MonoBehaviour
{
    public Animator animator;
    public int maxHealth=100;
    int currentHealth;
     public float speed = 3f;
    public float velocity;
    public float links;
    private Vector3 rotation;
    void Start()
    {
        currentHealth=maxHealth;
        velocity = transform.position.x + velocity;
        links = transform.position.x - links;
        animator.SetBool("IsRunning" , true);
            

    }

      void Update()
    {
        
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < links) {
            transform.eulerAngles = rotation - new Vector3(0,180,0);
        }

        if (transform.position.x > velocity) {
            transform.eulerAngles = rotation ;

        }

    }
    public void TakeDamage(int damage)
    {
        currentHealth -=damage;

        animator.SetTrigger("Hurt");
        transform.Translate(Vector3.left * 0 * Time.deltaTime);


        if(currentHealth<=0)
        {
            Die();
        }

    }

    void Die(){
       // Debug.Log("Enemy died!");
        animator.SetBool("IsDead",true);
        FindObjectOfType<AudioManager>().Play("enemy-hit");
        // Disable enemy
        GetComponent<Collider2D>().enabled=false;
        this.enabled=false;

    }

}
