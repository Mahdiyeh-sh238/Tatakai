using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public int Levelnumber;
    public bool Lock;
    public GameObject Star1,Star2,Star3;
	public GameObject Gm_Open, Gm_Lock;

    void Start()
    {
        CheckLevel ();
    }
  
   public void CheckLevel(){
		 
	/*	if (Levelnumber <= PlayerPrefs.GetInt ("MaxLevel") || PlayerPrefs.GetInt (NamBuy ) == 1) {
			Lock = false;
		} else if (Levelnumber > PlayerPrefs.GetInt ("MaxLevel") && PlayerPrefs.GetInt (NamBuy ) == 0){
			Lock = true;
		}*/

		if (Levelnumber <= PlayerPrefs.GetInt ("MaxLevel")){
				Lock = false;
		} else{
			Lock = true;
		}
		
		if (Lock) {
			Gm_Lock.SetActive (true);
			//Gm_Open.SetActive (false);
			//TxtShowPrice.text = PriceLevel.ToString ();

		} else {
			//Gm_Lock.SetActive (false);
			Gm_Open.SetActive (true);
		}

   }
		/*if (!Lock) {
			if (PlayerPrefs.GetInt (NamStar) > 0) {
				Star1.SetActive (true);
			}
			if (PlayerPrefs.GetInt (NamStar) > 1) {
				Star2.SetActive (true);
			} 
			if (PlayerPrefs.GetInt (NamStar) > 2) {
				Star3.SetActive (true);
			}

		}*/

        public void LoadLevel(){
		if (Lock) {
            print("lock");
			/*if (PriceLevel <= PlayerPrefs .GetInt ("Odlar")) {
				GameManager gm = FindObjectOfType <GameManager > ();
				gm.RefreshData (PriceLevel);
				PlayerPrefs.SetInt (NamBuy, 1);
				CheckLevel ();
			}else {
				print ("You Have not Odlar");
			}*/

		}else {
			SceneManager.LoadScene (Levelnumber);
		
		}
	}
}
