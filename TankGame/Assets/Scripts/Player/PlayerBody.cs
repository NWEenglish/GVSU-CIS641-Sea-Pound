using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerBody : MonoBehaviour
    {
        private Rigidbody2D rigidbody_2D;

        private float HorizontalSpeed => Input.GetAxisRaw("Horizontal") * MovementHelper.acceleration;
        private float VerticalSpeed => Input.GetAxisRaw("Vertical") * MovementHelper.acceleration;

        // Start is called before the first frame update
        public void Start()
        {
            // Setup Rigidbody Object
            rigidbody_2D = gameObject.GetComponent<Rigidbody2D>();
        }

        // Updates is called at a fixed interval
        public void FixedUpdate()
        {
            // Moves player
            Vector2 movement = MovementHelper.Move(ref rigidbody_2D, HorizontalSpeed, VerticalSpeed);

            // Rotate player
            MovementHelper.Rotate(ref rigidbody_2D, movement, -90f);

            if (MovementHelper.IsOutOfBounds(gameObject))
            {
                gameObject.transform.position = new Vector3(0, 0, gameObject.transform.position.z);
            }
        }

        // Update is called once per frame
        public void Update()
        {
            
        }
    }
}
