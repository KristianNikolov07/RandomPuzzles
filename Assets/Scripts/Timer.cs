using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI meshPro; 
    float time = 0;
    public float time_rounded;

    void Awake()
    {
        meshPro = GetComponent<TextMeshProUGUI>();

        
    }

    void Update()
    {
        time += Time.deltaTime;
        time_rounded = (float)Math.Round(time, 2);

        int totalSeconds = (int)time_rounded;
        int hours = totalSeconds / 3600;
        int remainingSeconds = totalSeconds % 3600;
        int mins = remainingSeconds / 60;
        int secs = remainingSeconds % 60;


        float fractionalPart = time_rounded - totalSeconds;
        int cents = Mathf.RoundToInt(fractionalPart * 100); 

        meshPro.text = $"{hours:D2}:{mins:D2}:{secs:D2}.{cents:D2}";

    }
}