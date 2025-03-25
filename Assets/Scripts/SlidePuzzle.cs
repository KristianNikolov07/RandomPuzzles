using System.Collections;
using UnityEngine;

public class SlidePuzzle : MonoBehaviour
{
    public GameObject[] tiles;
    
    void Awake(){
        int i = 0;
        foreach (var tile in tiles)
        {
            if(tile != null){
                tile.GetComponent<SlidePuzzleTile>().arrPos = i;
                i++;
            }
            
        }
    }

    void Start()
    {
        scramble();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tileClicked(int pos){
        //left
        if(pos != 0 && pos != 4 && pos != 8 && pos != 12){
            if(tiles[pos - 1] == null){
                tiles[pos - 1] = tiles[pos];
                tiles[pos] = null;
                tiles[pos - 1].transform.position += new Vector3(-1, 0, 0);
                tiles[pos - 1].GetComponent<SlidePuzzleTile>().arrPos--;
            }
        }
        //right
        if(pos != 3 && pos != 7 && pos != 11 && pos != 15){
            if(tiles[pos + 1] == null){
                tiles[pos + 1] = tiles[pos];
                tiles[pos] = null;
                tiles[pos + 1].transform.position += new Vector3(1, 0, 0);
                tiles[pos + 1].GetComponent<SlidePuzzleTile>().arrPos++;
            }
        }

        //up
        if(pos != 0 && pos != 1 && pos != 2 && pos != 3){
            if(tiles[pos - 4] == null){
                tiles[pos - 4] = tiles[pos];
                tiles[pos] = null;
                tiles[pos - 4].transform.position += new Vector3(0, 1, 0);
                tiles[pos - 4].GetComponent<SlidePuzzleTile>().arrPos-= 4;
            }
        }

        //down
        if(pos != 12 && pos != 13 && pos != 14 && pos != 15){
            if(tiles[pos + 4] == null){
                tiles[pos + 4] = tiles[pos];
                tiles[pos] = null;
                tiles[pos + 4].transform.position += new Vector3(0, -1, 0);
                tiles[pos + 4].GetComponent<SlidePuzzleTile>().arrPos+= 4;
            }
        }
        check();
    }


    void check(){

        foreach (var tile in tiles)
        {
            if (tile != null){
                SlidePuzzleTile tileScript = tile.GetComponent<SlidePuzzleTile>();
                if((tileScript.arrPos + 1).ToString() != tileScript.name){
                    return;
                }
            }
            
            
        }
        Debug.Log("Solved");
    }

    void scramble(){
        //TODO: ADD SCRAMBLE ALG
    }
}
