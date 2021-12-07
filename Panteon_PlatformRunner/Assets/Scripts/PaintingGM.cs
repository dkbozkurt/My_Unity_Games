// Dogukan Kaan Bozkurt
// github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingGM : MonoBehaviour
{
    #region Variables
    // GameObject's components
    [SerializeField] private Animator cameraAnim;
    [SerializeField] private GameObject paintingBoard;

    [SerializeField] private GameObject[] whiteCube;

    [SerializeField] private Material orgMaterial;

    private int total;
    private int dyedColor;
    #endregion

    #region Scripts
    [SerializeField] private ScoreSystem scoreSys;
    #endregion

    void Start()
    {
        // Camera Animation
        cameraAnim.enabled = true;

        // Board becoming visible
        paintingBoard.SetActive(true);

        // Total number of Cubes
        total = whiteCube.Length;

        // Total number of dyed cubes
        dyedColor = 0;

        // Changing board's color to white
        for (int i = 0; i < total; i++)
        {
            Material instantColor= whiteCube[i].GetComponent<Renderer>().material;

            instantColor = orgMaterial;
            
        }       
        
    }

    public int getDyedColorPercentage()
    {
        return ((dyedColor*100)/total);
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // If raycast returns true do inside of the if clause
        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();

            // If focused cube's color didnt changed change the color and increase the number of dyed cubes
            if(selectionRenderer != null && selectionRenderer.material.color==orgMaterial.color && Input.GetMouseButton(0))
            {
                selectionRenderer.material.color = Color.red;
                dyedColor++;

                //Debug.Log("dyedcolor:" + dyedColor);

                // Percentage sends to score system script to display the score.
                scoreSys.ChangeScore(getDyedColorPercentage());

                // If All the wall painted end the game
                if (dyedColor == total)
                {
                    scoreSys.endTheGame();
                    //sound
                }
            }
        }       
        
    }
}
