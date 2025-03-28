using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public GameObject TimerText;
    void Start()
    {
        TimerText.GetComponent<TextMeshProUGUI>().text = TimerInfo.timeText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
