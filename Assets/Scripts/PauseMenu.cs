using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Resume(){
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Quit(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
