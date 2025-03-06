using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesPuzzle : MonoBehaviour
{
    public GameObject tile;
    public GameObject[] tiles;
    public int firstTileIndex;
    private List<int> pattern = new List<int>();  // Use List<int> for dynamic growth

    void Start()
    {
        GeneratePattern(5);
    }

    void GeneratePattern(int size)
    {
        pattern.Clear(); // Ensure pattern is empty before generating
        pattern.Add(firstTileIndex);
        int currentIndex = firstTileIndex;

        for (int i = 0; i < size - 1; i++)
        {
            int rand = Random.Range(1, 5);

            switch (rand)
            {
                case 1: currentIndex--; break;
                case 2: currentIndex++; break;
                case 3: currentIndex -= 3; break;
                case 4: currentIndex += 3; break;
            }

            currentIndex = (currentIndex + 9) % 9;

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
