using System.Collections.Generic;
using UnityEngine;

public class SpawnerLogic : MonoBehaviour
{

    public List<GameObject> SpawnableObjects;
    public bool canRespawn = false;
    public int respawnTimer = 30;

    private GameObject CurrentObject;
    private System.DateTime LastAliveTime;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnItem();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentObject != null)
        {
            LastAliveTime = System.DateTime.Now;
        }
        else if (CurrentObject == null && canRespawn && LastAliveTime.AddSeconds(respawnTimer) <= System.DateTime.Now)
        {
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        int randomValue = (int)((Random.value * 100) % SpawnableObjects.Count);
        CurrentObject = Object.Instantiate(SpawnableObjects[randomValue], gameObject.transform);
    }
}
