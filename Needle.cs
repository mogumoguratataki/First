using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//どの的で止まったか判定するためのスクリプト
public class Needle : MonoBehaviour {

	public static Needle instance; //ポイントとターンの管理をするstatic変数
	public int point;//残りのポイント数
	public int turn;//残りのターン数
	public Roulette roulette;//Rouletteスクリプトからの変数の参照

	void Start () {
		instance = this;
	}

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D collision) {
		if (roulette.speed <= 10) {
			Debug.Log (point + turn);
			if (collision.name.Contains("Triangle 1")) {
				point += 1;
				turn += 0;
			}
			if (collision.name.Contains("Triangle 2")) {
				point += 0;
				turn += 2;
			}
			if (collision.name.Contains("Triangle 3")) {
				point += 3;
				turn += 0;
			}
			if (collision.name.Contains("Triangle 4")) {
				point += 0;
				turn += 1;
			}
			if (collision.name.Contains("Triangle 5")) {
				point += 2;
				turn += 0;
			}
			if (collision.name.Contains("Triangle 6")) {
				point += 0;
				turn += 3;
			}
		}
	}
}
