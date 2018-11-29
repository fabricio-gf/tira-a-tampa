using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingManager : MonoBehaviour {

	private GeneticAlgorithm genAlg1;
	// private GeneticAlgorithm genAlg2;

	private int popSize;
	private int dnaSize;
	private int numGen;
	private bool[,] board;
	private int firstPositionX;
	private int firstPositionY;
	private int secondPositionX;
	private int secondPositionY;
	private int boardSizeX;
	private int boardSizeY;
	public int losingPenalty;
	public int winningReward;
	private float mutationRate;

	public GameConfig config;
	private int seed1;

	public List<int[]> StartTraining (bool[,] newBoard, int fPosX, int fPosY, int sPosX, int sPosY, int bSizeX, int bSizeY) {
		System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();

		popSize = config.population;
		dnaSize = config.genes;
		numGen = config.generations;
		mutationRate = config.mutation;
		
		board = newBoard;
		boardSizeX = bSizeX;
		boardSizeY = bSizeY;

		firstPositionX = fPosX;
		firstPositionY = fPosY;
		secondPositionX = sPosX;
		secondPositionY = sPosY;

		// board = new bool[boardSizeX, boardSizeY];
		// for(int i = 0; i < boardSizeX; i++){
		// 	for(int j = 0; j < boardSizeY; j++){
		// 		board[i,j] = false;
		// 	}
		// }
		
		// int seed2;
		

		seed1 = Random.Range(0,100);
		genAlg1 = new GeneticAlgorithm(popSize, dnaSize, numGen, board, firstPositionX, firstPositionY, secondPositionX, secondPositionY, boardSizeX, boardSizeY, winningReward, losingPenalty, seed1, mutationRate, config.Voronoi);
		// do{seed2 = Random.Range(0,100);}while(seed2 == seed1);
		// genAlg2 = new GeneticAlgorithm(popSize, dnaSize, numGen, board, secondPositionX, secondPositionY, firstPositionX, firstPositionY, boardSizeX, boardSizeY, winningReward, losingPenalty, seed2, mutationRate);	
		
		List<int[]> pop1 = genAlg1.RunAlgorithm();
		string str = "";
		for(int i = 0; i < pop1.Count; i++){
			str += pop1[0][i].ToString() + " ";
		}
		print(str);
	
		// List<int[]> pop2 = genAlg2.RunAlgorithm();

		

		stopwatch.Stop();
		print("Elapsed time: " + stopwatch.ElapsedMilliseconds);

		return pop1.GetRange(0,2);
		//agir 5 jogadas
		

		// UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
	}

	public List<int[]> RetrainAlgorithm(bool[,] newBoard, int currentFirstPositionX, int currentFirstPositionY, int currentSecondPositionX, int currentSecondPositionY){

		board = newBoard;
		firstPositionX = currentFirstPositionX;
		secondPositionX = currentSecondPositionX;
		firstPositionY = currentFirstPositionY;
		secondPositionY = currentSecondPositionY;


		genAlg1 = new GeneticAlgorithm(popSize, dnaSize, numGen, board, firstPositionX, firstPositionY, secondPositionX, secondPositionY, boardSizeX, boardSizeY, winningReward, losingPenalty, seed1, mutationRate, config.Voronoi);		
		List<int[]> pop1 = genAlg1.RunAlgorithm();

		return pop1.GetRange(0,2);
	
	}

}
