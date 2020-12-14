using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControls : MonoBehaviour
{
	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
    Gun gn;
    Animator playerAnimator;

    private void Start()
    {
        gn = GameObject.FindGameObjectWithTag("Player").GetComponent<Gun>();
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    void Update ()
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
        void Resume ()
        {
        	pauseMenuUI.SetActive(false);
        	Time.timeScale = 1f;
        	GameIsPaused = false;
            gn.enabled = true;
            playerAnimator.enabled = true;
        }
        void Pause ()
        {
        	pauseMenuUI.SetActive(true);
        	Time.timeScale = 0f;
        	GameIsPaused = true;
            gn.enabled = false;
            playerAnimator.enabled = false;
        }

	}
    public void PlayPressed()
    {
       //
    }
    public void ExitPressed()
    {
    	pauseMenuUI.SetActive(false);
        	Time.timeScale = 1f;
        	GameIsPaused = false;
        
    }
}