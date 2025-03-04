using UnityEngine;

public class TilesPuzzle : MonoBehaviour
{

    GameObject[] tiles;
    public GameObject tile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GeneratePuzzle(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneratePuzzle(int size){
        for(int i = 0; i < size; i++){
            for(int j = 0; j < size; j++){
                Instantiate(tile, new Vector3(transform.position.x + i, transform.position.y - j, 0), Quaternion.identity);
            }
        }
    }
}
