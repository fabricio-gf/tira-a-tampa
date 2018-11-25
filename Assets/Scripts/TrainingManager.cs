using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingManager : MonoBehaviour {

	private GeneticAlgorithm genAlg1;
	private GeneticAlgorithm genAlg2;

	private int popSize;
	private int dnaSize;
	private int numGen;
	private bool[,] board;
	public int firstPositionX;
	public int firstPositionY;
	public int secondPositionX;
	public int secondPositionY;
	public int boardSizeX;
	public int boardSizeY;
	public int losingPenalty;
	public int winningReward;
	private float mutationRate;

	public GameConfig config;

	public void StartTraining () {
		System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();

		popSize = config.population;
		dnaSize = config.genes;
		numGen = config.generations;
		mutationRate = config.mutation;
		
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
	
		List<int[]> pop2 = genAlg2.RunAlgorithm();

		

		stopwatch.Stop();
		print("Elapsed time: " + stopwatch.ElapsedMilliseconds);

		//agir 5 jogadas
		

		UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
	}

}
