using UnityEngine;

public class Room : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] matchingRooms;
    public GameObject nextRoomSpawn;

    void Start()
    {
        
    }

    public void SpawnNext(){
        int rand = Random.Range(0, matchingRooms.Length);
        GameObject next = Instantiate(matchingRooms[rand], nextRoomSpawn.transform.position, Quaternion.identity);
        next.GetComponent<Room>().SpawnNext();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
