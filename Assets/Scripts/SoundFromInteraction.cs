using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFromInteraction : MonoBehaviour
{
    public float loudnessSensibility = 100;
    public MicLoudnessDetection detector;
    public float threshold = 0.1f;
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
    }
}
