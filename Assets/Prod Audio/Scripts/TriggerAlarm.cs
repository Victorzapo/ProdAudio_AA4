using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAlarm : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/3D/Props/Alert");
        }
    }
}
