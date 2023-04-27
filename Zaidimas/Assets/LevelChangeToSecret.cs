using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeToSecret : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger entered");

        if(other.tag == "Player")
        {
            player.transform.position = new Vector3(377f, -2.17f, transform.position.z);
        }
    }
}
