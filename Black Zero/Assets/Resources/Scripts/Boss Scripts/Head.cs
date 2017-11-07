using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private GameObject Body;
    [SerializeField] private GameObject Laser_Spawn_Location_1;
    [SerializeField] private GameObject Laser_Spawn_Location_2;
    [SerializeField] private GameObject Laser_Prefab;

    void Update ()
    {
        if (Body.GetComponent<Body>().IsHit == true)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (Body.GetComponent<Body>().IsHit == false)
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }

        //fire lasers from the eyes

        if (!Body.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
  
	}

}
