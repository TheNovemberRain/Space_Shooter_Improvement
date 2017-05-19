using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spownWait;
	public float startWait;
	public float waitWave;

	public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	private int score;
	private bool gameOver;
	private bool restart;

	void Start(){
		StartCoroutine(SpawnWaves ());
		score = 0;
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
		UpdateScore ();
	}

	void Update(){
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);

		while (true) {
			for (int i = 0; i <= hazardCount; i++) {
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];

				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y, spawnValues.z);

				Quaternion spawnRotation = new Quaternion();
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spownWait);
			}
			yield return new WaitForSeconds (Random.Range(waitWave - 3.0f, waitWave));

			if (gameOver) {
				restartText.text = "Press 'R' for restart";
				restart = true;
				break;
			}
		}
	}
		

	void UpdateScore(){
		scoreText.text= "SCORE: " + score.ToString ();
	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}

	public void GameOver(){
		gameOverText.text = "YOU DIE!";
		gameOver = true;
	}
}
