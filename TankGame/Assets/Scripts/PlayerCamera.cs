using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public PlayerBody player;

    private const float cameraHeight = 15f;

    private PlayerCamera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<PlayerCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.transform.transform.position;
            mainCamera.transform.position = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z - cameraHeight);
        }

        // Player has died
        else
        {

        }
    }
}
