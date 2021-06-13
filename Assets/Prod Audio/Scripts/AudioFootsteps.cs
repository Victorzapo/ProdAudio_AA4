using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFootsteps : MonoBehaviour
{
    private int iSurface;
    private string sSurface;

    [FMODUnity.EventRef]
    public string fmodEventPath = "";
    private FMOD.Studio.EventInstance footstepsInstance;

    private float footstepsDelay = 0.35f;
    private float currentTime = 0.0f;
    private bool isMoving = false;

    private CharacterController cController;

    void Start()
    {
        sSurface = "Normal";
        footstepsInstance = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/2D/Player/Player_ft");
        cController = GetComponent<CharacterController>();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (sSurface != hit.transform.tag)
        {
            switch (hit.transform.tag)
            {
                case "Untagged":
                    iSurface = 0;
                    footstepsDelay = 0.35f;
                    break;

                case "Desk":
                    iSurface = 1;
                    footstepsDelay = 0.35f;
                    break;

                case "Metal":
                    iSurface = 2;
                    footstepsDelay = 0.5f;
                    break;

                default:
                    iSurface = 0;
                    break;
            }
            sSurface = hit.transform.tag;
            footstepsInstance.setParameterByName("Surface", iSurface);
        }
    }

    public void FootstepsPlay()
    {
        footstepsInstance.start();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) isMoving = true;
        else isMoving = false;

        if (currentTime <= footstepsDelay)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            if (isMoving) FootstepsPlay();
            currentTime = 0.0f;
        }
    }


}
