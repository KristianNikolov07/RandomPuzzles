using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField]
    private int speed = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        rigidbody.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;

    }
}
