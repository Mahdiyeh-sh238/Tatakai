using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager2 : MonoBehaviour
{
    public string num;
    public int Score=0,panelScore=0,myStar=0;
    public Text ScoreText,panelScoreText;
    public GameObject str1,str2,str3;
    public float MinScore;
    public float NormalScore;
    public float MaxScore;
    public string namStar;
    void Start()
    {
      //num = "Score" + SceneManager.GetActiveScene ().name;
      //Score=PlayerPrefs.GetInt(num,0);
      ScoreText.text=Score.ToString();
      namStar="Star"+SceneManager.GetActiveScene().name;

    }

    void Update()
    {
       // ScoreText.text=PlayerPrefs.GetInt("Score",0).ToString();
    }

     public void SaveCoin()
    {
        Score+=5;
        PlayerPrefs.SetInt(num,Score);
        ScoreText.text=Score.ToString();
    }
    public void ShowResult()
    {
        panelScoreText.text=Score.ToString();

        if(Score>=MinScore)
        {
            str1.SetActive(true);
            myStar+=1;
        }
        if(Score>=NormalScore)
        {
            str2.SetActive(true);
            myStar+=1;
        }
        if(Score>=MaxScore)
        {
            str3.SetActive(true);
            myStar+=1;
        }
        if(myStar>PlayerPrefs.GetInt(namStar))//15
        PlayerPrefs.SetInt(namStar,myStar);
        
    }
}
