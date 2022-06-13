using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_Players : MonoBehaviour
{
    public GameObject player;
    public Transform dummy;

    //Name Player
    public static int namePlayer = 0;
    public static int nameEnemy = 0;

    private void OnMouseDown() 
    {
        if(camera_Control.playerFirst)
        { 
            if(this.transform.parent.parent.name == "Player Place")
            {
                var pos = new Vector3();
                pos = dummy.position;
                pos.y = dummy.position.y + 2.5f;

                var playerObject = Instantiate(player, pos, Quaternion.identity);

                //Name Player Object
                namePlayer++;
                playerObject.gameObject.name = "Player" + namePlayer.ToString();

                camera_Control.playerFirst = false;
            }
        }
        else if(!camera_Control.playerFirst)
        {
            if(this.transform.parent.parent.name == "Enemy Place")
            {
                var pos = new Vector3();
                pos = dummy.position;
                pos.y = dummy.position.y + 2.5f;

                var playerObject = Instantiate(player, pos, Quaternion.identity);

                //Name Player Object
                nameEnemy++;
                playerObject.gameObject.name = "Enemy" + nameEnemy.ToString();

                camera_Control.playerFirst = true;
            }
        }
    }
}
