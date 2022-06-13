using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Control : MonoBehaviour
{
    //Chasing Ball
    public GameObject targetBall;
    private Transform tBall;

    //Walk Speed
    public float walkSpeed;
    public float chaseSpeed;

    //First Player Spawn
    private bool firstSpawn;

    //Get Cought by Enemy
    private bool getCought;

    bool iHaveBall;
    
    bool iCanMove;
    Material m_Material;

    // Start is called before the first frame update
    void Start()
    {
        //Get Cought by Enemy
        getCought = false;

        //First Spawn
        firstSpawn = true;

        //Looking for the ball
        targetBall = GameObject.Find("Ball");
        tBall = targetBall.GetComponent<Transform>();

        //Do I have the ball ? (Change to false later)
        iHaveBall = false;

        //Can I move ?
        m_Material = GetComponent<Renderer>().material;
        m_Material.color = Color.grey;
        iCanMove = false;

        StartCoroutine(playerWalk());
    }

    //Walk after 3 Sec
    IEnumerator playerWalk()
    {
        yield return new WaitForSeconds(3);
        iCanMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(iCanMove && !getCought)
        {
            //Change Color
            m_Material.color = Color.blue;

            if(this.transform.parent.name == "Player1")
            {
                //Chasing Ball
                var step =  chaseSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, tBall.position, step);

                if (Vector3.Distance(transform.position, tBall.position) < 0.001f)
                {
                    //Swap the position of the cylinder.
                    tBall.position *= -1.0f;
                }
            }
            else
            {
                //Go Up
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + walkSpeed);
            }
        }
        if(getCought && this.transform.parent.name == enemy_Chase.playerName && enemy_Chase.chasePlayer)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.5f, this.transform.position.z);

            Destroy(this.transform.parent.gameObject, 3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            ball_Control.playerBall = false;
            getCought = true;
        }
    }
}
