using UnityEngine;

public class Roomgen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    GameObject firstRoom;

    [SerializeField]
    GameObject[] rooms;

    void Start()
    {
        GameObject room = Instantiate(firstRoom, new Vector3(0, 0, 0), Quaternion.identity);
        
        for(int i = 0; i < 50; i++)
        {
            GameObject nextRoom = room.GetComponent<Room>().nextRoom();
            Vector3 nextRoomSpawn = room.GetComponent<Room>().nextRoomSpawn.transform.position;

            room = Instantiate(nextRoom, nextRoomSpawn, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
