using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //ボールが見える可能性のあるｚ軸の最大値
    private float visiblePosZ = -6.5f;


    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;
    //得点を表示するテキスト
    private GameObject scoreText;

    //得点
    int score = 0;


	// Use this for initialization
	void Start () {
        //シーン中のGameOverTextオブジェクトの取得
        this.gameoverText = GameObject.Find("GameOverText");
        //シーン中のScoreTextオブジェクトの取得
        this.scoreText = GameObject.Find("ScoreText");
       
	}
	
	// Update is called once per frame
	void Update () {
        //ボールが画面外に出たとき
        if (this.transform.position.z < visiblePosZ)
        {
            //GameOverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "GameOver";

        }
        //ScoreTextに得点を表示
        this.scoreText.GetComponent<Text>().text ="Score " +score.ToString();

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 1;
        }else if(other.gameObject.tag == "LargeStarTag")
        {
            score += 10;
        }else if(other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag")
        {
            score += 5;
        }
    }
}
