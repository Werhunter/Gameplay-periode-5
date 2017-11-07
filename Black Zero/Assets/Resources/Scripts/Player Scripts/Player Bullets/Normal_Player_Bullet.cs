using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Player_Bullet : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private int damage = 1;
    private Vector3 direction;

    public void Initialize(Vector3 direction)
    {
        this.direction = direction;
        Destroy(gameObject, 3f);

    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        // doe hier een Phsics.SphereCast();
        //Collider[] colliders = Physics.OverlapSphere(transform.position, .25f);
        //for (int i = 0; i < colliders.Length; i++)
        //{
        //    if (colliders[i].gameObject.tag == "Environment")
        //    {
        //        gameObject.SetActive(false);
        //        return;
        //    }
        //}
    }

    private void OnTriggerEnter(Collider col)
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

    private void Deactivate()
    { 
        this.gameObject.SetActive(false);
    }
}
