using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    [SerializeField] private float PunchTimerMax = 5f;
    private float PunchTimer = 0f;
    private float PunchSpeed = 7f;
    private Vector3 FistLocation;

    public bool IsHit = false;
    private float IsHitDeactivateTimer = 0f;
   

    void Update ()
    {
        Debug.Log("" + IsHit);

        FistLocation = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        if (PunchTimer >= PunchTimerMax)
        {
            //hier moet de fist naar beneden 
            FistLocation.x -= 1;
        }

        //try to punch with one hand and then the other
        //try and punch together
        if (IsHit == true)
        {
            Hit();
        }
	}

    public void Hit()
    {
        // Color_Shower.GetComponent<Renderer>().material.color = Custom_Color;
        if (IsHit == true)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
            IsHitDeactivateTimer += Time.deltaTime;
        }

        if (IsHitDeactivateTimer >= 1f)
        {
            IsHit = false;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            IsHitDeactivateTimer = 0f;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player_Bullet")
        {
            IsHit = true;
            col.gameObject.SetActive(false);
        }
    }

}
