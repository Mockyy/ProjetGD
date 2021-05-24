using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThrowMode : MonoBehaviour
{
    public static event Action throwModeSwitched;

    private static bool throwMode;

    // Start is called before the first frame update
    void Start()
    {
        throwMode = true;
        GetComponent<AimPointe>().enabled = false;
        GetComponent<AimTir>().enabled = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("SwitchThrowMode"))
        {
            SwitchThrowMode();
        }
    }

    private void SwitchThrowMode()
    {
        throwMode = !throwMode;
        throwModeSwitched?.Invoke();
        if (throwMode)
        {
            GetComponent<AimPointe>().enabled = false;
            GetComponent<AimTir>().enabled = true;
        }
        else
        {
            GetComponent<AimPointe>().enabled = true;
            GetComponent<AimTir>().enabled = false;
        }
    }

    public static bool GetThrowMode()
    {
        return throwMode;
    }

}
