using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToMain : MonoBehaviour
{
    public Button ToMainMenuBotton;

    private void Start() => ToMainMenuBotton.onClick.AddListener(TaskOnClick);

    private void TaskOnClick()
    {
        gameObject.GetComponent<Menu>().Resume();
        SceneManager.LoadScene(0);
    }
}
