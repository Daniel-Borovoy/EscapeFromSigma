using UnityEngine;

public class CameraFolow : MonoBehaviour
{

	private GameObject Player;
    public float movingSpeed;

    private void Awake() => Player = GameObject.FindGameObjectWithTag("Player");
    void LateUpdate() => transform.position = Vector3.Lerp(this.transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z-10), movingSpeed*Time.deltaTime);
}