using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundMusic : MonoBehaviour
{
    public GameObject finalBoss;
    private FMODUnity.StudioEventEmitter bckgMusic;

    private void Start()
    {
        bckgMusic = GetComponent<FMODUnity.StudioEventEmitter>();
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (finalBoss == null)
        {
            bckgMusic.EventInstance.setParameterByName("Win", 1);
        }
    }
}
