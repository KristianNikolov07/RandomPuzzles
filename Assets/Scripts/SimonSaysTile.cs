using UnityEngine;
using UnityEngine.Events;

public class SimonSaysTile : MonoBehaviour
{
    [SerializeField]
    public UnityEvent<int> onClicked;
    public int id;
    void OnMouseDown()
    {
        onClicked.Invoke(id);
    }
}
