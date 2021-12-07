// Dogukan Kaan Bozkurt
//      github.com/dkbozkurt
//IceCreamDEMO

/* Ice cream filling script.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamFilling : MonoBehaviour
{
    #region Scripts
    [SerializeField] private ScoreCalculator scoreSys;
    [SerializeField] private ProgressBar progressB;
    #endregion

    #region Arrays
    [SerializeField] private GameObject[] creamLayer;
    private int[] inputCream = new int [50];
    private int[] groundtr = new int[50];
    #endregion

    #region Current State variables
    private Renderer currentLayerRend;
    private int currentLayer;
    #endregion

    [SerializeField] private GameObject progressBarMask;
    void Start()
    {
        Debug.Log("Start called!");
        currentLayer=0;
    }

    #region Get&Set Functions
    public void setCurrentLayer(int x) { currentLayer = x; }
    public int getCurrentLayer() { return currentLayer; }
    public int[] getinputCream() { return inputCream;}
    public int[] getGroundTruthScene1() { return groundtr; }
    #endregion

    public void Fill(Material flavor,int label)
    {
        //Debug.Log("Current Layer = " + currentLayer);
        //
        inputCream[currentLayer] = label;
        //
        progressBarMask.SetActive(true);
        progressB.increaseCurrent();
        progressB.GetCurrentFill();
        //
        creamLayer[currentLayer].SetActive(true);
        currentLayerRend = creamLayer[currentLayer].GetComponent<Renderer>();
        currentLayerRend.material.color = flavor.color;
        //
        MatchCalculator(currentLayer);
        //
        currentLayer ++;        
    }

    public void MatchCalculator(int layer)
    {
        if(inputCream[layer] == groundtr[layer])
        {
            scoreSys.setCorrects();
        }

    }

    public void ResCream()
    {
        for (int _layer = 0;_layer<50;_layer++)
        {
            inputCream[_layer] = -1;
            creamLayer[_layer].SetActive(false);
        }
    }
    public void groundTruthScene(int SceneNUM)
    {
        if(SceneNUM==1)
        {
            for (int i = 0; i < 50; i++)
            {
                if (i < 25)
                    groundtr[i] = 0;
                else
                    groundtr[i] = 1;
            }
        }
        else if (SceneNUM == 2)
        {
            for (int i = 0; i < 50; i++)
            {
                if (i < 15)
                    groundtr[i] = 1;
                else if (i < 20)
                    groundtr[i] = 0;
                else if (i < 30)
                    groundtr[i] = 1;
                else if (i < 35)
                    groundtr[i] = 0;
                else
                    groundtr[i] = 1;
            }
        }
        
        
    }

}
