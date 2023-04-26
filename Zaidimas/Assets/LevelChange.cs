using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger entered");

        if(other.tag == "Player")
        {
            player.transform.position = new Vector3(-1f, -301.81f, transform.position.z);
        }
    }
}
