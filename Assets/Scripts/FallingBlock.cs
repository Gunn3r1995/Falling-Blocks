using UnityEngine;

namespace Assets.Scripts
{
    public class FallingBlock : MonoBehaviour {
        public Vector2 speedMinMax;
        float speed;
        public bool localTranslationOn;

        float visibleHeightThreshold;

        void Start() {
            speed = Mathf.Lerp (speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent ());
            visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
        }

        void Update () {
            if (localTranslationOn) {
                transform.Translate (Vector2.down * speed * Time.deltaTime, Space.Self);
            } else {
                transform.Translate (Vector2.down * speed * Time.deltaTime, Space.World);
            }

            if(transform.position.y < visibleHeightThreshold) {
                Destroy (gameObject);
            }
        }


    }
}
