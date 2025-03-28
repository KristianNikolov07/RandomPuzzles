using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        TimerInfo.time = GameObject.Find("Timer").GetComponent<Timer>().time_rounded;
        TimerInfo.timeText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>().text;
        SceneManager.LoadScene("EndScene");
    }
}
