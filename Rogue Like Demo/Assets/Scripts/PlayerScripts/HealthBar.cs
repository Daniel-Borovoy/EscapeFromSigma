using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{	private Animator anim;
    public Image bar;
    public float fill;
    
    void Start()
    {	
    	bar.fillAmount = fill;
        fill = 1f;
         for (int i = 4; i > 0; i--)
        {
        	fill -= 0.25f * Time.deltaTime;
        }
    }
	void Update()
    {
        
       
        if (fill == 0)
        {
        	DieAnimation();
        }
    }
    	void DieAnimation()
     	{
     		anim.SetInteger("State", 10);
     		Debug.Log("You dead!");
     	}
}
