using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomVariants : MonoBehaviour
{
    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;

    public GameObject Key;
    //public GameObject Gun;

    [HideInInspector] public List<GameObject> rooms;

    private void Start()
    {
        StartCoroutine(RandomSpawner());
    }

    IEnumerator RandomSpawner()
    {
        yield return new WaitForSeconds(5f);
        AddRoom lastRoom = rooms[rooms.Count - 1].GetComponent<AddRoom>();

        Instantiate(Key, rooms[Random.Range(0, rooms.Count - 2)].transform.position, Quaternion.identity);
        //Instantiate(Gun, rooms[rooms.Count - 2].transform.position, Quaternion.identity);

        lastRoom.door.SetActive(true);
        lastRoom.walls.SetActive(false);//GetComponent<WallsController>().DisableWalls();
       
    }
}
