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
        mainMenuPanel.SetActive(false);
        leaderboardPanel.SetActive(true);
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
