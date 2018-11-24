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


	[Range(1,2)] public int playerNumber;
	public Direction startingDirection;
	[Range(1,10)] public float speed;
	public Color trailColor;
	public GameObject trailPrefab;

	Direction currentDirection = Direction.UP;
	Direction nextDirection;
	private Vector3 moveVector;
	private Vector3 nextPosition;
	private GameObject previousWall;
	private bool isDead = false;

	void Start(){
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
		ChangeDirection(nextDirection);
		nextPosition = transform.position + moveVector;
		if(previousWall != null) previousWall.GetComponent<BoxCollider2D>().enabled = true;
		previousWall = Instantiate(trailPrefab, transform.position, Quaternion.identity);
		previousWall.GetComponent<SpriteRenderer>().color = trailColor;
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

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Wall" || col.tag == "Robot"){
			isDead = true;
		}
	}
}
