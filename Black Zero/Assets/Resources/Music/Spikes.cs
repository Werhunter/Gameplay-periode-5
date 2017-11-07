using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private float ActivateSpikesTimer = 0f;
    [SerializeField] private int damage = 1;

    void Update()
    {
        if (ActivateSpikesTimer <= 0)
        {
            //speel een Idle animatie waarin de spikes er nog niet zijn
        }

        if (ActivateSpikesTimer >= 2.5f)
        {
            //speel een animatie waarin de spikes een beetje omhoog gaan
        }

        if (ActivateSpikesTimer >= 5f)
        {
            //speel een animatie waarin de spikes helemaal omhoog gaan
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && ActivateSpikesTimer >= 5f)
        {
            col.GetComponent<Player_Health>().CurrentPlayerHealth -= damage;
            Destroy(this.gameObject);
        }
    }
}
