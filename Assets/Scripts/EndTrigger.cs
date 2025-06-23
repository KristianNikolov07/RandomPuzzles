using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        TimerInfo.time = GameObject.Find("Timer").GetComponent<Timer>().time_rounded;
        TimerInfo.timeText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>().text;
        SceneManager.LoadScene("EndScene");
    }
}
