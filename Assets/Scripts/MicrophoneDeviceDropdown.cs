using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MicrophoneDeviceDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    private MicLoudnessDetection _micLoudnessDetection;
    List<string> microphoneList = new List<string>();
    private void Start()
    {
        PopulateDropdown();
    }
    void PopulateDropdown()
    {
        foreach (var item in Microphone.devices)
        {
            microphoneList.Add(item);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(microphoneList);
        _micLoudnessDetection.MicToAudioClip(Microphone.devices[dropdown.value]);
    }
}
