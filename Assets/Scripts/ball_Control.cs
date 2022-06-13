using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_Control : MonoBehaviour
{
    float degreesPerSecond = 2;

    player_Control closestPlayer;

    //Move the ball Up
    private GameObject enemyGoal;
    private Transform targetedGoal;
    private float ballSpeed = 0.8f;

    public static bool playerBall;
    float z;

    //Move the ball to other Players
    bool passTheBall;

    //Who is carrying the ball
    public static string playerBallName;

    // Start is called before the first frame update
    void Start()
    {
        enemyGoal = GameObject.FindGameObjectWithTag("Enemy Goal");

        playerBall = false;
        
        passTheBall = false; 
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate Ball
        transform.Rotate(new Vector3(degreesPerSecond, 0, 0) * 1f);

        if(make_Players.namePlayer >= 1)
        {
            findPlayer();
        }

        if(playerBall)
        {
            //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.01f);
            var step =  ballSpeed * Time.deltaTime;
            targetedGoal = enemyGoal.GetComponent<Transform>();
            transform.position = Vector3.MoveTowards(transform.position, targetedGoal.position, step);

            if (Vector3.Distance(transform.position, targetedGoal.position) < 0.001f)
            {
                //Swap the position of the cylinder.
                targetedGoal.position *= -1.0f;
            }
        }
        else if(passTheBall)
        {
            var step =  2 * Time.deltaTime;
            targetedGoal = closestPlayer.GetComponent<Transform>();
            transform.position = Vector3.MoveTowards(transform.position, targetedGoal.position, step);

            if (Vector3.Distance(transform.position, targetedGoal.position) < 0.001f)
            {
                //Swap the position of the cylinder.
                targetedGoal.position *= -1.0f;
            }
        }
        else
        {
            transform.position = this.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerBall = true;
            passTheBall = false;

            playerBallName = other.transform.parent.name;
        }
        else if(other.tag == "Enemy Goal")
        {
            //Goal (Restart All)
            Debug.Log("Goallll");
            camera_Control.scorePlayer++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerBall = false;
            findPlayerExit();
        }
    }

    private void findPlayerExit()
    {
        float distanceClosestPlayer = Mathf.Infinity;
        player_Control[] allPlayers = GameObject.FindObjectsOfType<player_Control>();

        if(allPlayers.Length > 1)
        {
            foreach (player_Control currentPlayer in allPlayers)
            {
                float distanceToPlayer = (currentPlayer.transform.position - this.transform.position).sqrMagnitude;
                if(distanceToPlayer < distanceClosestPlayer)
                {
                    distanceClosestPlayer = distanceToPlayer;
                    closestPlayer = currentPlayer;

                    passTheBall = true;
                }
            }
        }
        else
        {
            //(Restart All)
            Debug.Log("Game Over");
            camera_Control.scoreEnemy++;

            Application.LoadLevel("SampleScene");
        }
    }

    private void findPlayer()
    {
        float distanceClosestPlayer = Mathf.Infinity;
        player_Control[] allPlayers = GameObject.FindObjectsOfType<player_Control>();

        if(allPlayers.Length > 1)
        {
            foreach (player_Control currentPlayer in allPlayers)
            {
                float distanceToPlayer = (currentPlayer.transform.position - this.transform.position).sqrMagnitude;
                if(distanceToPlayer < distanceClosestPlayer)
                {
                    distanceClosestPlayer = distanceToPlayer;
                    closestPlayer = currentPlayer;

                    passTheBall = true;
                }
            }
        }
    }
}
