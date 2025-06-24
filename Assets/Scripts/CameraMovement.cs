using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] List<Vector3> positions = new List<Vector3>();
    public enum FinalDirection
    {
        LEFT,
        UP,
        RIGHT
    }

    FinalDirection finalDirection = new FinalDirection();

    Vector3 finalRoomPos = new Vector3();

    int currentIndex = 0;
    float speed = 10f;
    GameObject fadeOut;

    void Awake()
    {
        fadeOut = GameObject.FindGameObjectWithTag("FadeOut");
    }

    public void AddPositon(Vector3 pos)
    {
        pos.x -= 4.5f;
        pos.y -= 0.5f;
        pos.z = -10;
        positions.Add(pos);
    }

    public void MoveToNextPosition()
    {
        StartCoroutine(MoveCameraCoroutine());
    }

    public void SetFinalDirection(FinalDirection direction)
    {
        finalDirection = direction;
    }

    public void SetFinalRoomPos(Vector3 pos)
    {
        pos.x -= 4.5f;
        pos.y -= 0.5f;
        pos.z = -10;
        finalRoomPos = pos;
    }

    IEnumerator MoveCameraCoroutine()
    {
        if (currentIndex + 1 < positions.Count)
        {
            Vector3 nextPos = positions[currentIndex + 1];

            while (Vector3.Distance(transform.position, nextPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * speed);
                yield return null;
            }

            transform.position = nextPos;
            currentIndex++;
        }
        else
        {
            //Final Movement
            if (finalDirection == FinalDirection.LEFT || finalDirection == FinalDirection.RIGHT)
            {
                while (Vector3.Distance(transform.position, finalRoomPos) > 0.01f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, finalRoomPos, Time.deltaTime * speed);
                    yield return null;
                }
            }

            Vector3 endPos = transform.position;
            endPos.y += 8;
            fadeOut.GetComponent<FadeOut>().fadeOut();
            while (Vector3.Distance(transform.position, endPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * speed / 2);
                yield return null;
            }
            
        }
        
    }

    void Start()
    {
        transform.position = positions[0];
        StartCoroutine(firstMove());
    }

    IEnumerator firstMove()
    {
        yield return new WaitForSecondsRealtime(1f);
        MoveToNextPosition();
    }
}
