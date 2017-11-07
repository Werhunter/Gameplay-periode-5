using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //[SerializeField] private float moveSpeed;
    //private Rigidbody rbody;

    private float counter;
    [SerializeField] private float reloadSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject player_follow_mouse_bullet;

    private int BulletSwitch = 0;
    private Vector3 follow_mouse_bullet_position;

    [SerializeField] private Transform Player_Bullet_Spawn_Location_1;
    [SerializeField] private GameObject Player_Gun;
    [SerializeField] private GameObject Player_Barricade_Prefab;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
       // Debug.Log("time = " + Time.timeScale);


        if (counter == 0f)
        {
            if (Input.GetMouseButton(0))
            {
                if (BulletSwitch == 0)
                {
                    Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    targetPosition.y = 0f;
                    Vector3 originPosition = transform.position;
                    originPosition.y = 0f;
                    Vector3 direction = targetPosition - originPosition;
                    direction.Normalize();
                    GameObject newBullet = Instantiate<GameObject>(bulletPrefab, transform.position, Quaternion.identity);
                    newBullet.GetComponent<Normal_Player_Bullet>().Initialize(direction);
                    counter = reloadSpeed;
                    animator.SetTrigger("fire");
                }
            }

            if (Input.GetMouseButton(0))
            {
                if (BulletSwitch == 1)
                {
                    Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    targetPosition.y = 0f;
                    //GameObject newBullet = Instantiate<GameObject>(follow_mouse_bullet, transform.position, Quaternion.identity);
                    player_follow_mouse_bullet.SetActive(true);
                  //  newBullet.GetComponent<Player_Follow_Mouse_Bullet>().Initialize();
                    counter = reloadSpeed;
                    animator.SetTrigger("fire");
                }
            }
        }
        else
        {
            counter = Mathf.Clamp(counter - Time.deltaTime, 0f, reloadSpeed);
        }

        if (player_follow_mouse_bullet != null)
        {
            follow_mouse_bullet_position = player_follow_mouse_bullet.transform.position;
        }

        #region BulletSwitch

        if (Input.GetKeyDown(KeyCode.E))
        {
            BulletSwitch += 1;

            if (BulletSwitch != 1)
            {
                player_follow_mouse_bullet.SetActive(false);
                Time.timeScale = 1;
            }
        }

        //dit zorgt er voor dat de bullet switch niet -1 kan zijn
        if (BulletSwitch < 0)
        {
            BulletSwitch = 0;
        }

        //door de code boven en onder kan de bullet switch dus alleen 0 en 1 zijn en als ik meer nodig heb dan moet ik
        //de code van onder aanpassen door er een bij te doen

        //dit zorgt er voor dat de bullet switch weer terug gaat naar het begin
        if (BulletSwitch > 1)
        {
            BulletSwitch = 0;
        }

        //Debug.Log("Bullet Switch = " + BulletSwitch);

        #endregion

        if (BulletSwitch == 1)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Teleport();
            }



            if (Input.GetMouseButton(2))
            {
                CreateBarricade();
            }
        }
        

    }

    #region Teleport + Baricade




    private void Teleport()
    {
        if (player_follow_mouse_bullet != null)
        {
           this.gameObject.transform.position = follow_mouse_bullet_position;
           player_follow_mouse_bullet.SetActive(false);
            Time.timeScale = 1;
        }

    }

    private void CreateBarricade()
    {
        if (player_follow_mouse_bullet != null)
        {
           Player_Barricade_Prefab.transform.position = follow_mouse_bullet_position;
           Player_Barricade_Prefab.SetActive(true);
           player_follow_mouse_bullet.SetActive(false);   
        }
    }

    #endregion
}