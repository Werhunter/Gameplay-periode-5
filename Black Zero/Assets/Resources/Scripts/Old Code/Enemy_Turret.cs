using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Turret : MonoBehaviour
{
    [SerializeField] private GameObject Enemy_Bullets;
    [SerializeField] private float ShootTimer = 0f;
    [SerializeField] private GameObject Player;
    private Vector2 rotation_angle;

    void Update ()
    {
        ShootTimer += Time.deltaTime;
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

        if (ShootTimer >= 1f)
        {
            rotation_angle = Player.transform.position - transform.position;
            GameObject bullet = Instantiate(Enemy_Bullets, this.transform.position, Quaternion.Euler(rotation_angle));
            bullet.GetComponent<Enemy_Bullet>().direction = rotation_angle;
            ShootTimer = 0f;
         
        }

      
	}
}
