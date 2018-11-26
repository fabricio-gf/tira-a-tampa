using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public GameConfig config;
	public TrainingManager trainingManager;

	public Text speedText;
	public Text populationsText;
	public Text generationsText;
	public Text genesText;
	public Text mutationText;

	[Range(5,10)] public int baseSpeedValue;
	[Range(20,100)] public int basePopValue;
	[Range(50,500)] public int baseGenValue;
	[Range(5,10)] public int baseGenesValue;
	[Range(0,1)] public float baseMutValue;


	void Start(){
		ChangeSpeed(baseSpeedValue);
		ChangePopulation(basePopValue);
		ChangeGenerations(baseGenValue);
		ChangeGenes(baseGenesValue);
		ChangeMutation(baseMutValue);
	}

	public void StartGame(){
		// trainingManager.StartTraining();
		SceneManager.LoadScene("Game");
	}

	public void StartMultiplayer(){
		SceneManager.LoadScene("Multiplayer");
	}

	public void ChangeSpeed(float sp){
		config.speed = (int)sp;
		speedText.text = config.speed.ToString();
	}

	public void ChangePopulation(float pop){
		config.population = (int)pop;
		populationsText.text = config.population.ToString();
	}

	public void ChangeGenerations(float gen){
		config.generations = (int)gen;
		generationsText.text = config.generations.ToString();
	}

	public void ChangeGenes(float genes){
		config.genes = (int)genes;
		genesText.text = config.genes.ToString();
	}

	public void ChangeMutation(float mut){
		config.mutation = (float)System.Math.Round(mut,2);
		mutationText.text = config.mutation.ToString();
	}

	public void QuitGame(){
		Application.Quit();
	}
}
