using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public bool isGameOver;

    public static PlayerController instance;//Singleton
    public int playerScale;


    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;


    private Rigidbody rb;
    private Animator animator;
    private FloatingJoystick floatingJoystick;

    private void Awake()
    {
        instance = this;
        playerScale = 0;
        animator = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        floatingJoystick= GameObject.FindGameObjectWithTag("FloatingJoystick").GetComponent<FloatingJoystick>();
        
    }

    private void FixedUpdate()
    {
        if (!isGameOver)
        {

            Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
            rb.AddForce(movementSpeed * Time.fixedDeltaTime * direction, ForceMode.VelocityChange);

            if (direction != Vector3.zero)
            {
                Quaternion newRotation = Quaternion.LookRotation(direction);
                rb.rotation = newRotation;
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
        else
        {
            animator.Play("PlayerCatch");
            GameManager.instance.ShowGameOVerPanel();
        }
    }

    //oyun tek bi fonksiyonda bitmeli ve diger objeler oyun bitti methodu calistiginda ona gore tepki vermeli
    public void GameOver()
    {
        isGameOver = true;
    }

}
