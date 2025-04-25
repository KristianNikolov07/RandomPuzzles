using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MatchPuzzle : MonoBehaviour
{
    public GameObject[] tiles; 
    public UnityEvent solved;
    public Sprite defaultSprite;
    void Start()
    {
        reshuffle();
    }

    void reshuffle()
    {
        for (int t = 0; t < tiles.Length; t++ )
        {
            GameObject tmp = tiles[t];
            int r = Random.Range(t, tiles.Length);
            tiles[t] = tiles[r];
            tiles[r] = tmp;
        }

        tiles[0].transform.localPosition = new Vector3(0, 0, -1);
        tiles[1].transform.localPosition = new Vector3(1, 0, -1);
        tiles[2].transform.localPosition = new Vector3(2, 0, -1);
        tiles[3].transform.localPosition = new Vector3(3, 0, -1);
        tiles[4].transform.localPosition = new Vector3(0, -1, -1);
        tiles[5].transform.localPosition = new Vector3(1, -1, -1);
        tiles[6].transform.localPosition = new Vector3(2, -1, -1);
        tiles[7].transform.localPosition = new Vector3(3, -1, -1);


    }

    int clickedTiles = 0;
    Sprite previousTileActivateSprite;
    public void TileClicked(Sprite activateSprite){
  
        if(clickedTiles%2 != 0 && activateSprite != previousTileActivateSprite){
            StartCoroutine(deactivateTiles());
            clickedTiles = 0;
            return;
        }
        previousTileActivateSprite = activateSprite;
        clickedTiles++;
        if(clickedTiles == 8){
            solved.Invoke();
        }

    }

    IEnumerator deactivateTiles(){
        yield return new WaitForSecondsRealtime(0.5f);
        for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].GetComponent<SpriteRenderer>().sprite = defaultSprite;
                tiles[i].GetComponent<MatchPuzzleTile>().activated = false;
            }
    }

        
}
