using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Robot robot;

	public KeyCode upKey;
	public KeyCode downKey;
	public KeyCode leftKey;
	public KeyCode rightKey;

	void Awake(){
		robot = GetComponent<Robot>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(upKey)){
			robot.SetNextDirection(Robot.Direction.UP);
		}
		else if(Input.GetKeyDown(downKey)){
			robot.SetNextDirection(Robot.Direction.DOWN);
		}
		else if(Input.GetKeyDown(leftKey)){
			robot.SetNextDirection(Robot.Direction.LEFT);
		}
		else if(Input.GetKeyDown(rightKey)){
			robot.SetNextDirection(Robot.Direction.RIGHT);
		}
	}
}
