using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {

	public enum Direction{
		RIGHT,
		UP,
		LEFT,
		DOWN
	}


	[Range(1,2)] public int playerNumber;
	public Direction startingDirection;
	[Range(1,10)] public float speed;
	public Color trailColor;
	public GameObject[] trailPrefab;

	public Transform dynamic;

	Direction currentDirection;
	Direction nextDirection;
	Direction previousDirection;
	private Vector3 moveVector;
	private Vector3 nextPosition;
	private GameObject previousWall;
	private bool isDead = false;

	void Awake(){
		previousDirection = startingDirection;
		currentDirection = startingDirection;
		SetNextDirection(startingDirection);
		nextPosition = transform.position + moveVector;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(isDead){
			return;
		}
		if(Vector3.Distance(transform.position, nextPosition) <= 0.01){
			MoveStep();
		}
		transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed*Time.deltaTime);	
	}

	private void MoveStep(){
		//define next direction
		ChangeDirection(nextDirection);
		nextPosition = transform.position + moveVector;
		
		//rotate
		transform.eulerAngles = new Vector3(0, 0, (int)nextDirection * 90);
		
		//spawn wall at curr position
		if(previousWall != null) previousWall.GetComponent<BoxCollider2D>().enabled = true;
		if(previousDirection == nextDirection){
			previousWall = Instantiate(trailPrefab[0], transform.position, Quaternion.identity, dynamic);
		}
		else if((int)nextDirection == ((int)previousDirection+1)%4){
			previousWall = Instantiate(trailPrefab[1], transform.position, Quaternion.identity, dynamic);
		}
		else if((int)nextDirection == ((int)previousDirection+3)%4){
			previousWall = Instantiate(trailPrefab[2], transform.position, Quaternion.identity, dynamic);
		}
		previousWall.GetComponent<SpriteRenderer>().color = trailColor;
		previousWall.transform.eulerAngles = new Vector3(0, 0, (int)nextDirection * 90);
	}
	
	private void ChangeDirection(Direction dir){
		previousDirection = currentDirection;
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
		if((int)currentDirection + (int)dir != 2 && (int)currentDirection + (int)dir != 4){
			nextDirection = dir;	
		}
		else{
			if(dir == Direction.UP || dir == Direction.LEFT){
				nextDirection = dir;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Wall" || col.tag == "Robot"){
			isDead = true;
		}
	}
}
