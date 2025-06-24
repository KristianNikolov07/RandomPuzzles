using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    Animator animator;
    public void fadeOut()
    {
        animator = GetComponent<Animator>();
        animator.enabled = true;
        animator.Play("FadeIn");
        StartCoroutine(end());

    }

    IEnumerator end()
    {
        yield return new WaitForSecondsRealtime(1f);
        animator.enabled = false;
        TimerInfo.time = GameObject.Find("Timer").GetComponent<Timer>().time_rounded;
        TimerInfo.timeText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>().text;
        SceneManager.LoadScene("EndScene");
    }
}
