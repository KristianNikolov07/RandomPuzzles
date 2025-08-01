using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    bool player_in = false;
    bool switched_on = false;
    public UnityEvent clicked;
    public UnityEvent toggled_on;
    public UnityEvent toggled_off;

    void OnMouseDown()
    {
        clicked.Invoke();
        switched_on = !switched_on;
        if (switched_on)
        {
            toggled_on.Invoke();
        }
        else
        {
            toggled_off.Invoke();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && player_in)
        {
            clicked.Invoke();
            switched_on = !switched_on;
            if (switched_on)
            {
                toggled_on.Invoke();
            }
            else
            {
                toggled_off.Invoke();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player_in = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player_in = false;
    }
}
