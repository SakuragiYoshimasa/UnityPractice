using UnityEngine;
using System.Collections;


public enum TurnModes {
	Right,
	Left,
	None
};


public static class TurnMode {
	
	private static int[] direction ={
		-1,
		1,
		0
	};

	public static int GetDirection(TurnModes mode){
		return direction[(int)mode];
	}

	public static bool isTurning(TurnModes mode){
		return mode == TurnModes.Left || mode == TurnModes.Right;
	}
}
