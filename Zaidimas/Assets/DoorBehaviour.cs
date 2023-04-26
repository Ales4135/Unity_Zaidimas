using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public void OpenDoor()
    {
        Vector3 doorClosePos = transform.position;
        Vector3 doorOpenPos = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
        float doorSpeed = 300f;

        if (transform.position != doorOpenPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorOpenPos, doorSpeed * Time.deltaTime);
        }
    }
}
