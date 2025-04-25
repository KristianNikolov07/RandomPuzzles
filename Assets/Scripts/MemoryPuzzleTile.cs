using UnityEngine;
using System.Collections;

public class MemoryPuzzleTile : MonoBehaviour
{
    public float moveSpeed = 2f;
    public bool isMoving = false;
    public bool isCorrect = false;
    
    IEnumerator MoveLeftCoroutine()
    {
        isMoving = true;
        Vector3 targetPos = transform.position + Vector3.left * 2;
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

    IEnumerator MoveLeftByTwoCoroutine()
    {
        isMoving = true;
        Vector3 targetPos = transform.position + Vector3.left * 4;
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

    IEnumerator MoveRightCoroutine()
    {
        isMoving = true;
        Vector3 targetPos = transform.position + Vector3.right * 2;
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

    IEnumerator MoveRightByTwoCoroutine()
    {
        isMoving = true;
        Vector3 targetPos = transform.position + Vector3.right * 4;
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }


    public void MoveLeft(){
        StartCoroutine(MoveLeftCoroutine());
    }

    public void MoveLeftByTwo(){
        StartCoroutine(MoveLeftByTwoCoroutine());
    }

    public void MoveRight(){
        StartCoroutine(MoveRightCoroutine());
    }

    public void MoveRightByTwo(){
        StartCoroutine(MoveRightByTwoCoroutine());
    }
}