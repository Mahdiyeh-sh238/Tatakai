using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public string nam,nam2;
	//public string NamStar;
	public float ScoreInTime;
    public int Score=0;
    	public Text TxtScore,TxtRecord,score;

    void Start()
    {
        		nam = "Score" + SceneManager.GetActiveScene ().name;
                nam2 = "Coin" + SceneManager.GetActiveScene ().name;

                    }

    // Update is called once per frame
    void Update()
    {
        		ScoreInTime += 1 * Time.deltaTime;

    }

    public void SaveRecord()
    {
        if(ScoreInTime < PlayerPrefs.GetFloat(nam)|| PlayerPrefs.GetFloat (nam) == 0)
            PlayerPrefs.SetFloat(nam,ScoreInTime);

            TxtScore.text = ScoreInTime.ToString ();
            TxtRecord.text = PlayerPrefs.GetFloat (nam).ToString();

            print (PlayerPrefs.GetInt (nam));
    }

    public void SaveCoin()
    {
        Score+=5;
        PlayerPrefs.SetInt(nam2,Score);
        score.text=Score.ToString();
    }
}
