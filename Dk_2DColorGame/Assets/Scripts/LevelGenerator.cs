//Dogukan Kaan Bozkurt
//Dk_2DColorGame

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform levelPart_1;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPoint").position;
        SpawnLevelPart();
        SpawnLevelPart();
        SpawnLevelPart();
        SpawnLevelPart();
        SpawnLevelPart();
    }

    private void Update()
    {
        if (Obs_Cleaner.obs_check == true)
        {
            SpawnLevelPart();
            SpawnLevelPart();
            Obs_Cleaner.obs_check = false;
        }
       
    }
    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart_1, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

    public void SpawnLevelPart()
    {
        Transform lastLevelPartTransform =  SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPoint").position;
    }
}
