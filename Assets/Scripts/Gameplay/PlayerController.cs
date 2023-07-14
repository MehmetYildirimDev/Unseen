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
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;


    //public new Rigidbody rigidbody;
    //public GameObject playerStaticRotation;

    private Animator animator;

    //private DynamicJoystick dynamicJoystick;
    private Vector3 direction;


    private Touch _touch;

    private Vector3 _touchDown;
    private Vector3 _touchUp;

    private bool _dragStarted;
    private bool _isMoving;

    public bool status = true;

    private void Awake()
    {
        instance = this;
        playerScale = 0;
        animator = this.GetComponent<Animator>();
    }

    //private void Start()
    //{
    //    dynamicJoystick = GameObject.Find("Dynamic Joystick").GetComponent<DynamicJoystick>();
    //}


    private void Update()
    {
        if (isGameOver)
        {
            GameManager.instance.ShowGameOVerPanel();
        }

        animatorController();
        MoveAndRotate();

    }

    private void MoveAndRotate()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Began)
            {
                _dragStarted = true;
                _isMoving = true;
                _touchDown = _touch.position;
                _touchUp = _touch.position;

                animator.SetBool("isMoving", _isMoving);
            }
        }
        if (_dragStarted)
        {
            if (_touch.phase == TouchPhase.Moved)
            {
                _touchDown = _touch.position;
            }

            if (_touch.phase == TouchPhase.Ended)
            {
                _touchDown = _touch.position;
                _isMoving = false;
                _dragStarted = false;
                animator.SetBool("isMoving", _isMoving);
            }

            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotation(), rotationSpeed * Time.deltaTime);
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }
    }

    Quaternion CalculateRotation()
    {
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
        return temp;
    }

    Vector3 CalculateDirection()
    {
        Vector3 temp = (_touchDown - _touchUp).normalized;

        temp.z = temp.y;
        temp.y = 0;

        return temp;
    }

    private void animatorController()
    {
        if (isGameOver)
        {
            animator.Play("PlayerCatch");
            return;
        }
        //animator.SetFloat("velocity", direction.magnitude);
    }

    /*
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
        rigidbody.AddForce(direction * movementSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        if (direction.magnitude > 0.2f)
        {
            transform.rotation = Quaternion.Lerp(playerStaticRotation.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
        }
    }
    */
    //oyun tek bi fonksiyonda bitmeli ve diger objeler oyun bitti methodu calistiginda ona gore tepki vermeli
    public void GameOver()
    {
        isGameOver = true;
    }

}
