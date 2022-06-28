using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UD_Elevator : MonoBehaviour
{
         public GameObject UD_elevator;
         public float speed;
         public float leftDistance;

    // Update is called once per frame
    void Update()
    {
         float y=Mathf.PingPong(Time.time*speed,1)*6-3;
         UD_elevator.transform.position=new Vector3(leftDistance,y,0);
    }
}
