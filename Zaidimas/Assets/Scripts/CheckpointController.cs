using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointController : MonoBehaviour
{
    public Sprite redFlag;
    public Sprite blueFlag;
    private SpriteRenderer checkpointSpriteRenderer;
    public bool checkpointReached;

    // Start is called before the first frame update
    void Start()
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player")
        {
            checkpointSpriteRenderer.sprite = blueFlag;
            checkpointReached = true;
            PlayerController.lastCheckpoint = transform.position;
        }
        //if(other.tag == "Player")
        //{
        //    checkpointSpriteRenderer.sprite = blueFlag;
        //    checkpointReached = true;
        //}
    }
}
