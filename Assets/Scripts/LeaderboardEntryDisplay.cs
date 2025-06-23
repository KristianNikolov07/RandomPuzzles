using System;
using TMPro;
using UnityEngine;

public class LeaderboardEntryDisplay : MonoBehaviour
{
    public GameObject placeText;
    public GameObject usernameText;
    public GameObject timeText;

    public void setValues(int place, string username, float time)
    {
        if (place == 1)
        {
            placeText.GetComponent<TextMeshProUGUI>().text = "1ST";
        }
        else if (place == 2)
        {
            placeText.GetComponent<TextMeshProUGUI>().text = "2ND";
        }
        else if (place == 3)
        {
            placeText.GetComponent<TextMeshProUGUI>().text = "3RD";
        }
        else
        {
            placeText.GetComponent<TextMeshProUGUI>().text = place + "TH";
        }

        usernameText.GetComponent<TextMeshProUGUI>().text = username;

        time += Time.deltaTime;
        float time_rounded = (float)Math.Round(time, 2);

        int totalSeconds = (int)time_rounded;
        int hours = totalSeconds / 3600;
        int remainingSeconds = totalSeconds % 3600;
        int mins = remainingSeconds / 60;
        int secs = remainingSeconds % 60;

        float fractionalPart = time_rounded - totalSeconds;
        int cents = Mathf.RoundToInt(fractionalPart * 100);

        timeText.GetComponent<TextMeshProUGUI>().text = $"{hours:D2}:{mins:D2}:{secs:D2}.{cents:D2}";
    }
}
