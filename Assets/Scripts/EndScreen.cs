using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public GameObject nameInput;
    public GameObject TimerText;
    public GameObject errorText;

    Dictionary<int, int> tableIDs = new Dictionary<int, int>();
    void Start()
    {
        TimerText.GetComponent<TextMeshProUGUI>().text = TimerInfo.timeText;
        tableIDs.Add(10, 1014527);
        tableIDs.Add(20, 1014528);
        tableIDs.Add(50, 1014529);
    }

    public void UploadScore()
    {
        string username = nameInput.GetComponent<TextMeshProUGUI>().text;
        float time = TimerInfo.time;
        int numRooms = GameSettings.numRooms;
        int tableID = tableIDs[numRooms];

        GameJolt.API.Scores.Add((int)time, TimerInfo.timeText, username, tableID, "", (bool success) =>
        {
            if (success)
            {
                BackToMenu();
            }
            else
            {
                errorText.SetActive(true);
            }
        });
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
