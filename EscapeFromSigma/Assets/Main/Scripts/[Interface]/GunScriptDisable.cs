using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScriptDisable : MonoBehaviour
{
    Gun bl;

    private void Start()
    {
        bl = gameObject.GetComponent<Gun>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            bl.enabled = !bl.enabled;
            Debug.Log("dasdsa");
        }
    }
}
