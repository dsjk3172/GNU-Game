using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey("escape"))
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
