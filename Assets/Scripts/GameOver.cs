using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameOver : MonoBehaviour {
        public GameObject gameOverScreen;
        public Text secondsSurvivedUI;
        bool gameOver;

        void Start() {
            FindObjectOfType<PlayerController> ().OnPlayerDeath += OnGameOver;	
        }

        // Update is called once per frame
        void Update () {
            if(gameOver) {
                if(Input.GetKeyDown (KeyCode.Space)){
                    SceneManager.LoadScene (0);
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Quitting Application");
                Application.Quit();
            }
        }

        void OnGameOver(){
            gameOverScreen.SetActive (true);
            secondsSurvivedUI.text = Mathf.RoundToInt (Time.timeSinceLevelLoad).ToString ();
            gameOver = true;
        }
    }
}
