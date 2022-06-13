using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camera_Control : MonoBehaviour
{
    public GameObject table_Play;
    
    //Global Text
    public Text txtTurn;
    public Text txtTimer;
    public Text txtScore;

    //Global Public Static
    public static bool playerFirst;
    public static int turnReal;
    public static float timerReal;
    public static int scoreEnemy;
    public static int scorePlayer;
    public static int scoreDraw;

    // Start is called before the first frame update
    void Start()
    {
        //Score
        scoreDraw = 0;
        scoreEnemy = 0;
        scorePlayer = 0;

        //Turn
        playerFirst = true;

        //Timer
        timerReal = 140;

        MeshRenderer m_Table_Play = table_Play.GetComponent<MeshRenderer>();

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = m_Table_Play.bounds.size.x / m_Table_Play.bounds.size.y;

        if(screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = m_Table_Play.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = m_Table_Play.bounds.size.y / 2 * differenceInSize;
        }
    }

    private void Update() 
    {
        //Turn
        if(playerFirst)
        {
            txtTurn.text = "Player Turn";
        }
        else if(!playerFirst)
        {
            txtTurn.text = "Enemy Turn";
        }

        //Timer
        timerReal -= Time.deltaTime;
        txtTimer.text = "Time : " + timerReal;

        //Score
        txtScore.text = "Player : " + scorePlayer + " Enemy : " + scoreEnemy;

        if(timerReal <= 0)
        {
            scoreDraw++;
            restartGame();
        }

        if(scoreEnemy + scorePlayer + scoreDraw >= 5)
        {
            if(scoreEnemy > scorePlayer)
            {
                //Game Over
            }
            else if(scorePlayer > scoreEnemy)
            {
                //Player Win
            }
        }

        DontDestroyOnLoad(scoreEnemy);
    }

    public void restartGame()
    {
        //Timer
        timerReal = 140;
        
        //Turn
        playerFirst = true;
    }
}
