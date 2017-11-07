using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling_System : MonoBehaviour
{

    public int MaxObjectsForPool = 30;

    private GameObject[] Pool;

    [SerializeField]
    private GameObject Pool_Object;


    void OnEnable()
    {
        Pool = new GameObject[MaxObjectsForPool];

        for (int i = 0; i < MaxObjectsForPool; i++)
        {
            Pool[i] = Instantiate(Pool_Object);
            Pool[i].SetActive(false);
        }

    }


    public GameObject[] GetBulletPool
    {

        get { return (Pool); }
        set { Pool = value; }

    }


}
