using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Fire_Direction : MonoBehaviour
{
    [SerializeField] private GameObject Target; //player anderen vijanden etc...
    [SerializeField] private float Target_Speed;
    private Vector2 direction;



    void Update ()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, Target.transform.position, Target_Speed * Time.deltaTime);
    }


    public void GetTargetDirection()
    {      
        this.transform.position = direction;
    }
}
