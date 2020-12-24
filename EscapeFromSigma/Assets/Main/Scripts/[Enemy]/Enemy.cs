using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : MonoBehaviour
{
    //Variables
    public int health;
    private AddRoom room;
    public float MovingSpeed;
    public bool isRangedEnemy;
    public float AggressiveZone;
    public float MeleeStoppingDistance; //Minimal distance between player and melee enemy
    public float RangedStoppingDistance; //Minimal distance between player and ranged enemy
    private float DBPaE; //Distance Between Player and Enemy
    private int Sign;
    private float Angle;
    private bool isFacingRight;
    Transform player;
    public bool isAnimated;
    private Animator anim;
    [HideInInspector] public bool PlayerNotInRoom;
    public GameObject effect;


    //Awake, Start
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        room = GetComponentInParent<AddRoom>();
    }
    
    
    //Updates
    private void Update()
    {
        
        //Something about enemy health
        if (health <= 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            room.enemies.Remove(gameObject);
        }

        //Angle
        Vector2 enemyPosition = transform.position;
        Vector2 playerPosition = player.transform.position;
        Vector2 direction = playerPosition - enemyPosition;
        Sign = (direction.y >= enemyPosition.y) ? 1 : -1;
        Angle = Vector2.Angle(Vector2.right, direction) * Sign;

        //Moving
        if (!PlayerNotInRoom)
        {
            DBPaE = Vector2.Distance(transform.position, player.position);

            if (DBPaE <= AggressiveZone)
            {
                if (isRangedEnemy)
                {
                    GoToPlayer(RangedStoppingDistance);
                }
                else
                {
                    GoToPlayer(MeleeStoppingDistance);
                }
            }
        }

        
    }

    private void FixedUpdate()
    {
        if (isAnimated == false)
        {
            if (isFacingRight == false && (Angle < -90 && Angle > -180 || Angle > 90 && Angle < 180))
            {
                Flip();
            }
            else if (isFacingRight == true && (Angle > -90 && Angle < 90))
            {
                Flip();
            }
        }

        //Animation
        if (isAnimated == true)
        {
            bool Right = (Angle >= -22.5f && Angle < 22.5f) ? true : false;
            bool Left = ((Angle >= 157.5f && Angle < 180f) || (Angle >= -180f && Angle < -157.5f)) ? true : false;
            bool Up = (Angle >= 67.5f && Angle < 112.5f) ? true : false;
            bool Down = (Angle >= -112.5f && Angle < -67.5f) ? true : false;
            bool UpRight = (Angle >= 22.5f && Angle < 67.5f) ? true : false;
            bool UpLeft = (Angle >= 112.5f && Angle < 157.5) ? true : false;
            bool DownRight = (Angle >= -67.5f && Angle < -22.5f) ? true : false;
            bool DownLeft = (Angle >= -157.5f && Angle < -112.5f) ? true : false;

            anim.SetBool("Right", Right);
            anim.SetBool("Left", Left);
            anim.SetBool("Up", Up);
            anim.SetBool("Down", Down);
            anim.SetBool("Up-Right", UpRight);
            anim.SetBool("Up-Left", UpLeft);
            anim.SetBool("Down-Right", DownRight);
            anim.SetBool("Down-Left", DownLeft);
        }
    }

    //Other methods
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    private void GoToPlayer(float StoppingDistance)
    {
        if (DBPaE >= StoppingDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, MovingSpeed * Time.deltaTime);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
