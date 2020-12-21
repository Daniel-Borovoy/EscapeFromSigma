using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoomMain : MonoBehaviour
{
    [Header("Walls")]
    public GameObject walls;
    public GameObject wallEffect;

    private RoomVariants variants;
    private bool wallsDestroyed;

    private void Awake()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
    }

    private void Start()
    {
        variants.rooms.Add(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(waitToDisableWalls());
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (wallsDestroyed && other.CompareTag("Wall"))
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator waitToDisableWalls()
    {
        yield return new WaitUntil(() => GetComponent<RoomVariants>().FinishedGenerating == true);
        walls.GetComponent<WallsController>().DisableWalls();
    }
}
