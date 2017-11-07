using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int Health = 1;

    void Update()
    {

        if (Health <= 0)
        {
            Deactivate();
        }

    }


    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

}
