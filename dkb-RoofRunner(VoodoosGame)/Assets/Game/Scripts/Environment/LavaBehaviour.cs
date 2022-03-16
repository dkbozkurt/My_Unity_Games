using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using UnityEngine;
using DG.Tweening;

public class LavaBehaviour : MonoBehaviour
{
    private bool _piecesDropable;

    private void Start()
    {
        _piecesDropable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.TryGetComponent(out PipeStacker pipeStacker))
            {
                PiecesDrop();
            }
        }
    }

    private void PiecesDrop()
    {
        if (PipeStacker.rightPipes.Count > 0 && PipeStacker.leftPipes.Count > 0)
        {
            Destroyer(PipeStacker.rightPipes,PipeStacker.rightPipes.Count-1);
            Destroyer(PipeStacker.leftPipes,PipeStacker.leftPipes.Count-1);
        }
        
        else if (PipeStacker.rightPipes.Count > 0 && PipeStacker.leftPipes.Count < 0)
        {
            Destroyer(PipeStacker.rightPipes,PipeStacker.rightPipes.Count-1);
            Destroyer(PipeStacker.rightPipes,0);
        }
        
        else if (PipeStacker.rightPipes.Count < 0 && PipeStacker.leftPipes.Count > 0)
        {
            Destroyer(PipeStacker.leftPipes,PipeStacker.leftPipes.Count-1);
            Destroyer(PipeStacker.leftPipes,0);
        }
        
        else
        {
            _piecesDropable = false;
        }
        
        if (_piecesDropable)
        {
            WaitForTime(0.1f);
        }
        else
        {
            GameObject.FindWithTag("SlidePipe").GetComponent<SliderPipeBehaviour>().ChangeSliderPipeLenght();
        }
    }

    private void WaitForTime(float t)
    {

        StartCoroutine(Do());
        IEnumerator Do()
        {
            yield return new WaitForSeconds(t);
            _piecesDropable= false;
            PiecesDrop();
        }
    }
    
    private void Destroyer(List<GameObject> gameObjectList,int index)
    {
        gameObjectList[index].transform.SetParent(null);
        gameObjectList[index].GetComponent<Collider>().isTrigger = false;
        gameObjectList[index].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        gameObjectList[index].GetComponent<Rigidbody>().AddForce(-transform.forward * 250f);
        Destroy(gameObjectList[index],2f);
        gameObjectList.RemoveAt(index);
        
        GameObject.FindWithTag("Player").GetComponent<PipeStacker>().ReLocateMainPipe();
    }

    
}
