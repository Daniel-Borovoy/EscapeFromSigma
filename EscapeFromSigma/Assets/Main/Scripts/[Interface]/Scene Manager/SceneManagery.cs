using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagery : MonoBehaviour
{
    public int CurNumOfRooms = 0;
    public int MaxRooms;


    public void Update()
    {
        if (CurNumOfRooms >= MaxRooms)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void nextScene(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }
    public void PlusToCur()
    {
        CurNumOfRooms += 1;
    }
}