using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Control : MonoBehaviour
{
    public GameObject targetPlayer;
    private Transform tPlayer;

    //Walk Speed
    public float chaseSpeed;

    //Save first Position
    private Transform firstPosition;
    private Vector3 spawnPos;
    private Vector3 targetPosition;

    //Chase Line
    public CapsuleCollider enemyChase;
    bool isTargetingPlayer;

    bool iCanMove;
    Material m_Material;

    // Start is called before the first frame update
    void Start()
    {
        //Save first Position
        firstPosition = this.GetComponent<Transform>();
        spawnPos = firstPosition.position;
        SetTargetPosition(spawnPos);

        //Check Target Player
        isTargetingPlayer = false;

        //Can I move ?
        m_Material = GetComponent<Renderer>().material;
        m_Material.color = Color.grey;
        iCanMove = false;

        StartCoroutine(enemyWalk());
    }

    //Walk after 3 Sec
    IEnumerator enemyWalk()
    {
        yield return new WaitForSeconds(3);
        iCanMove = true;
    }

    bool IsPlayerInDetectionRange()
    {
        if (enemy_Chase.chasePlayer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void SetTargetPosition(Vector3 newTargetPosition)
    {
        targetPosition = newTargetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(iCanMove)
        {
            m_Material.color = Color.red;

            if (IsPlayerInDetectionRange())
            {
                //Get Data from Chase Line
                targetPlayer = GameObject.Find(enemy_Chase.playerName);
                tPlayer = targetPlayer.GetComponent<Transform>();

                if (!isTargetingPlayer && this.transform.parent.name == enemy_Chase.myName)
                {
                    isTargetingPlayer = true;
                    SetTargetPosition(tPlayer.position);
                }
                else
                {
                    SetTargetPosition(spawnPos);
                    if (isTargetingPlayer)
                    {
                        isTargetingPlayer = false;
                    }
                }
            }
            else
            {
                SetTargetPosition(spawnPos);
                if (isTargetingPlayer)
                {
                    isTargetingPlayer = false;
                }
            }

            goBack();
        }
    }

    private void goBack()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, targetPosition, 1 * Time.deltaTime);
    }
}
