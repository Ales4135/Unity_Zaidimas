using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameDone : MonoBehaviour
{
    public GameFinishedScreen game;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger entered");

        if(other.tag == "Player")
        {
            game.Setup();
        }
    }
}
