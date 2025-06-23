using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class LeaderboardEntry
{
    public string username;
    public double _time;
    public int rooms;
}

public class LeaderboardEntries
{
    public List<LeaderboardEntry> entries;
}

public class Leaderboard : MonoBehaviour
{
    string url = "http://20.240.218.232";
    int page = 0;
    int rooms = 10;

    public GameObject loadingText;
    public GameObject entriesPanel;
    public GameObject entryPrefab;
    public GameObject pageText;

    void Start()
    {
        StartCoroutine(FetchLeaderboard(0));
    }

    IEnumerator FetchLeaderboard(int page)
    {
        entriesPanel.SetActive(false);
        loadingText.SetActive(true);

        int childCount = entriesPanel.transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            Destroy(entriesPanel.transform.GetChild(i).gameObject);
        }

        pageText.GetComponent<TextMeshProUGUI>().text = "Page " + (page + 1);

        UnityWebRequest www = UnityWebRequest.Get(url + "/get?page=" + page + "&rooms=" + rooms);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            loadingText.SetActive(false);
            entriesPanel.SetActive(true);
            string res = www.downloadHandler.text;

            LeaderboardEntries json = JsonUtility.FromJson<LeaderboardEntries>(res);
            int place = page * 6 + 1;
            foreach (var entry in json.entries)
            {
                GameObject entryDisplay = Instantiate(entryPrefab, entriesPanel.transform);
                entryDisplay.GetComponent<LeaderboardEntryDisplay>().setValues(place, entry.username, (float)entry._time);
                place++;
            }
        }
    }

    public void previousPage()
    {
        page--;
        if (page < 0) page = 0;
        StartCoroutine(FetchLeaderboard(page));
    }

    public void nextPage()
    {
        page++;
        StartCoroutine(FetchLeaderboard(page));
    }

    public void SetRooms10()
    {
        rooms = 10;
        StartCoroutine(FetchLeaderboard(page));
    }

    public void SetRooms20()
    {
        rooms = 20;
        StartCoroutine(FetchLeaderboard(page));
    }

    public void SetRooms50()
    {
        rooms = 50;
        StartCoroutine(FetchLeaderboard(page));
    }
}
