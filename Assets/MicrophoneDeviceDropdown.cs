using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.UI;

public class MicrophoneDeviceDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    private MicLoudnessDetection _micLoudnessDetection;
    private void Start()
    {
        PopulateDropdown();
    }
    void PopulateDropdown()
    {
        List<string> microphoneList = new List<string>();
        foreach (var item in Microphone.devices)
        {
            microphoneList.Add(item);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(microphoneList);
        _micLoudnessDetection.MicToAudioClip(Microphone.devices[dropdown.value]);
    }
}
