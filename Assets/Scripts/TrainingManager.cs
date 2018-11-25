using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingManager : MonoBehaviour {

	private GeneticAlgorithm genAlg1;
	private GeneticAlgorithm genAlg2;

	public int popSize;
	public int dnaSize;
	public int numGen;
	public bool[,] board;
	public int firstPositionX;
	public int firstPositionY;
	public int secondPositionX;
	public int secondPositionY;
	public int boardSizeX;
	public int boardSizeY;
	public int losingPenalty;
	public int winningReward;
	public float mutationRate;

	// Use this for initialization
	void Start () {
		System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
		
		board = new bool[boardSizeX, boardSizeY];
		for(int i = 0; i < boardSizeX; i++){
			for(int j = 0; j < boardSizeY; j++){
				board[i,j] = false;
			}
		}
		
		int seed1;
		int seed2;
		

		seed1 = Random.Range(0,100);
		genAlg1 = new GeneticAlgorithm(popSize, dnaSize, numGen, board, firstPositionX, firstPositionY, secondPositionX, secondPositionY, boardSizeX, boardSizeY, winningReward, losingPenalty, seed1, mutationRate);
		do{seed2 = Random.Range(0,100);}while(seed2 == seed1);
		genAlg2 = new GeneticAlgorithm(popSize, dnaSize, numGen, board, secondPositionX, secondPositionY, firstPositionX, firstPositionY, boardSizeX, boardSizeY, winningReward, losingPenalty, seed2, mutationRate);	
		
		List<int[]> pop1 = genAlg1.RunAlgorithm();
	
		// Debug.Log("pop2");
		List<int[]> pop2 = genAlg2.RunAlgorithm();

		
		// Debug.Log("GEN 1 ALG :");
		// for(int i = 0; i < pop1.Count; i++){
		// 	Debug.Log("ind "+ i);
		// 	for(int j = 0; j < pop1[i].Length; j++){
		// 		Debug.Log("gene " + j + " " + pop1[i][j]);
		// 	}
		// }
		
		// Debug.Log("GEN 2 ALG :");
		// for(int i = 0; i < pop2.Count; i++){
		// 	Debug.Log("ind " + i);
		// 	for(int j = 0; j < pop2[i].Length; j++){
		// 		Debug.Log("gene " + j + " " + pop2[i][j]);
		// 	}
		// }

		//System.Threading.Thread.Sleep(500);
		stopwatch.Stop();
		print("Elapsed time: " + stopwatch.ElapsedMilliseconds);

		//agir 5 jogadas
		
	}

}
