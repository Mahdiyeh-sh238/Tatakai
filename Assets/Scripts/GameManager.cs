using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //public static string[] Names;
    void Awake()
    {
        //PlayerPrefs.SetInt("MaxLevel",1);
        if (PlayerPrefs.GetInt ("MaxLevel") == 0)
        {
          PlayerPrefs.SetInt ("MaxLevel", 1);
        }

     }
}
