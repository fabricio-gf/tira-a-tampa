using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

	public TrainingManager trainingManager;
	public Robot robot;
	[HideInInspector] public bool gameOver = false;

	private List<int[]> individuals;
	private int index = 0;

	// Use this for initialization
	void Start () {
		individuals = trainingManager.StartTraining(Grid.instance.board, Grid.instance.AIPosition.x, Grid.instance.AIPosition.y, Grid.instance.playerPosition.x, Grid.instance.playerPosition.y, Grid.instance.boardSizeX, Grid.instance.boardSizeY);
	}
	
	// Update is called once per frame
	void Update () {

		if(!gameOver && robot.canMove == false){
			//calculate fitness
			robot.SetNextDirection((Robot.Direction)individuals[0][index]);
			Grid.instance.UpdateBoard(false, individuals[0][index]);
			robot.canMove = true;
			index++;
			if(index == individuals[0].Length-1){
				individuals = trainingManager.RetrainAlgorithm(Grid.instance.board, Grid.instance.AIPosition.x, Grid.instance.AIPosition.y, Grid.instance.playerPosition.x, Grid.instance.playerPosition.y);
				index = 0;
			}
		}
	}
}
