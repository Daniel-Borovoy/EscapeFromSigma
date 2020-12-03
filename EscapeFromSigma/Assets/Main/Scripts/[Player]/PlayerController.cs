using UnityEngine;

public class PlayerController : MonoBehaviour
{
                                                                        //Moving
    public float speed;

    private Rigidbody2D Rigidbody;
    private Vector2 moveVelocity;

    private void Awake() => Rigidbody = GetComponent<Rigidbody2D>();

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    private void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position + moveVelocity * Time.deltaTime);
    }
}