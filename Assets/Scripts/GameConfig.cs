using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Config")]
public class GameConfig : ScriptableObject {

	[Range(5,10)] public int speed;
	[Range(20,100)] public int population;
	[Range(50,500)] public int generations;
	[Range(1,10)] public int genes;
	[Range(0,1)] public float mutation;
}
