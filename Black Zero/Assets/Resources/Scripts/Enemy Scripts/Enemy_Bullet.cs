using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    [SerializeField] private float Bullet_speed = 2f;
    [SerializeField] private int damage = 1;
    private float DeathTimer = 0f;
    public Vector2 direction;

    [SerializeField] private bool DeathTimerOFForON = false;

    void Update()
    {
        transform.position += new Vector3(direction.x,direction.y,0).normalized * Bullet_speed * Time.deltaTime;

       /*
        * PAK DIRECTION (FLOAT DIR = POS1 - POS2)
        * CAST DE BULLET (GameObject (dis de cast name...)newBullet = instantiate)
        * Geef direction mee, newbullet.getcomponent<script>().direction = DIR;
        * in bullet. transform.position += new vector3(direction.x,direction.y,0).NORMALIZED;
        * NORMALIZED omdat je dan waardes tussen 0-1 krijgt;
        * dan keer speed en time.deltatime
        * end result;
        * transform.position += new vector3(direction.x,direction.y,0).NORMALIZED * speed * time.deltatime
        * nu schiet een bullet en gaat die richting de plek waar de player stond;
        */

        if (this.gameObject != null)
        {
            if (DeathTimerOFForON == false)
            {
                DeathTimer++;
            }        
        }

        if (DeathTimer >= 125f)
        {
            Deactivate();
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.GetComponent<Player_Health>().CurrentPlayerHealth -= damage;
            Deactivate();
        }

        if (col.gameObject.tag == "Player_Bullet" || col.gameObject.tag == "Environment")
        {
            Deactivate();
        }

        //if (col.gameObject.tag != "Player")
        //{
        //    Destroy(this.gameObject);
        //}

    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

}
