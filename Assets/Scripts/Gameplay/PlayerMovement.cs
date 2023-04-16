using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isGameOver;

    public static PlayerMovement instance;//Singleton yapiyoz
    public int playerScale;


    //public VariableJoystick VariableJoystick;
    public new Rigidbody rigidbody;
    public float speed;

    public float rotationSpeed;
    public GameObject playerStaticRotation;

    public Vector3 firstPos;
    public Vector3 lastPos;

    public Vector3 dif;

    public Animator animator;

    private void Awake()
    {
        instance = this;
        playerScale = 0;
    }

    private void Update()
    {

        animatorController();

    }

    private void animatorController()
    {
        if (isGameOver)
        {
            animator.Play("PlayerCatch");
            return;
        }
        animator.SetFloat("velocity", dif.magnitude);
    }


    public void FixedUpdate()
    {
        if (!isGameOver)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 10;
            firstPos = Camera.main.ScreenToWorldPoint(pos);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 10;
            lastPos = Camera.main.ScreenToWorldPoint(pos);
            dif = lastPos - firstPos;
            dif.x = Mathf.Clamp(dif.x, -1, 1);
            dif.y = 0;
            dif.z = Mathf.Clamp(dif.z, -1, 1);
            //transform.position += new Vector3(dif.x, 0, dif.z);
        }
        else
        {
            dif = Vector3.zero;
        }

        rigidbody.AddForce(dif * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        if (dif.magnitude > 0.2f)
        {
            transform.rotation = Quaternion.Lerp(playerStaticRotation.transform.rotation, Quaternion.LookRotation(dif), Time.deltaTime * rotationSpeed);
        }
    }

}
