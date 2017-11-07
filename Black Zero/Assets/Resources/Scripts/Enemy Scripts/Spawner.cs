using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Suicide_Enemy_Prefab;
    private float SpawnEnemysTimer = 0f;
    private float SpawnEnemysTimerEnd = 5f;

    [SerializeField] private Transform Player;

    void Update()
    {
        SpawnEnemysTimer += Time.deltaTime;

        if (SpawnEnemysTimer >= SpawnEnemysTimerEnd)
        {
            GameObject Basic_Enemy = Instantiate(Suicide_Enemy_Prefab, transform.position, Quaternion.identity);
            Basic_Enemy.GetComponent<Enemy>().target = Player;
            SpawnEnemysTimer = 0f;
        }

    }


}
