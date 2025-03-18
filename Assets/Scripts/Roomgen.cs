using UnityEngine;

public class Roomgen : MonoBehaviour
{
    [SerializeField]
    GameObject firstRoom;

    [SerializeField]
    GameObject[] rooms;

    void Start()
    {
        GameObject room = Instantiate(firstRoom, Vector3.zero, Quaternion.identity);

        for (int i = 0; i < 20; i++)
        {
            int attempts = 0;
            int rand;
            GameObject nextRoom = null;

            do
            {
                rand = Random.Range(0, rooms.Length);
                nextRoom = rooms[rand];
                Debug.Log("Entrance " + nextRoom.GetComponent<Room>().entranceOpposite);
                Debug.Log("Exit " + room.GetComponent<Room>().exit);
                attempts++;

                if (attempts > 100)
                {
                    Debug.LogError("No valid room found after 100 attempts!");
                    return;
                }
            }
            while (nextRoom.GetComponent<Room>().entranceOpposite != room.GetComponent<Room>().exit);

            Vector3 nextRoomSpawn = room.GetComponent<Room>().nextRoomSpawn.transform.position;
            room = Instantiate(nextRoom, nextRoomSpawn, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
