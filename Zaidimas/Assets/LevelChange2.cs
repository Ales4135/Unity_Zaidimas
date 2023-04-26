using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange2 : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger entered");

        if(other.tag == "Player")
        {
            player.transform.position = new Vector3(145f, -11.44f, transform.position.z);
        }
    }
}
