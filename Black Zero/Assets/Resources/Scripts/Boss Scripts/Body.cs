using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] private GameObject Suicide_Enemy_Prefab_Spawn_Location;
    [SerializeField] private GameObject Suicide_Enemy_Prefab;
    private float SpawnEnemysTimer = 0f;
    public bool IsHit = false;
    private float IsHitDeactivateTimer = 0f;

    void Update ()
    {
        SpawnEnemysTimer += Time.deltaTime;

        if (SpawnEnemysTimer >= 5f)
        {
           // Instantiate(Suicide_Enemy_Prefab, Suicide_Enemy_Prefab_Spawn_Location.transform.position, Quaternion.identity);
            SpawnEnemysTimer = 0f;
        }

        if (IsHit == true)
        {
            Hit();
        }
        //spawn Suicide Enemy's

    }

    public void Hit()
    {
        // Color_Shower.GetComponent<Renderer>().material.color = Custom_Color;
        if (IsHit == true)
        {
            this.GetComponent<SpriteRenderer>().color = Color.black;
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
