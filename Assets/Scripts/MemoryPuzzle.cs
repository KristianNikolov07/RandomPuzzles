using UnityEngine;
using System.Collections;

public class MemoryPuzzle : MonoBehaviour
{
    public GameObject[] tiles;
    void Start()
    {
        SelectCorrect();
        StartCoroutine(swap());
    }

    void SelectCorrect(){
        int rand = Random.Range(0, tiles.Length);
        tiles[rand].GetComponent<MemoryPuzzleTile>().isCorrect = true;
    }

    IEnumerator swap(){
        for (int i = 0; i < 10; i++)
        {
            int rand1 = Random.Range(0, tiles.Length);
            int rand2;
            do{
                rand2 = Random.Range(0, tiles.Length);
            }while(rand1 == rand2);

            while(true)
            {
                if(tiles[rand1].GetComponent<MemoryPuzzleTile>().isMoving == false && tiles[rand2].GetComponent<MemoryPuzzleTile>().isMoving == false)
                {
                    if(rand1 < rand2){
                        if(rand2 - rand1 == 1){
                            tiles[rand1].GetComponent<MemoryPuzzleTile>().MoveRight();
                            tiles[rand2].GetComponent<MemoryPuzzleTile>().MoveLeft();
                            GameObject tmp = tiles[rand1];
                            tiles[rand1] = tiles[rand2];
                            tiles[rand2] = tmp;
                        }
                        if(rand2 - rand1 == 2){
                            tiles[rand1].GetComponent<MemoryPuzzleTile>().MoveRightByTwo();
                            tiles[rand2].GetComponent<MemoryPuzzleTile>().MoveLeftByTwo();
                            GameObject tmp = tiles[rand1];
                            tiles[rand1] = tiles[rand2];
                            tiles[rand2] = tmp;
                        }
                    }
                    if(rand1 > rand2){
                        if(rand1 - rand2 == 1){
                            tiles[rand2].GetComponent<MemoryPuzzleTile>().MoveRight();
                            tiles[rand1].GetComponent<MemoryPuzzleTile>().MoveLeft();
                            GameObject tmp = tiles[rand1];
                            tiles[rand1] = tiles[rand2];
                            tiles[rand2] = tmp;
                        }
                        if(rand1 - rand2 == 2){
                            tiles[rand2].GetComponent<MemoryPuzzleTile>().MoveRightByTwo();
                            tiles[rand1].GetComponent<MemoryPuzzleTile>().MoveLeftByTwo();
                            GameObject tmp = tiles[rand1];
                            tiles[rand1] = tiles[rand2];
                            tiles[rand2] = tmp;
                        }

                    }
                    break;
                }
                
                
            }
            yield return new WaitForSecondsRealtime(0.1f);
            
        }
        
    }
}
