using UnityEngine;

public class Roomgen : MonoBehaviour
{
    [SerializeField]
    GameObject firstRoom;

    [SerializeField]
    GameObject EndTrigger;

    [SerializeField]
    GameObject[] rooms;

    void Start()
    {
        GameObject room = Instantiate(firstRoom, Vector3.zero, Quaternion.identity);

        for (int i = 0; i < 5; i++)
        {
            int rand;
            GameObject nextRoom = null;

            do
            {
                rand = Random.Range(0, rooms.Length);
                nextRoom = rooms[rand];
                Debug.Log("Entrance " + nextRoom.GetComponent<Room>().entranceOpposite);
                Debug.Log("Exit " + room.GetComponent<Room>().exit);
            }
            while (nextRoom.GetComponent<Room>().entranceOpposite != room.GetComponent<Room>().exit);

            Vector3 nextRoomSpawn = room.GetComponent<Room>().nextRoomSpawn.transform.position;
            room = Instantiate(nextRoom, nextRoomSpawn, Quaternion.identity);
        }

        Vector3 endTriggerSpawn = room.GetComponent<Room>().nextRoomSpawn.transform.position;
        Instantiate(EndTrigger, endTriggerSpawn, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
