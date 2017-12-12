using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour {
        public float speed = 7;
        public event System.Action OnPlayerDeath;

        float screenHalfWidthInWorldUnits;

        // Use this for initialization
        void Start () {
            float halfPlayerWidth = transform.localScale.x / 2f;
            screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
        }
	
        // Update is called once per frame
        void Update () {
            float inputX = Input.GetAxisRaw ("Horizontal");
            float velocity = inputX * speed;
            transform.Translate (Vector2.right * velocity * Time.deltaTime);

            if (transform.position.x < -screenHalfWidthInWorldUnits) {
                transform.position = new Vector2 (screenHalfWidthInWorldUnits, transform.position.y);
            } else if (transform.position.x > screenHalfWidthInWorldUnits) {
                transform.position = new Vector2 (-screenHalfWidthInWorldUnits, transform.position.y);
            }
        }

        void OnTriggerEnter2D(Collider2D triggerCollider) {
            if(triggerCollider.gameObject.tag == "Falling Block") {
                if(OnPlayerDeath != null){
                    OnPlayerDeath ();
                }
                Destroy (gameObject);
            } else if (triggerCollider.gameObject.tag == "Untagged")
            {
                Debug.Log("Hit an object with an undefined tag");
            }
        }
    }
}
