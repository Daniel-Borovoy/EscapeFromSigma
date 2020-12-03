using UnityEngine;
public class SceneManager : MonoBehaviour
{
    public void nextScene(int _sceneNumber)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneNumber);
    }
}