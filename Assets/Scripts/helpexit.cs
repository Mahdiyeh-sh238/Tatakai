using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class helpexit : MonoBehaviour
{
   public void Exit()
	{
		Application.Quit();
	}
	public void help()
	{
		SceneManager.LoadScene("help");
	}
}
