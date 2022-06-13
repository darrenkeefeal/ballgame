using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Chase : MonoBehaviour
{
    public static bool chasePlayer;

    //Get Player Transform Position
    public static string myName;
    public static string playerName;
    public static float x, y, z;

    void Start()
    {
        chasePlayer = false;
        
        playerName = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Get Player Name
            playerName = other.transform.parent.name;

            //Get my Name
            myName = this.transform.parent.parent.name;

            //Get Player Pos
            GameObject getPlayerPos = GameObject.Find(other.name);
            Transform getTransformPlayer = getPlayerPos.GetComponent<Transform>();
            x = getTransformPlayer.position.x;
            y = getTransformPlayer.position.y;
            z = getTransformPlayer.position.z;

            if(ball_Control.playerBallName == playerName)
            {
                chasePlayer = true;
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            chasePlayer = false;
        }
    }
}
