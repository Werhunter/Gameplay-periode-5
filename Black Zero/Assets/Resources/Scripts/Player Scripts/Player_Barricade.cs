using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Barricade : MonoBehaviour
{
    private float DeactiveateTimer = 0f;

    void Update ()
    {
        DeactiveateTimer += Time.deltaTime;

        if (DeactiveateTimer >= 5f)
        {
            Deactivate();
        }

	}

    private void Deactivate()
    {
        DeactiveateTimer = 0f;
        this.gameObject.SetActive(false);
    }
}
