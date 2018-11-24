using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {

	public enum Direction{
		UP,
		DOWN,
		LEFT,
		RIGHT
	}

	public Direction startingDirection;
	public float speed;
	public Color trailColor;

	Direction currentDirection = Direction.UP;
	Direction nextDirection;
	private Vector3 moveVector;
	private Vector3 nextPosition;

	void Start(){
		SetNextDirection(startingDirection);
		nextPosition = transform.position + moveVector;
	}

	// Update is called once per frame
	void FixedUpdate () {	
		if(Vector3.Distance(transform.position, nextPosition) <= 0.01){
			ChangeDirection(nextDirection);
			nextPosition = transform.position + moveVector;
		}
		transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed*Time.deltaTime);	
	}

	private void ChangeDirection(Direction dir){
		switch(dir){
			case Direction.UP:
				moveVector = new Vector3(0, 1, 0);
				currentDirection = Direction.UP;
			break;
			case Direction.DOWN:
				moveVector = new Vector3(0, -1, 0);
				currentDirection = Direction.DOWN;
			break;
			case Direction.LEFT:
				moveVector = new Vector3(-1, 0, 0);
				currentDirection = Direction.LEFT;
			break;
			case Direction.RIGHT:
				moveVector = new Vector3(1, 0, 0);
				currentDirection = Direction.RIGHT;
			break;
			default:
			break;
		}
	
	}

	public void SetNextDirection(Direction dir){
		if((int)currentDirection + (int)dir > 1 && (int)currentDirection + (int)dir < 5){
			nextDirection = dir;
		}
	}
}
