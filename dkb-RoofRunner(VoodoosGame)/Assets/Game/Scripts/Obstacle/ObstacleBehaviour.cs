using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    private bool _isCollided;
    public bool deactivateAnims;
    
    private void Start()
    {
        _isCollided = false;
        deactivateAnims = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pipe" && !_isCollided)
        {
            if (other.TryGetComponent(out CollectableObject collectableObject))
            {
                BreakPipeFromIndex(other, collectableObject);
                deactivateAnims = true;
            }
        }

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PipeStacker>().Die();
            deactivateAnims = true;
        }
        
    }

    private void BreakPipeFromIndex(Collider other,CollectableObject collectableObject)
    {
        if (collectableObject.PipeSide == PipeDirection.Right)
        {
            if (other.transform.position.x - GameObject.FindWithTag("Player").gameObject.transform.position.x >= 0f)
            {
                for (int i = PipeStacker.rightPipes.Count-1; i > collectableObject.Index; i--)
                {
                    Destroyer(PipeStacker.rightPipes, i);
                }
            }
            else
            {
                for (int i = collectableObject.Index; i >= 0; i--)
                {
                    Destroyer(PipeStacker.rightPipes, i);
                }

                for (int i = PipeStacker.leftPipes.Count-1; i >= 0; i--)
                {
                    Destroyer(PipeStacker.leftPipes, i);
                }
            }
        }
       
        else if (collectableObject.PipeSide == PipeDirection.Left)
        {
            if (other.transform.position.x - GameObject.FindWithTag("Player").gameObject.transform.position.x > 0f)
            {
                for (int i = collectableObject.Index; i >= 0; i--)
                {
                    Destroyer(PipeStacker.leftPipes, i);
                }

                for (int i = PipeStacker.rightPipes.Count-1; i >= 0; i--)
                {
                    Destroyer(PipeStacker.rightPipes, i);
                }
                
            }
            else
            {
                for (int i = PipeStacker.leftPipes.Count-1; i > collectableObject.Index; i--)
                {
                    Destroyer(PipeStacker.leftPipes, i);
                }
            }
        }
        GameObject.FindWithTag("SlidePipe").GetComponent<SliderPipeBehaviour>().ChangeSliderPipeLenght();
        // Debug.Log("PipeStacker.rightPipes[i] " + PipeStacker.rightPipes.Count +"\nPipeStacker.leftPipes[i] " + PipeStacker.leftPipes.Count );
        
    }
    
    private void Destroyer(List<GameObject> gameObjectList,int index)
    {
        gameObjectList[index].transform.SetParent(null);
        gameObjectList[index].GetComponent<Collider>().isTrigger = false;
        gameObjectList[index].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        gameObjectList[index].GetComponent<Rigidbody>().AddForce(-transform.forward * 300f);
        Destroy(gameObjectList[index],2f);
        gameObjectList.RemoveAt(index);
        
        GameObject.FindWithTag("Player").GetComponent<PipeStacker>().ReLocateMainPipe();
    }
    
    
}
