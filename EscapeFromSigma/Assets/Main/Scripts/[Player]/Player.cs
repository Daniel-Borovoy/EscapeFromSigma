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
    Transform transformObject;
    bool FacingRight = true;
    //Angle
    private float Angle;
    private float sign;


    [HideInInspector][Header("Animation")]
    private Animator anim;

    //Methods and functions
    //Awake, Start and Updates
    private void Start()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        transformObject = this.transform;
    }
    private void Update()
    {
        /*//Animations
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);

        if (Input.GetMouseButton(0))
            anim.SetBool("isShooting", true);
        else
            anim.SetBool("isShooting", false);*/

        //Rotatoin
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 objectPos = transformObject.position;
        Vector2 direction = mousePos - objectPos;

        //Angle. 0<a<90 = RightUp, 90<a<180 = LeftUp, -180<a<-90 = LeftDown, -90<a<0 = RightDown
        sign = (direction.y >= objectPos.y) ? 1 : -1;
        Angle = Vector2.Angle(Vector2.right, direction) * sign;

        

        //Moving
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * moveSpeed;
    }

    private void FixedUpdate()
    {
        //Moving
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        Physics2D.gravity = new Vector3(0, 0, -9.8f);

        //Rotation
        if (FacingRight != true && (Angle < 90 && Angle > -90))
            Flip();
        else if (FacingRight == true && (Angle < -180 && Angle < -90) && (Angle < 180 && Angle > 90))
            Flip();
    }

    //Other methods

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

    public void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}