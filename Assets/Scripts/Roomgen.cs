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
        room.GetComponent<Room>().SpawnNext();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
