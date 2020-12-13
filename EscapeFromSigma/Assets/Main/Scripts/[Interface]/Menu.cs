using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    HealthBar HB;
    Gun gn;
    Animator playerAnimator;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        HB = GetComponent<HealthBar>();
        gn = GetComponent<Gun>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        	if (GameIsPaused)
        	{
        		Resume();
        	}
        	else
        	{
        		Pause();
        	}
        }
    }

        void Resume ()
        {
        	pauseMenuUI.SetActive(false);
        	Time.timeScale = 1f;
        	GameIsPaused = false;
            gn.enabled = true;
            playerAnimator.enabled = true;
            HB.enabled = true;
        }

       	void Pause ()
        {
        	pauseMenuUI.SetActive(true);
        	Time.timeScale = 0f;
        	GameIsPaused = true;
            gn.enabled = false;
            playerAnimator.enabled = false;
            HB.enabled = false;
        }
    }