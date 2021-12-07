using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("PlayScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
