using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    string url = "http://20.240.218.232";
    public GameObject nameInput;
    public GameObject TimerText;
    public GameObject errorText;

    void Start()
    {
        TimerText.GetComponent<TextMeshProUGUI>().text = TimerInfo.timeText;
    }

    public void UploadScore()
    {
        string username = nameInput.GetComponent<TextMeshProUGUI>().text;
        float time = TimerInfo.time;
        int numRooms = GameSettings.numRooms;
        StartCoroutine(Upload(username, time, numRooms));
    }

    IEnumerator Upload(string username, float time, int numRooms)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("time", time.ToString());
        form.AddField("rooms", numRooms.ToString());
        byte[] rawData = form.data;
        Debug.Log("Raw form data: " + System.Text.Encoding.UTF8.GetString(rawData));
        UnityWebRequest www = UnityWebRequest.Post(url + "/add", form);
        www.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            errorText.SetActive(true);
            Debug.Log(www.error);
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
