using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TilesPuzzle : MonoBehaviour
{
    public GameObject tile;
    public GameObject[] tiles;
    public UnityEvent solved;
    public int firstTileIndex;
    private List<int> pattern = new List<int>(); 

    void Start()
    {
        for(int i = 0; i < tiles.Length; i++){
            tiles[i].GetComponent<Tile>().id = i;
        }
        GeneratePattern(5);
    }

    void GeneratePattern(int size)
    {
        pattern.Clear(); 
        pattern.Add(firstTileIndex);
        int currentIndex = firstTileIndex;

        for (int i = 0; i < size - 1; i++)
        {
            while (true)
            {
                int rand = Random.Range(1, 5);

                if (rand == 1 && currentIndex % 3 != 0) 
                {
                    currentIndex--;
                    break;
                }
                else if (rand == 2 && currentIndex % 3 != 2)
                {
                    currentIndex++;
                    break;
                }
                else if (rand == 3 && currentIndex >= 3) 
                {
                    currentIndex -= 3;
                    break;
                }
                else if (rand == 4 && currentIndex <= 5)
                {
                    currentIndex += 3;
                    break;
                }
            }

            pattern.Add(currentIndex);
        }
    }

    public void ShowPattern()
    {
        StopAllCoroutines();
        for(int i = 0; i < tiles.Length; i++){
            tiles[i].GetComponent<Tile>().changeToDefault();
        }
        StartCoroutine(ShowPatternCoroutine());
    }

    private IEnumerator ShowPatternCoroutine()
    {
        foreach (int index in pattern)
        {
            tiles[index].GetComponent<Tile>().changeToGreen();
            yield return new WaitForSeconds(0.5f);
            tiles[index].GetComponent<Tile>().changeToDefault();
        }
    }

    int currentTile = 0;
    public void tileActivated(int id){
        
        if(id == pattern[currentTile]){
            tiles[id].GetComponent<Tile>().changeToGreen();
            currentTile++;
        }
        else{
            for(int i = 0; i < tiles.Length; i++){
                tiles[i].GetComponent<Tile>().changeToDefault();
            }
            currentTile = 0;
        }

        if(currentTile >= 5){
            solved.Invoke();
        }

    }
}
