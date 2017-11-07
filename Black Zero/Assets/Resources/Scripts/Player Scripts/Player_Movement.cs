using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody rbody;

    private Animator animator;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        #region Movement

        Vector3 offset = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            offset += Vector3.forward * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            offset += Vector3.back * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            offset += Vector3.left * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            offset += Vector3.right * moveSpeed;
        }
        rbody.velocity = offset;
        animator.SetBool("running", offset.magnitude > 0);

        #endregion

    }

}
