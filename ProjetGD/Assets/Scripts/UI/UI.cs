using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class UI : MonoBehaviour
{
    private void OnEnable()
    {
        ThrowMode.throwModeSwitched += UpdateThrowMode;
    }

    private void OnDisable()
    {
        ThrowMode.throwModeSwitched -= UpdateThrowMode;
    }

    // Update is called once per frame
    void UpdateThrowMode()
    {
        if (ThrowMode.GetThrowMode())
            GetComponent<TextMeshProUGUI>().text = "Tirer";
        else
            GetComponent<TextMeshProUGUI>().text = "Pointer";
    }
}