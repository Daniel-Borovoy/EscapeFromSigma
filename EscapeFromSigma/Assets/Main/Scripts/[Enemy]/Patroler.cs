using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroler : MonoBehaviour
{
    public float speed;

    public int positiononPatrol;

    Transform point;

    bool movingright;

    Transform player;

    bool chill = false;
    bool angry = false;
    bool goback = false;

    public float stoppingDistance;
    void Start()
    {
        point = GameObject.FindGameObjectWithTag("Point").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positiononPatrol && angry == false)
        {
            chill = true;
        }
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goback = false;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goback = true;
            angry = false;
        }


        if(chill == true)
        {
            Chill();
        }
        else if(angry == true)
        {
            Angry();
        }
        else if(goback == true)
        {
            GoBack();
        }
    }
    void Chill()
    {
        if(transform.position.x > point.position.x + positiononPatrol)
        {
            movingright = false;
        }
        else if(transform.position.x < point.position.x - positiononPatrol)
        {
            movingright = true;
        }

        if(movingright)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        speed = 4;
    }
    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = 3;
    }
    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        speed = 4;
    }
}
