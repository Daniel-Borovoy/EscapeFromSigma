using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float speed;

    private Vector2 currentDirection = new Vector3(0.0f, 1.0f, 0.0f);
    private Transform transformObject;

    private void Start() => transformObject = this.transform;

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 objectPos = transformObject.position;

        Vector2 direction = mousePos - objectPos;
        direction.Normalize();

        currentDirection = Vector2.Lerp(currentDirection, direction, Time.deltaTime * speed);
        transformObject.up = currentDirection;
    }
}
