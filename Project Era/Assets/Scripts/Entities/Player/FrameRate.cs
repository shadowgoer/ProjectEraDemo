using UnityEngine;
using System.Collections;

public class FrameRate : MonoBehaviour {

    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
