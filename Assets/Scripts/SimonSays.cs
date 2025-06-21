using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
            tile.gameObject.GetComponent<SimonSaysTile>().onClicked.AddListener(OnTileClicked);
            tile.gameObject.GetComponent<SimonSaysTile>().id = tiles.Count - 1;
        }
        GeneratePattern();
    }

    void GeneratePattern()
    {
        pattern = new List<int>();
        for (int i = 0; i < length; i++)
        {
            var rand = Random.Range(0, 8);
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
        if (is_clickable)
        {
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
        
    }

    IEnumerator ChangeTileToDefault(int id)
    {
        yield return new WaitForSecondsRealtime(0.1f);
        tiles[id].GetComponent<SpriteRenderer>().sprite = default_tile;
    }
    
    
}
