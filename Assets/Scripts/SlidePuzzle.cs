using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlidePuzzle : MonoBehaviour
{

    public UnityEvent solved;
    public UnityEvent unsolved;
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
                    unsolved.Invoke();
                    return;
                }
            }
            
            
        }
        solved.Invoke();
    }

    void scramble(){
        int emptyIndex = 15;

        for(int i = 0; i < 100; i++){
            int rand = Random.Range(1, 5);
            if(rand == 1){
                if(emptyIndex != 0 && emptyIndex != 4 && emptyIndex != 8 && emptyIndex != 12){
                    tileClicked(emptyIndex - 1);
                    emptyIndex --;
                }
            }
            if(rand == 2){
                if(emptyIndex != 3 && emptyIndex != 7 && emptyIndex != 11 && emptyIndex != 15){
                    tileClicked(emptyIndex + 1);
                    emptyIndex ++;
                }
            }
            if(rand == 3){
                if(emptyIndex != 0 && emptyIndex != 1 && emptyIndex != 2 && emptyIndex != 3){
                    tileClicked(emptyIndex - 4);
                    emptyIndex -= 4;
                }
            }
            if(rand == 4){
                if(emptyIndex != 12 && emptyIndex != 13 && emptyIndex != 14 && emptyIndex != 15){
                    tileClicked(emptyIndex + 4);
                    emptyIndex += 4;
                }
            }
        }
    }
}
