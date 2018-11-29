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
		individuals = trainingManager.StartTraining(Grid.instance.board, Grid.instance.positions[robot.playerNumber-1].x, Grid.instance.positions[robot.playerNumber-1].y, Grid.instance.positions[2-robot.playerNumber].x, Grid.instance.positions[2-robot.playerNumber].y, Grid.instance.boardSizeX, Grid.instance.boardSizeY);
	}
	
	// Update is called once per frame
	void Update () {

		if(!gameOver && robot.canMove == false){
			//calculate fitness
			robot.SetNextDirection((Robot.Direction)individuals[0][index]);
			Grid.instance.UpdateBoard(robot.isPlayer, individuals[0][index]);
			robot.canMove = true;
			index++;
			if(index == individuals[0].Length-1){
				individuals = trainingManager.RetrainAlgorithm(Grid.instance.board, Grid.instance.positions[robot.playerNumber-1].x, Grid.instance.positions[robot.playerNumber-1].y, Grid.instance.positions[2-robot.playerNumber].x, Grid.instance.positions[2-robot.playerNumber].y);
				index = 0;
			}
		}
	}
}
