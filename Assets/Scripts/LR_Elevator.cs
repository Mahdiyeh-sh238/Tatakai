using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LR_Elevator : MonoBehaviour
{
    public GameObject LR_elevator;
     
    public float speed;
    void Update()
    {
          float x=Mathf.PingPong(Time.time*speed,1)*22;
         LR_elevator.transform.position=new Vector3(x+5,-1.5f,0);
    }
}
