using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

	public static Grid instance;

	public int boardSizeX;
	public int boardSizeY;

	public Vector2Int[] positions;

	// public Vector2Int playerPosition;
	// public Vector2Int AIPosition;

	public bool[,] board;

	void Awake(){
		if(instance == null){
			instance = this;
		}
		else if(instance != this){
			Destroy(gameObject);
		}

		board = new bool[boardSizeX, boardSizeY];
		for(int i = 0; i < boardSizeX; i++){
			for(int j = 0; j < boardSizeY; j++){
				if(i == 0 || i == boardSizeX-1 || j == 0 || j == boardSizeY){
					board[i, j] = true;
				}
				else{
					board[i,j] = false;
				}
			}
		}
		for(int i = 0; i < boardSizeX; i++)
		board[positions[0].x, positions[0].y] = true;
		board[positions[1].x, positions[1].y] = true;
	}

	public void UpdateBoard(bool isPlayer, int direction){
		// print("is player " + isPlayer + " direction " + direction);
		// Debug.Break();
		if(!isPlayer){
			switch(direction){
				case 0:
					positions[1] += new Vector2Int(1, 0);
				break;
				case 1:
					positions[1] += new Vector2Int(0, -1);
				break;
				case 2:
					positions[1] += new Vector2Int(-1, 0);
				break;
				case 3:
					positions[1] += new Vector2Int(0, 1);
				break;
				default:
				break;
			}
			if((positions[1].x < boardSizeX && positions[1].x > -1) && (positions[1].y < boardSizeY && positions[1].y > -1)){
				board[positions[1].x, positions[1].y] = true;
			}
		}
		else{
			switch(direction){
				case 0:
					positions[0] += new Vector2Int(1, 0);
				break;
				case 1:
					positions[0] += new Vector2Int(0, -1);
				break;
				case 2:
					positions[0] += new Vector2Int(-1, 0);
				break;
				case 3:
					positions[0] += new Vector2Int(0, 1);
				break;
				default:
				break;
			}
			if((positions[0].x < boardSizeX && positions[0].x > -1) && (positions[0].y < boardSizeY && positions[0].y > -1)){
				board[positions[0].x, positions[0].y] = true;
			}
		}
	}
}
