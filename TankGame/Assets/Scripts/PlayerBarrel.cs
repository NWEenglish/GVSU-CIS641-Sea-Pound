using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrel : MonoBehaviour
{
    public Vector3 cursorPosition; // hide later

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        cursorPosition = Input.mousePosition;

    }

    // Update is called once per frame
    void Update() { }
}
