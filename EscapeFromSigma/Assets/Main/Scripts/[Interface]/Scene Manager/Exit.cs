using UnityEngine;
using UnityEngine.UI;
public class Exit : MonoBehaviour
{
    public Button ExitBotton;

    private void Start() => ExitBotton.onClick.AddListener(TaskOnClick);

    private void TaskOnClick() => Application.Quit();
}
