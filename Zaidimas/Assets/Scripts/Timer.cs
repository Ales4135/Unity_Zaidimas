using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    bool timerActive = false;
    float currentTime;
    public TextMeshProUGUI timerText;

    Damageable playerDamageable;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(player == null )
        {
            Debug.Log("No player found in the scene.");
        }

        playerDamageable = player.GetComponent<Damageable>();
    }

    void Start()
    {
        currentTime = 0;
        timerActive = true;
    }

    void Update()
    {
        if(timerActive == true){
            currentTime = currentTime - Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerText.text = time.ToString(@"mm\:ss\:ff");

        if(playerDamageable.Health == 0){
            timerActive = false;
        }

        else if(playerDamageable.Health > 0)
            timerActive = true;
        
    }

    
}
