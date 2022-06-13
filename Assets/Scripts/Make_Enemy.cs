using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_Enemy : MonoBehaviour
{
    public GameObject enemy;
    public Transform dummy;

    private void OnMouseDown() 
    {
        var pos = dummy.position;
        pos.y = dummy.position.y + 2f;
        
        Instantiate(enemy, pos, Quaternion.identity);
    }
}
