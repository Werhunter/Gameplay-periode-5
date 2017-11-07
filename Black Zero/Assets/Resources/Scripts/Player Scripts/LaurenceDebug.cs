using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LaurenceDebug : MonoBehaviour {
    private void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EditorApplication.isPaused = !EditorApplication.isPaused;
        }
        #endif
    }

}
