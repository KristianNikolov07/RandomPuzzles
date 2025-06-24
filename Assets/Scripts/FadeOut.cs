using System.Collections;
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
        SceneManager.LoadScene("EndScene");
    }
}
