using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public KeyCode quitKey;
	public KeyCode restartKey;

	public GameConfig config;

	public GameObject player;
	public GameObject ai;

	public Text endText;
	public GameObject endWindow;
	private int deadPlayers = 0;

	private bool gameEnded = false;

	void Awake(){
		if(instance == null){
			instance = this;
		}
		else{
			Destroy(gameObject);
		}

		//define valores da IA
		player.GetComponent<Robot>().speed = config.speed;
		ai.GetComponent<Robot>().speed = config.speed;
	}

	void Update(){
		if(gameEnded && Input.GetKeyDown(restartKey)){
			PlayAgain();
		}
		else if(gameEnded && Input.GetKeyDown(quitKey)){
			BackToMenu();
		}
	}

	public void EndGame(int deadPlayer){
		ai.GetComponent<AIController>().gameOver = true;
		endWindow.SetActive(true);
		deadPlayers++;
		if(deadPlayers > 1){
			endText.text = "EMPATE!";
		}
		else{
			switch(deadPlayer){
			case 1:
				if(SceneManager.GetActiveScene().name == "Game"){
					endText.text = "TIRA A TAMPA!";
				}
				else{
					endText.text = "Player 2 won!";
				}
				ai.GetComponent<Robot>().ToggleDead();
			break;
			case 2:
				if(SceneManager.GetActiveScene().name == "Game"){
					endText.text = "PARABÉNS FERA!";
				}
				else{
					endText.text = "Player 1 won!";
				}
				player.GetComponent<Robot>().ToggleDead();
			break;
			default:
			break;
			}
		}
		gameEnded = true;
	}

	public void PlayAgain(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void BackToMenu(){
		SceneManager.LoadScene("Menu");
	}
}
