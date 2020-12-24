using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    [Header("Key")]
    public GameObject keyIcon;
    /*public GameObject wallEffect;*/
    private bool keyBottonPushed;


    [Header("Moving")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 moveVelocity;


    [Header("Rotation")]
    [SerializeField] private float RotationSpeed;
    private Vector2 currentDirection = new Vector3(0.0f, 1.0f, 0.0f);
    private Transform transformObject;
    //Angle
    private float Angle;
    private float sign;


    [HideInInspector][Header("Animation")]
    private Animator anim;


    [Header("Shooting")]
    [SerializeField] private Transform shotPoint;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private float StartTimeBtwShots;
    private float TimeBtwShots;

    //Methods and functions

    private void Start()
    {
        anim = GetComponent<Animator>();
        transformObject = this.transform;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //Animations
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);

        if (Input.GetMouseButton(0))
            anim.SetBool("isShooting", true);
        else
            anim.SetBool("isShooting", false);


        //Rotation
        /*Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 objectPos = transformObject.position;
        Vector2 direction = mousePos - objectPos;
        direction.Normalize();
        currentDirection = Vector2.Lerp(currentDirection, direction, Time.deltaTime * RotationSpeed);
        transformObject.up = currentDirection;*/

        //Angle. 0<a<90 = RightUp, 90<a<180 = LeftUp, -180<a<-90 = LeftDown, -90<a<0 = RightDown
        //sign = (direction.y >= objectPos.y) ? 1 : -1;
        //Angle = Vector2.Angle(Vector2.right, direction) * sign;

        //Moving
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * moveSpeed;


        //Shooting
        if (TimeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(Bullet, shotPoint.position, transform.rotation);
                TimeBtwShots = StartTimeBtwShots;
            }
        }
        else
            TimeBtwShots -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        //Moving
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        Physics2D.gravity = new Vector3(0, 0, -9.8f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            keyIcon.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    public void OnKeyBottonDown()
    {
        keyBottonPushed = !keyBottonPushed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Door") && keyBottonPushed && keyIcon.activeInHierarchy)
        {
            //Instantiate(wallEffect, collision.transform.position, Quaternion.identity);
            keyIcon.SetActive(false);
            collision.gameObject.SetActive(false);
            keyBottonPushed = false;
        }
    }
}