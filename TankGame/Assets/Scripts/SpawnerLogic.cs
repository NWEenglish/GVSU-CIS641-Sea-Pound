using System.Collections.Generic;
using UnityEngine;

public class SpawnerLogic : MonoBehaviour
{

    public List<GameObject> SpawnableObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        int randomValue = (int)((Random.value * 100) % SpawnableObjects.Count);
        Object.Instantiate(SpawnableObjects[randomValue], gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
