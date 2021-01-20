using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//メインのスクリプト
public class Roulette : MonoBehaviour {

	public Button push_button;//ボタンの表示・非表示
	public GameObject hexagon;//ルーレット本体
	Vector3 center = Vector3.zero;//ルーレットの位置
	Vector3 axis = new Vector3 (0, 0, 1);//ルーレットが回る方向
	public float speed;//ルーレットが回るスピード
	public float boost;//スピードの加速
	bool start;//ボタンを押しているかの有無

	//ボタンを押したとき
	public void Push(){
		//start = true;
		push_button.gameObject.SetActive(false);//非表示にする

		//LateUpdateの部分はここに移しても問題ないのでしょうか?
		speed = 180;
		hexagon.transform.RotateAround(center, axis, speed * Time.deltaTime);
		StartCoroutine(RoundCoroutine());
	}

	//Updateの部分をCoroutineに置き換え
	//StartCoroutine関数を使って呼び出す。
	IEnumerator RoundCoroutine()
    {
        while (true)
        {
			hexagon.transform.RotateAround(center, axis, speed * Time.deltaTime);//ルーレットを回す
			speed *= boost;
			if (speed > Random.Range(1000000f, 100000000f) * 1000)
			{
				needle.turn -= 1;//回る分ターンを減らす
				if (needle.turn < 0)
				{
					needle.turn += 1;//負の値にならないようにする
					speed = 0;//ルーレットを止める
					push_button.gameObject.SetActive(true);//ボタンを再表示
				    //start = false;//ボタンを初期状態にする
					return; //コルーチンから抜ける
				}
				else
				{
					speed = 1;//もう一回回す
				}
			}

			yield return null;  //これで1フレーム待つという処理になる。
		}
    }
	
	// Update is called once per frame   
	//void Update () {
	//	var needle = Needle.instance;//Needleスクリプトからの変数の参照
	//	if (start) {
	//		hexagon.transform.RotateAround(center, axis, speed * Time.deltaTime);//ルーレットを回す
	//		speed *= boost;
	//		if (speed > Random.Range(1000000f, 100000000f) * 1000)
	//		{
	//			needle.turn -= 1;//回る分ターンを減らす
	//			if (needle.turn < 0)
	//			{
	//				needle.turn += 1;//負の値にならないようにする
	//				speed = 0;//ルーレットを止める
	//				push_button.gameObject.SetActive(true);//ボタンを再表示
	//				start = false;//ボタンを初期状態にする
	//			}
	//			else
	//			{
	//				speed = 1;//もう一回回す
	//			}
	//		}
	//	}
	//}

	//再表示されたボタンを押したときの処理
	//void LateUpdate() {
	//	var needle = Needle.instance;//Needleスクリプトからの変数の参照
	//	if (start && speed <= 0) {
	//		speed = 180;
	//		hexagon.transform.RotateAround(center, axis, speed * Time.deltaTime);
	//	}
	//}
}