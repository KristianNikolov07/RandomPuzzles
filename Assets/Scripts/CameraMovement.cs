using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] List<Vector3> positions = new List<Vector3>();
    int currentIndex = 0;
    float speed = 10f;

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

    IEnumerator MoveCameraCoroutine()
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
