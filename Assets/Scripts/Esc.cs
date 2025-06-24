using UnityEngine;

public class Esc : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(pauseMenu.activeSelf){
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else{
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            
        }
    }
}
