using UnityEngine;

public class SlidePuzzleTile : MonoBehaviour
{
    public int arrPos;
    public void OnMouseDown(){
        GetComponentInParent<SlidePuzzle>().tileClicked(arrPos);
    }
}
