using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ポイントとターンの数値を表示するためのスクリプト
public class Display : MonoBehaviour {

	public Text pointText;
	public Text turnText;

	// Update is called once per frame
	void Update () {
		var needle = Needle.instance;
		pointText.text = needle.point.ToString ();
		turnText.text = needle.turn.ToString ();
	}
}
