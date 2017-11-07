using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Follow_Enemy : MonoBehaviour
{
    [SerializeField] private float Movement_Speed = 1f;
    [SerializeField] private GameObject Target; //player anderen vijanden etc...

	void Update ()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, Target.transform.position, Movement_Speed * Time.deltaTime);
    }
}
