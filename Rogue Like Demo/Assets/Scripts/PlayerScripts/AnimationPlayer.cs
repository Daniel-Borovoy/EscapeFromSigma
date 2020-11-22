using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
  	private Animator anim;

  	void Start ()
  	{
  		anim = GetComponent <Animator> ();
  	}
  	void Update()
  	{
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveDown(); 
        }
        //Костыль... Сделал так, потомучто getkeydown и getkeyup работают , если находятся в одной функции.
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetFloat("X", 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetFloat("X", 0);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetFloat("Y", 0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetFloat("Y", 0);
        }
    }

    void MoveUp()
    {
        anim.SetFloat("Y", 1);
    }
    void MoveLeft()
    {
        anim.SetFloat("X", -1);
    }
    void MoveRight()
    {
        anim.SetFloat("X", 1);
    }
    void MoveDown()
    {
        anim.SetFloat("Y", -1);
    }
}



