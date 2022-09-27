using UnityEngine;

public class Camera : MonoBehaviour
{
    public PlayerBody player;

    private const float cameraHeight = 15f;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = player.transform.transform.position;
        mainCamera.transform.position = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z - cameraHeight);
    }
}
