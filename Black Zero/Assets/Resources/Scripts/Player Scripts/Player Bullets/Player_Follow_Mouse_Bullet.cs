using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Follow_Mouse_Bullet : MonoBehaviour
{

    [SerializeField] private float speed = 5f;

    //private Vector3 direction;
    private bool DeactivateTimerActionvation = false;
    private float DeactivateTimer = 3f;

    [SerializeField]private GameObject PlayerPosition;

    //public void Initialize()
    //{
        //this.direction = direction;
        //Destroy(gameObject, 3f);
    //}

    public void Awake()
    {
        //this.transform.position = BulletSpawnPosition;
        DeactivateTimerActionvation = true;
        this.transform.position = PlayerPosition.transform.position;
    }

    private void Update()
    {

        Time.timeScale = 0.5f;

        if (DeactivateTimerActionvation == true)
        {
            DeactivateTimer -= Time.deltaTime;
        }

        if (DeactivateTimer <= 0f)
        {
            // this.transform.position = BulletSpawnPosition;
            Deactivate();
        }

        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.y = 0f;
        //transform.Translate(direction * speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // doe hier een Phsics.SphereCast();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            Deactivate();
            // Debug.Log("ik ga uit");
        }
    }

    private void Deactivate()
    {
      
        DeactivateTimer = 0f;
        DeactivateTimer = 3f;
        this.transform.position = PlayerPosition.transform.position;
        this.gameObject.SetActive(false);
    }


}
