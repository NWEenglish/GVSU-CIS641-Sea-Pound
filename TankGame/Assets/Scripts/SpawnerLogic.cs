using System.Collections.Generic;
using Assets.Scripts.Constants.Names;
using Assets.Scripts.Constants.Types;
using Assets.Scripts.GeneralGameLogic;
using UnityEngine;

public class SpawnerLogic : MonoBehaviour
{
    public List<GameObject> SpawnableObjects;

    private int RespawnTimer = 30;
    private bool RespawnAllowed;
    private GameObject CurrentObject;
    private System.DateTime LastAliveTime;

    private const int MinRespawnTimer = 10;

    void Start()
    {
        SetRespawnAllowed();
        SpawnItem();
    }

    void Update()
    {
        if (CurrentObject != null)
        {
            LastAliveTime = System.DateTime.Now;
        }
        else if (CurrentObject == null && RespawnAllowed && LastAliveTime.AddSeconds(RespawnTimer) <= System.DateTime.Now)
        {
            if (RespawnTimer > MinRespawnTimer)
            {
                RespawnTimer -= 2;
            }

            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        int randomValue = (int)((Random.value * 100) % SpawnableObjects.Count);
        CurrentObject = Object.Instantiate(SpawnableObjects[randomValue], gameObject.transform);
    }

    private void SetRespawnAllowed()
    {
        switch (GameObject.Find(ObjectNames.GameLogic).GetComponent<GameModeSetup>().GameMode)
        {
            case GameModeType.Defensive:
                RespawnAllowed = true;
                break;
            default:
                RespawnAllowed = false;
                break;
        }
    }
}
