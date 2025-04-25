using UnityEngine;

public class Room : MonoBehaviour
{
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

    public GameObject nextRoom(){
        int rand = Random.Range(0, matchingRooms.Length);
        return matchingRooms[rand];
    }
}
