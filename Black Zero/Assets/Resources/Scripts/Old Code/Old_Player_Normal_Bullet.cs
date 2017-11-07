using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old_Player_Normal_Bullet : MonoBehaviour
{
    [SerializeField]
    private float Bullet_speed = 4f;
    private float TimeTillDeactiveateTimer = 0f;
    private Vector2 direction;
    private Rigidbody2D rigidbody;

    [SerializeField] private int damage = 1;

    public void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Vector2 position, Vector2 direction)
    {
       // gameObject.SetActive(true);
        transform.position = position;
        this.direction = direction;

        //ik moet zorgen voor dat de bullet rotatie.x 90 is
     
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition((Vector2)transform.position + direction * Bullet_speed * Time.fixedDeltaTime);
        
    }

    private void Update()
    {

        Bullet_speed = Random.Range(4f, 8f);

        // Debug.Log("DeactiveTimer = " + TimeTillDeactiveateTimer);

        if (TimeTillDeactiveateTimer >= 2.5f)
        {
            TimeTillDeactiveateTimer = 0f;
            Deactivate();
        }

        TimeTillDeactiveateTimer += Time.deltaTime;
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.GetComponent<Enemy_Health>().Health -= damage;
            Deactivate();
        }
        
        if (col.gameObject.tag == "Environment" || col.gameObject.tag == "Enemy_Bullet")
        {
            Deactivate();
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
