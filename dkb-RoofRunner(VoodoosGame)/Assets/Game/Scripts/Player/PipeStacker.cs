using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeStacker : MonoBehaviour
{
    [SerializeField] private GameObject pipeCollection;
    
    private int _pipeIndex;

    public static List<GameObject> rightPipes = new List<GameObject>();
    public static List<GameObject> leftPipes = new List<GameObject>();
    
    private void Awake()
    {
        rightPipes.Clear();
        leftPipes.Clear();
    }

    private void Start()
    {
        _pipeIndex = 0; 

        rightPipes.Add(pipeCollection.transform.GetChild(0).gameObject);
        rightPipes[0].GetComponent<CollectableObject>().PipeSide = PipeDirection.Right;
        
        leftPipes.Add(pipeCollection.transform.GetChild(1).gameObject);
        leftPipes[0].GetComponent<CollectableObject>().PipeSide = PipeDirection.Left;
        
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pipe")
        {
            if (other.gameObject.TryGetComponent(out CollectableObject collectableObject))
            {
                if (!collectableObject.IsCollected)
                {
                    
                    UpdateMainPipe(other, collectableObject,PipeDirection.Right);
                
                    var cloneGameObject = Instantiate(other.gameObject);
                    UpdateMainPipe(cloneGameObject.GetComponent<Collider>(), 
                        cloneGameObject.GetComponent<CollectableObject>(),
                        PipeDirection.Left);
                    
                    transform.GetChild(1).gameObject.GetComponent<SliderPipeBehaviour>().ChangeSliderPipeLenght();
                }
            }
        }
    }

    private void UpdateMainPipe(Collider other, CollectableObject collectableObject,PipeDirection group)
    {
        other.gameObject.transform.parent = pipeCollection.transform;
        collectableObject.IsCollected = true;
        
        if (group == PipeDirection.Right)
        {
            _pipeIndex = rightPipes.Count ;
            collectableObject.Index = _pipeIndex;            
            rightPipes.Add(other.gameObject);   
            collectableObject.PipeSide = PipeDirection.Right;
            collectableObject.LocateCollectableObject(1);
            DoPipeScale(rightPipes);
        }
        else if (group == PipeDirection.Left)
        {
            _pipeIndex = leftPipes.Count ;
            collectableObject.Index = _pipeIndex;
            leftPipes.Add(other.gameObject);
            collectableObject.PipeSide = PipeDirection.Left;
            collectableObject.LocateCollectableObject(-1);
            DoPipeScale(leftPipes);
        }
        
    }

    public void DoPipeScale(List<GameObject> _pipeList)
    {
        var sequence = DOTween.Sequence();
        
        foreach (GameObject child in _pipeList)
        {
            sequence.Append(child.transform.DOScaleX(0.45f, 0.1f).OnComplete(() =>
            {
                child.transform.DOScaleX(0.3f, 0.1f);
            }));
        }
       
        // Sound;
    }

    public void ReLocateMainPipe()
    {

        float rightCornerPosition =rightPipes[rightPipes.Count - 1].transform.localPosition.x;
        float leftCornerPosition = leftPipes[leftPipes.Count - 1].transform.localPosition.x;

        pipeCollection.transform.DOLocalMoveX((-1 * ((rightCornerPosition + leftCornerPosition) / 2)), 2f);
        
    }

    public void Die()
    {
        GetComponentInChildren<ParticleSystem>().Play();
        GetComponent<SwerveMovement>().enabled = false;
        
        foreach (Transform child in pipeCollection.transform)
        {
            child.SetParent(null);
            //child.gameObject.GetComponent<Collider>().isTrigger = false;
            child.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            child.gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * 300f);
        }
        
        transform.GetChild(0).GetComponent<PlayerModelAnimBehaviour>().DieAnimation();
        Invoke("ReSwapn",0.5f);
        
    }

    private void ReSwapn()
    {
        // transform.position= Vector3.zero;
        // GetComponent<SwerveMovement>().enabled = false;
        // GetComponent<SwerveMovement>().ForwardSpeed= 5f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
