using System.Collections.Generic;
using UnityEngine;

public class SpawnerLogic : MonoBehaviour
{

    public List<GameObject> SpawnableObjects;
    public bool canRespawn = false;
    public int respawnTimer = 30;

    private GameObject CurrentObject;
    private System.DateTime LastSpawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnItem();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentObject == null && canRespawn && LastSpawnTime.AddSeconds(respawnTimer) >= System.DateTime.Now)
        {
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        int randomValue = (int)((Random.value * 100) % SpawnableObjects.Count);
        CurrentObject = Object.Instantiate(SpawnableObjects[randomValue], gameObject.transform);
        LastSpawnTime = System.DateTime.Now;
    }
}
