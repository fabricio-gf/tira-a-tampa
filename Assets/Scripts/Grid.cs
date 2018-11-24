using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

	public Grid instance;

	public int gridSizeX;
	public int gridSizeY;

	public bool[,] grid;

	void Awake(){
		if(instance == null){
			instance = this;
		}
		else{
			Destroy(gameObject);
		}
		
		grid = new bool[gridSizeX, gridSizeY];
	}
}
