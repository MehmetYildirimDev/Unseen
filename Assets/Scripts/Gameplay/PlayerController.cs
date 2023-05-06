using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public bool isGameOver;

    public static PlayerController instance;//Singleton yapiyoz
    public int playerScale;


    //public VariableJoystick VariableJoystick;
    public new Rigidbody rigidbody;
    public float speed;

    public float rotationSpeed;
    public GameObject playerStaticRotation;

    public Animator animator;

    private DynamicJoystick dynamicJoystick;
    private Vector3 direction;

    private void Awake()
    {
        instance = this;
        playerScale = 0;
    }

    private void Start()
    {
        dynamicJoystick = GameObject.Find("Dynamic Joystick").GetComponent<DynamicJoystick>();
    }


    private void Update()
    {
        if (isGameOver)
        {
            GameManager.instance.ShowGameOVerPanel();
        }

        animatorController();

    }

    private void animatorController()
    {
        if (isGameOver)
        {
            animator.Play("PlayerCatch");
            return;
        }
        animator.SetFloat("velocity", direction.magnitude);
    }


    public void FixedUpdate()
    {
        if (!isGameOver)
        {
            MovePlayerNew();
        }
    }

    private void MovePlayerNew()
    {
        direction = Vector3.forward * dynamicJoystick.Vertical + Vector3.right * dynamicJoystick.Horizontal;
        rigidbody.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        if (direction.magnitude > 0.2f)
        {
            transform.rotation = Quaternion.Lerp(playerStaticRotation.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
        }
    }

    //oyun tek bi fonksiyonda bitmeli ve diger objeler oyun bitti methodu calistiginda ona gore tepki vermeli
    public void GameOver()
    {
        isGameOver = true;
    }

}
