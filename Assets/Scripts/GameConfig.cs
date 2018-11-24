using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Config")]
public class GameConfig : ScriptableObject {

	[Range(1,10)] public int speed;
	[Range(20,50)] public int populations;
	[Range(1,3)] public int difficulty;
}
