using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{	private Animator anim;
    [SerializeField]private GameObject HpBar;
    public Image bar;
    public float fill;
    public float HP;
    public float selfDamage;
    void Start()
    {
        selfDamage = 25f;
    	bar.fillAmount = 1;
        HP = bar.fillAmount * 100;
        
    }
	void Update()
    {
        
        bar.fillAmount = HP / 100;

        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeSelfDamage();
        }
   
    }

    private void LateUpdate()
    {
        if (HP <= 0)
        {
            gameObject.SetActive(false);
            HpBar.SetActive(false);
        }
    }

    void TakeSelfDamage()
    {
        HP -= selfDamage; 
    }

    private void OnDisable()
    {
            Debug.Log("You died!");
    }

}
