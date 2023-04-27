using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeFromSecret : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger entered");

        if(other.tag == "Player")
        {
            player.transform.position = new Vector3(121.5f, -332.9f, transform.position.z);
        }
    }
}
