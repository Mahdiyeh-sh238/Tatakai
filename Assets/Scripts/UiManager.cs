using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
   
	public void LoadLevel(int Number){
		SceneManager.LoadScene (Number);
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene (  SceneManager.GetActiveScene ().buildIndex + 1);
		 
	}

	public void Reset(){
		SceneManager.LoadScene ( SceneManager.GetActiveScene ().buildIndex );
	}

}
