using UnityEngine;

public class Roomgen : MonoBehaviour
{
    [SerializeField] GameObject firstRoom;
    [SerializeField] GameObject FinalLeft;
    [SerializeField] GameObject FinalUp;
    [SerializeField] GameObject FinalRight;
    [SerializeField] GameObject EndTrigger;
    [SerializeField] GameObject[] rooms;

    void Awake()
    {
        CameraMovement camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();
        int numRooms = GameSettings.numRooms;
        GameObject room = Instantiate(firstRoom, Vector3.zero, Quaternion.identity);
        camera.AddPositon(room.transform.position);

        for (int i = 0; i < numRooms; i++)
        {
            int rand;
            GameObject nextRoom;
            do
            {
                rand = Random.Range(0, rooms.Length);
                nextRoom = rooms[rand];
            }
            while (nextRoom.GetComponent<Room>().entranceOpposite != room.GetComponent<Room>().exit);

            Vector3 nextRoomSpawn = room.GetComponent<Room>().nextRoomSpawn.transform.position;
            room = Instantiate(nextRoom, nextRoomSpawn, Quaternion.identity);
            camera.AddPositon(room.transform.position);
        }

        Vector3 endTriggerSpawn = room.GetComponent<Room>().nextRoomSpawn.transform.position;
        if (room.GetComponent<Room>().exit == Room.Connection.LEFT)
            Instantiate(FinalLeft, endTriggerSpawn, Quaternion.identity);
        if (room.GetComponent<Room>().exit == Room.Connection.UP)
            Instantiate(FinalUp, endTriggerSpawn, Quaternion.identity);
        if (room.GetComponent<Room>().exit == Room.Connection.RIGHT)
            Instantiate(FinalRight, endTriggerSpawn, Quaternion.identity);
    }
}
