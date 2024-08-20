using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public PlayerMovement player1;

    public PlayerMovement player2;
    public PlayerShooting play1shoot;
    public PlayerShooting play2shoot;
    public PlayerHealth play1health;
    public PlayerHealth play2health;

    public bool player1active = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            SwitchPlayer();
        }
    }

    void SwitchPlayer()
    {
        if (player1active)
        {
            player1.enabled = false;
            player2.enabled = true;
            player1active = false;
            play1shoot.enabled = false;
            play2shoot.enabled = true;
            play1health.enabled = false;
            play2health.enabled = true;

        }
        else
        {
            player1.enabled = true;
            player2.enabled = false;
            player1active = true;
            play1shoot.enabled = true;
            play2shoot.enabled = false;
            play1health.enabled = true;
            play2health.enabled = false;
        }
    }
}
