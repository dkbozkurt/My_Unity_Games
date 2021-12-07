// Dogukan Kaan Bozkurt
// github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QueuePvsOpp : MonoBehaviour
{
    #region Variables
    // Players order in the game
    private int order;

    // Componenets
    [SerializeField] private Animator scoreIncrease;
    [SerializeField] private TMP_Text orderText;
    #endregion

    #region Scripts


    #endregion

    void Start()
    {
        // Player is heading at the beginning
        order = 1;
    }
    void Update()
    {
        // Check the queue everytime
        orderText.text = "  " + getOrder().ToString() + " /11";
    }

    // Player order change
    public void setOrder(int num)
    {
        order=order+num;              
    }

    // Returns the order value
    public int getOrder()
    {
        return order;
    }

    // When order has changed, anim will display
    public void orderChangeAnim(bool state)
    {
        scoreIncrease.SetBool("increase", state);
    }
}
