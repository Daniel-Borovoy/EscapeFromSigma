using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class HealthBar : MonoBehaviour
{
    //Variables
    [Header("Health")]
    [SerializeField] private GameObject HpBar;
    private Animator anim;
    public Image bar;
    public float MaxHP;
    public float currentHP;
    public float selfDamage;

    [Header("Regeneration")]
    [SerializeField] private float RegenDelay;
    public float HPS;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    //Awake, Start and Updates
    void Awake()
    {
        HPS = 3f;
        RegenDelay = 3f;
        selfDamage = 10f;
        MaxHP = 100f;
    	bar.fillAmount = 1;
        currentHP = bar.fillAmount * 100;
    }
    
	void Update()
    {  
        bar.fillAmount = currentHP / 100;

        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeSelfDamage();
        }

        if (currentHP > MaxHP)
            currentHP = MaxHP;
    }

    private void LateUpdate()
    {
        if (currentHP <= 0)
        {
            gameObject.SetActive(false);
            HpBar.SetActive(false);
        }

    }
    //Other functions
    public void TakeSelfDamage()
    {
        currentHP -= selfDamage;

        if (regen != null)
            StopCoroutine(regen);
        regen = StartCoroutine(Regen());
    }

    public void Heal(float amountOfHeal)
    {
        currentHP += amountOfHeal;
    }
    private void OnDisable() => Debug.Log("You dead");

    //Coroutines

    IEnumerator Regen() {
        yield return new WaitForSeconds(RegenDelay);

        while (currentHP < MaxHP)
        {
            currentHP += HPS * Time.deltaTime;
            yield return regenTick;
        }
        regen = null;
    }
}
