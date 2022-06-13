using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btn_Play()
    {
        Application.LoadLevel("SampleScene");
    }

    public void btn_Exit()
    {
        Application.Quit();
    }
}
