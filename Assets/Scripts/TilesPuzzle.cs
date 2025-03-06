using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesPuzzle : MonoBehaviour
{
    public GameObject tile;
    public GameObject[] tiles;
    public int firstTileIndex;
    private List<int> pattern = new List<int>(); 

    void Start()
    {
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
}
