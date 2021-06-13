using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string fmodEventPath = "";
    private FMOD.Studio.EventInstance shootInstance;

    private void Start()
    {
        shootInstance = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/3D/Enemies/Enemy_shoot");
    }

    public void ShootPlay()
    {
        shootInstance.start();
    }
}
