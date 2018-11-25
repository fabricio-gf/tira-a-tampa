using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

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
	}

	public void EndGame(int deadPlayer){
		endWindow.SetActive(true);
		deadPlayers++;
		if(deadPlayers > 1){
			endText.text = "EMPATE!";
		}
		else{
			switch(deadPlayer){
			case 1:
				endText.text = "TIRA A TAMPA!";
				ai.GetComponent<Robot>().ToggleDead();
			break;
			case 2:
				endText.text = "You won!";
				player.GetComponent<Robot>().ToggleDead();
			break;
			default:
			break;
			}
		}
		gameEnded = true;
	}

	public void PlayAgain(){
		SceneManager.LoadScene("Game");
	}

	public void BackToMenu(){
		SceneManager.LoadScene("Menu");
	}
}
