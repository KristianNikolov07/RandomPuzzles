using UnityEngine;

public class Room : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject[] matchingRooms;
    public GameObject nextRoomSpawn;

    public enum Connection{
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    public Connection entranceOpposite;
    public Connection exit;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject nextRoom(){
        int rand = Random.Range(0, matchingRooms.Length);
        return matchingRooms[rand];
    }
}
