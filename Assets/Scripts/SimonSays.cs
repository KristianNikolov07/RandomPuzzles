using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimonSays : MonoBehaviour
{
    [SerializeField]
    List<GameObject> tiles;
    List<int> pattern;
    int current_tile = 0;
    int current_guess = 0;

    [SerializeField]
    Sprite default_tile;

    [SerializeField]
    Sprite correct_tile;

    [SerializeField]
    Sprite wrong_tile;

    bool is_clickable = true;

    [SerializeField]
    UnityEvent isSolved;

    public int length = 10;

    void Awake()
    {
        tiles = new List<GameObject>();
        foreach (Transform tile in transform)
        {
            tiles.Add(tile.gameObject);
            var tileScript = tile.gameObject.GetComponent<SimonSaysTile>();
            tileScript.onClicked.AddListener(OnTileClicked);
            tileScript.id = tiles.Count - 1;
        }
        GeneratePattern();
    }

    void GeneratePattern()
    {
        pattern = new List<int>();
        for (int i = 0; i < length; i++)
        {
            int rand = Random.Range(0, 8);
            pattern.Add(rand);
        }
        Debug.Log(pattern);
    }

    public IEnumerator ShowPattern()
    {
        is_clickable = false;
        yield return new WaitForSecondsRealtime(0.5f);
        for (int i = 0; i < current_guess + 1; i++)
        {
            yield return new WaitForSecondsRealtime(0.3f);
            tiles[pattern[i]].GetComponent<SpriteRenderer>().sprite = correct_tile;
            yield return new WaitForSecondsRealtime(0.5f);
            tiles[pattern[i]].GetComponent<SpriteRenderer>().sprite = default_tile;
        }
        is_clickable = true;
    }

    void OnTileClicked(int id)
    {
        if (!is_clickable) return;

        if (id == pattern[current_tile])
        {
            tiles[id].GetComponent<SpriteRenderer>().sprite = correct_tile;
            current_tile++;
            if (current_tile == current_guess + 1)
            {
                current_guess++;
                current_tile = 0;
                if (current_guess == length)
                {
                    isSolved.Invoke();
                    Debug.Log("Solved");
                    is_clickable = false;
                    return;
                }
                StartCoroutine(ShowPattern());
            }
        }
        else
        {
            current_tile = 0;
            current_guess = 0;
            tiles[id].GetComponent<SpriteRenderer>().sprite = wrong_tile;
            StartCoroutine(ShowPattern());
        }

        StartCoroutine(ChangeTileToDefault(id));
    }

    IEnumerator ChangeTileToDefault(int id)
    {
        yield return new WaitForSecondsRealtime(0.1f);
        tiles[id].GetComponent<SpriteRenderer>().sprite = default_tile;
    }
}
