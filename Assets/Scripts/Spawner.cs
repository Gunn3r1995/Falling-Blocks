using UnityEngine;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour {
        public GameObject fallingBlockPrefab;
        public Vector2 secondsBetweenSpawnsMinMax;
        float nextSpawnTime;

        public Vector2 spawnSizeMinMax;
        public float spawnAngleMax;

        Vector2 screenHalfWidthInWorldUnits;

        // Use this for initialization
        void Start () {
            screenHalfWidthInWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        }
	
        // Update is called once per frame
        void Update () {
            if (Time.time > nextSpawnTime) {
                float secondsBetweenSpawns = Mathf.Lerp (secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent ());
                nextSpawnTime = Time.time + secondsBetweenSpawns;

                float spawnAngle = Random.Range (-spawnAngleMax, spawnAngleMax);
                float spawnSize = Random.Range (spawnSizeMinMax.x, spawnSizeMinMax.y);
                Vector2 spawnPosition = new Vector2 (Random.Range (-screenHalfWidthInWorldUnits.x, screenHalfWidthInWorldUnits.x), screenHalfWidthInWorldUnits.y + spawnSize);

                GameObject fallingBlock = (GameObject)Instantiate (fallingBlockPrefab, spawnPosition, Quaternion.Euler (Vector3.forward * spawnAngle));
                fallingBlock.transform.localScale = Vector2.one * spawnSize;
                fallingBlock.transform.parent = transform;
            }
        }
    }
}
