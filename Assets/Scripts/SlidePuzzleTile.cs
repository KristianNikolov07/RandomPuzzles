using UnityEngine;

public class SlidePuzzleTile : MonoBehaviour
{
    public int arrPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown(){
        GameObject.Find("SlidePuzzle").GetComponent<SlidePuzzle>().tileClicked(arrPos);
    }
}
