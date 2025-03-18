using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(){
        Debug.Log("aaa");
        SceneManager.LoadScene(1);
    }

    public void Leaderboard(){

    }

    public void Quit(){
        Application.Quit();
    }
}
