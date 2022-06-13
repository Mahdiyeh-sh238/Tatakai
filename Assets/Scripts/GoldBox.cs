using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBox : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

      public void Open()
    {
       animator.SetBool("IsOpen" , true);
        FindObjectOfType<AudioManager>().Play("get-coin");
        GetComponent<Collider2D>().enabled=false;
        this.enabled=false; 

    }

     /* private void OnCollisionEnter2D(Collision2D collision) {

                if (collision.gameObject.tag == "Player") {
                    animator.SetBool("IsOpen" , true);
                    FindObjectOfType<AudioManager>().Play("get-coin");
                    GetComponent<Collider2D>().enabled=false;
                    this.enabled=false;  
                     }
          }*/
        
}
