using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public GameConfig config;

	public Text speedText;
	public Text populationsText;
	public Text difficultyText;

	[Range(1,10)] public int baseSpeedValue;
	[Range(10,50)] public int basePopValue;
	[Range(1,3)] public int baseDiffValue;

	void Start(){
		ChangeSpeed(baseSpeedValue);
		ChangePopulation(basePopValue);
		ChangeDifficulty(baseDiffValue);
	}

	public void StartGame(){
		SceneManager.LoadScene("Game");
	}

	public void ChangeSpeed(float sp){
		config.speed = (int)sp;
		speedText.text = config.speed.ToString();
	}

	public void ChangePopulation(float sp){
		config.populations = (int)sp;
		populationsText.text = config.populations.ToString();
	}

	public void ChangeDifficulty(float sp){
		config.difficulty = (int)sp;
		difficultyText.text = config.difficulty.ToString();
	}
}
