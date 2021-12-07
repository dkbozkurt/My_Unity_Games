using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public delegate void EndGame();

    public static event EndGame endgame;






    void PlayerDiedFinishGame()
    {
        if (endgame != null)
            endgame();
            Destroy(gameObject);
        
    }

    private void OnTriggerEnter2D(Collider2D hedef)
    {
        if (hedef.tag == "EngelTemizleyici")
        {
            PlayerDiedFinishGame();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
