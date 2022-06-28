using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGuideLevel : MonoBehaviour
{
    public GameObject G1,G2,G3,G4;
    void Start()
    {
        G1.SetActive(true);
    }

   public void picG1(){
       G1.SetActive(true);
       G2.SetActive(false);
       G3.SetActive(false);
       G4.SetActive(false);
   }
   public void picG2(){
       G1.SetActive(false);
       G2.SetActive(true);
       G3.SetActive(false);
       G4.SetActive(false);
   }
   public void picG3(){
       G1.SetActive(false);
       G2.SetActive(false);
       G3.SetActive(true);
       G4.SetActive(false);
   }
   public void picG4(){
       G1.SetActive(false);
       G2.SetActive(false);
       G3.SetActive(false);
       G4.SetActive(true);
   }
   public void goHome(){
		SceneManager.LoadScene("DisplayLevels");
   }
}
