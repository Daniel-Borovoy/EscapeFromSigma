using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject obj;
    public float moveSpeed = 5f;


    public Rigidbody2D rb;
    private Vector2 moveVelocity;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * moveSpeed;

    }


    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        Physics2D.gravity = new Vector3(0, 0, -9.8f);
        
    }

}
