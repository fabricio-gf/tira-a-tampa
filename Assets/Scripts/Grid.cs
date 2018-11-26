using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

	public static Grid instance;

	public int boardSizeX;
	public int boardSizeY;

	public Vector2Int playerPosition;
	public Vector2Int AIPosition;

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
		board[playerPosition.x, playerPosition.y] = true;
		board[AIPosition.x, AIPosition.y] = true;
	}

	public void UpdateBoard(bool isPlayer, int direction){

		if(!isPlayer){
			switch(direction){
			case 0:
				AIPosition += new Vector2Int(1, 0);
			break;
			case 1:
				AIPosition += new Vector2Int(0, -1);
			break;
			case 2:
				AIPosition += new Vector2Int(-1, 0);
			break;
			case 3:
				AIPosition += new Vector2Int(0, 1);
			break;
			default:
			break;
		}
		if((AIPosition.x < boardSizeX && AIPosition.x > -1) && (AIPosition.y < boardSizeY && AIPosition.y > -1)){
			board[AIPosition.x, AIPosition.y] = true;
		}
	}
		else{
			switch(direction){
				case 0:
					playerPosition += new Vector2Int(1, 0);
				break;
				case 1:
					playerPosition += new Vector2Int(0, -1);
				break;
				case 2:
					playerPosition += new Vector2Int(-1, 0);
				break;
				case 3:
					playerPosition += new Vector2Int(0, 1);
				break;
				default:
				break;
			}
			if((playerPosition.x < boardSizeX && playerPosition.x > -1) && (playerPosition.y < boardSizeY && playerPosition.y > -1)){
				board[playerPosition.x, playerPosition.y] = true;
			}
		}
	}
}
