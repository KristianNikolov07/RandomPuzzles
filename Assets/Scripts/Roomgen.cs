using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Roomgen : MonoBehaviour
{
    [SerializeField] GameObject firstRoom;
    [SerializeField] GameObject FinalLeft;
    [SerializeField] GameObject FinalUp;
    [SerializeField] GameObject FinalRight;
    [SerializeField] GameObject EndTrigger;
    [SerializeField] List<GameObject> rooms = new List<GameObject>();

    void PopulateRoomsArray()
    {

        string[] folders = {
            "Rooms/Left",
            "Rooms/Right",
            "Rooms/Up",
            "Rooms/LeftUp",
            "Rooms/RightUp"
        };

        foreach (string folder in folders)
        {
            GameObject[] prefabs = Resources.LoadAll<GameObject>(folder);
            rooms.AddRange(prefabs);
        }

    }

    void Awake()
    {
        PopulateRoomsArray();


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
                rand = Random.Range(0, rooms.Count);
                nextRoom = rooms[rand];
            }
            while (nextRoom.GetComponent<Room>().entranceOpposite != room.GetComponent<Room>().exit);

            Vector3 nextRoomSpawn = room.GetComponent<Room>().nextRoomSpawn.transform.position;
            room = Instantiate(nextRoom, nextRoomSpawn, Quaternion.identity);
            camera.AddPositon(room.transform.position);
        }

        Vector3 endTriggerSpawn = room.GetComponent<Room>().nextRoomSpawn.transform.position;
        if (room.GetComponent<Room>().exit == Room.Connection.LEFT)
        {
            room = Instantiate(FinalLeft, endTriggerSpawn, Quaternion.identity);
            camera.SetFinalRoomPos(room.transform.position);
            camera.SetFinalDirection(CameraMovement.FinalDirection.LEFT);
        }
        else if (room.GetComponent<Room>().exit == Room.Connection.UP)
        {
            room = Instantiate(FinalUp, endTriggerSpawn, Quaternion.identity);
            camera.SetFinalDirection(CameraMovement.FinalDirection.UP);
        }
        else if (room.GetComponent<Room>().exit == Room.Connection.RIGHT)
        {
            room = Instantiate(FinalRight, endTriggerSpawn, Quaternion.identity);
            camera.SetFinalRoomPos(room.transform.position);
            camera.SetFinalDirection(CameraMovement.FinalDirection.RIGHT);
        }
    }
}
