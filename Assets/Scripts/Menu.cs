using GameJolt.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gameSettingsPanel;
    public GameObject leaderboardPanel;

    public void Play()
    {
        mainMenuPanel.SetActive(false);
        gameSettingsPanel.SetActive(true);
    }

    public void Gen10Rooms()
    {
        GameSettings.numRooms = 10;
        SceneManager.LoadScene("Main");
    }

    public void Gen20Rooms()
    {
        GameSettings.numRooms = 20;
        SceneManager.LoadScene("Main");
    }

    public void Gen50Rooms()
    {
        GameSettings.numRooms = 50;
        SceneManager.LoadScene("Main");
    }

    public void Back()
    {
        gameSettingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void OpenLeaderboard()
    {
        Application.OpenURL("https://gamejolt.com/games/randompuzzles/1001724/scores/1014527/best");

    }

    public void ExitLeaderboard()
    {
        leaderboardPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
