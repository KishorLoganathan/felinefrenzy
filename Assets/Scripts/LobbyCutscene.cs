using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LobbyCutscene : MonoBehaviour
{

    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;
    public CinemachineVirtualCamera cam3;

    public float timeBetweenCameras = 2f;

    // These functions were a test to try out dynamic camera angles in the lobby of my game. Some ChatGPT aid was used in this script 
    void Start() {

        StartCoroutine(PlayCutscene());

    }

    IEnumerator PlayCutscene() {

        // Activate Camera 1
        cam1.Priority = 10;
        cam2.Priority = 5;
        cam3.Priority = 5;
        yield return new WaitForSeconds(timeBetweenCameras);

        // Activate Camera 2
        cam1.Priority = 5;
        cam2.Priority = 10;
        yield return new WaitForSeconds(timeBetweenCameras);

        // Activate Camera 3
        cam2.Priority = 5;
        cam3.Priority = 10;
        yield return new WaitForSeconds(timeBetweenCameras);

        // Ends cutscene by bringing priority back to main camera
        cam3.Priority = 5;

    }
    

}
