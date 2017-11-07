using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old_Player_Follow_Mouse_Bullet : MonoBehaviour
{
    [SerializeField]
    private float Bullet_speed = 3f;
    private float TimeTillDeactiveateTimer = 0f;

    [SerializeField]
    private int damage = 1;


    void Update()
    {
      
        Vector2 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //hier laat ik de bullet bewegen richting de muis positie/de muis cursor
        this.transform.position = Vector2.Lerp(this.transform.position, cursorInWorldPos, Bullet_speed * Time.deltaTime);

        //  Debug.Log("DeactiveTimer = " + TimeTillDeactiveateTimer);

        if (TimeTillDeactiveateTimer >= 2.5f)
        {
            TimeTillDeactiveateTimer = 0f;
            Deactivate();
        }

        TimeTillDeactiveateTimer += Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name != "Player")
        {
            Deactivate();
           // Debug.Log("ik ga uit");
        }
        
    }


    private void Active()
    {
        this.gameObject.SetActive(true);
        
    }

    private void Deactivate()
    {
        TimeTillDeactiveateTimer = 0f;
        this.gameObject.SetActive(false);
    }


}
