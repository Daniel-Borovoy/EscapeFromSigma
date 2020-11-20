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
  		IsWalk();
  	}
  	

    void IsWalk()
    {
    	if	(Input.GetKeyDown(KeyCode.A) & Input.GetKeyDown(KeyCode.D))
    	{
    		anim.SetInteger("State", 0);
    	}
    	else{
    	bool r = false;
  		bool l = false;
    	//Анимация, когда идет вверх.
        if(Input.GetKeyDown(KeyCode.W)){
          bool up = true;
          anim.SetInteger("State", 1);
          anim.SetFloat("X", 0);
          anim.SetFloat("Y", 1);
      }
           if (Input.GetKeyUp(KeyCode.W))
           {
           	bool up = false;
           anim.SetInteger("State", 0);
       }	
       





		//Анимация, когда идет вниз.
        else if(Input.GetKeyDown(KeyCode.S))
        {
        	anim.SetInteger("State", 1);
        	anim.SetFloat("X", 0);
            anim.SetFloat("Y", -1);
        }
             if (Input.GetKeyUp(KeyCode.S))
            {
           anim.SetInteger("State", 0);
        	}
        
        //Анимация, когда идет влево.
        else if(Input.GetKeyDown(KeyCode.A))
        {
        	anim.SetInteger("State", 1);
        	anim.SetFloat("X", -1);
            anim.SetFloat("Y", 0);
            l = true;
        }
            if (Input.GetKeyUp(KeyCode.A))
            {
            	l = false;
            anim.SetInteger("State", 0);
        }
         if ((r == true) & (l == true))
        	{
        		anim.SetInteger("State", 0);
        	}
         //Анимация, когда идет вправо.
        else if(Input.GetKeyDown(KeyCode.D))
        {	
        	r = true;
        	anim.SetInteger("State", 1);
        	anim.SetFloat("X", 1);
            anim.SetFloat("Y", 0);
        }
           if (Input.GetKeyUp(KeyCode.D))
           {
           	r = false;
           anim.SetInteger("State", 0);
        	}
        
     	}

}
}
