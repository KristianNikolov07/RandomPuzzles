using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    GameObject pauseMenu;

    bool isPaused = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;

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
