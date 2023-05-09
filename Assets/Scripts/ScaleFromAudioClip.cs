using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class ScaleFromAudioClip : MonoBehaviour
{
    public AudioSource source;

    public Vector3 minScale;

    public Vector3 macScale;

    public MicLoudnessDetection detector;

    public float threshold = 0.1f;

    public float loudnessSensibility = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromAudioClip(source.timeSamples, source.clip) * loudnessSensibility;
        if (loudness < threshold) loudness = 0;
        transform.localScale = Vector3.Lerp(minScale, macScale, loudness);
    }
}
