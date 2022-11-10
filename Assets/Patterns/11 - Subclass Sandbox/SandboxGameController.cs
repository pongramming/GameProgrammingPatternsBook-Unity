using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandboxGameController : MonoBehaviour
{
    private SkyLaunch skyLaunch;

    private void Awake()
    {
        skyLaunch = new SkyLaunch();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            skyLaunch.Activate();
        }
    }
}
