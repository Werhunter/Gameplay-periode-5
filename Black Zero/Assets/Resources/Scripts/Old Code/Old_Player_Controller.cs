using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Playerstate
{
    idle = 0,
    standing_and_gunning = 1,
    running_and_gunning = 2 
};


public class Old_Player_Controller : MonoBehaviour
{
    [SerializeField] private Playerstate state;
    [SerializeField] private GameObject MuzzleFlashAnimation;

    //[SerializeField] private float speed = 2f;
    //private Vector3 movement;

    [SerializeField] private Transform Player_Bullet_Spawn_Location_1;
    [SerializeField] private GameObject Player_Gun;
    [SerializeField] private GameObject Player_Barricade_Prefab;


    [SerializeField] private GameObject FollowMouseBulletPoolingSystem;
    [SerializeField] private GameObject NormalBulletPoolingSystem;
    private GameObject[] FollowMouseBulletPool;
    private GameObject[] NormalBulletPool;


    private int MaxFollowMouseBullets = 30;
    private int MaxNormalBullets = 30;
    private int BulletSwitch = 0;

    private GameObject follow_mouse_bullet;
    private Vector2 follow_mouse_bullet_position;

    private Animator animator;

    private bool Ismoving { get { return Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0; } }
    //als horizontal of vertical niet 0 is dan is ismoving true zo wel dan is ie false (0 = idle) (!0 = moving shooting etc...)

    private void Start()
    {
        animator = GetComponent<Animator>();
        FollowMouseBulletPool = new GameObject[MaxFollowMouseBullets];
        FollowMouseBulletPool = FollowMouseBulletPoolingSystem.GetComponent<Pooling_System>().GetBulletPool;
        NormalBulletPool = new GameObject[MaxNormalBullets];
        NormalBulletPool = NormalBulletPoolingSystem.GetComponent<Pooling_System>().GetBulletPool;
    }

    void Update ()
    {

        if (Ismoving == true)
        {
            state = Playerstate.running_and_gunning; //todat ik een beteren run animation heb is dit de run animation
        }
        else if (Ismoving == false)
        {
            state = Playerstate.idle;
        }

        #region Movement

        //float moveHorizontal = Input.GetAxisRaw("Horizontal");
        //float moveVertical = Input.GetAxisRaw("Vertical");

        //movement = new Vector3(moveHorizontal, moveVertical, 0f);

        //movement = movement * speed * Time.deltaTime;

        //transform.position += movement;

       

        #endregion

        if (follow_mouse_bullet != null)
        {
            follow_mouse_bullet_position = follow_mouse_bullet.transform.position;
        }

        #region BulletSwitch

        if (Input.GetKeyDown(KeyCode.E))
        {
            BulletSwitch += 1;

            if (BulletSwitch != 1)
            {
                follow_mouse_bullet.SetActive(false);
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



        if (Input.GetMouseButton(0)) 
        {
            if (BulletSwitch == 0)
            { 
                if (Ismoving == true)
                {
                    ShootNormalBullets();
                    state = Playerstate.running_and_gunning;
                    MuzzleFlashAnimation.SetActive(true);
                }
                else if (Ismoving == false)
                {
                    ShootNormalBullets();
                    state = Playerstate.standing_and_gunning;
                    MuzzleFlashAnimation.SetActive(true);
                }
            }

        }

        if (Input.GetMouseButtonUp(0))
        {

            if (BulletSwitch == 1)
            {
                ShootFollowMouseBullets();
            }
        }

        //nadat de player heeft geschoten zet ik hier de muzzleflash uit
        //en voor de zekerheid zet ik de players animatie op idle
        if (Input.GetMouseButtonUp(0)) 
        {
            state = Playerstate.idle;
            MuzzleFlashAnimation.SetActive(false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Teleport();
        }

        if (Input.GetMouseButton(2))
        {
            CreateBarricade();
        }

        animator.SetInteger("State", (int)state);
	}


#region ShootFuncties + teleport

    private void ShootFollowMouseBullets()
    {

        for (int i = 0; i < FollowMouseBulletPool.Length; i++)
        {
            if (FollowMouseBulletPool[i] != null)
            {
                if (!FollowMouseBulletPool[i].activeSelf)
                {
                    
                    FollowMouseBulletPool[i].SetActive(true);

                    follow_mouse_bullet = FollowMouseBulletPool[i];
                    
                    //dit reset de bullets positie terug naar de players geweer
                    FollowMouseBulletPool[i].transform.position = new Vector2(Player_Bullet_Spawn_Location_1.transform.position.x, Player_Bullet_Spawn_Location_1.transform.position.y /*,Player_Bullet_Spawn_Location_1.transform.position.z*/);
                    break;
                }
            }
        }
        
    }


    private void ShootNormalBullets()
    {

        for (int i = 0; i < NormalBulletPool.Length; i++)
        {
            if (NormalBulletPool[i] != null)
            {
                if (!NormalBulletPool[i].activeSelf)
                {
                    {

                        NormalBulletPool[i].SetActive(true);

                        //dit reset de bullets positie terug naar de players geweer en geeft dan de directie van de mousecursor zodat de bullet weet waar hij heen moet gaan
                        Vector3 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        Vector3 direction = (cursorInWorldPos - (Vector3)transform.position).normalized;
                        NormalBulletPool[i].GetComponent<Old_Player_Normal_Bullet>().Initialize(Player_Gun.transform.position, direction);

                        break;

                    }
                }
            }
        }

    }

    private void Teleport()
    {
        if (follow_mouse_bullet != null)
        {
            if (follow_mouse_bullet.activeSelf)
            {
                this.gameObject.transform.position = follow_mouse_bullet_position;
                follow_mouse_bullet.SetActive(false);
            }
        }
       
    }

    private void CreateBarricade()
    {
        if (follow_mouse_bullet != null)
        {
            if (follow_mouse_bullet.activeSelf)
            {
                Player_Barricade_Prefab.transform.position = follow_mouse_bullet_position;
                Player_Barricade_Prefab.SetActive(true);
                follow_mouse_bullet.SetActive(false);
            }
        }
    }

    #endregion




}


