using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateReverb : MonoBehaviour
{
    private FMOD.Studio.EventInstance rvbSnapshot;

    private void Start()
    {
        rvbSnapshot = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Cave rvb");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rvbSnapshot.start();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rvbSnapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
