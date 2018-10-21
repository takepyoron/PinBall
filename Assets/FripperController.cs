using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20f;
    //弾いたときの傾き
    private float flickAngle = -20f;

    private int leftfingerId = 0;
    private int rightfingerId = 0;


	// Use this for initialization
	void Start () {
        //HingiJointコンポーネントを取得
        this.myHingeJoint = GetComponent<HingeJoint>();
        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update () {

        //左矢印キーを押したとき左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        } //右矢印キーを押したとき右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        } //左矢印キーを離したとき左フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        } //右矢印キーを離したとき右フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //タッチ回数の取得
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touches = Input.touches[i];

            //指で画面をタッチしたときの状態
            if (Input.touches[i].phase == TouchPhase.Began)
            {
                //画面の左半分をタッチしたとき左フリッパーを動かす
                if (Input.touches[i].position.x < Screen.width * 0.5 && tag == "LeftFripperTag")
                {
                    Input.touches[i].fingerId = leftfingerId;
                    SetAngle(this.flickAngle);
                }
                //画面の右半分をタッチしたとき右フリッパーを動かす
                else if(Input.touches[i].position.x > Screen.width * 0.5 && tag == "RightFripperTag")
                {
                    Input.touches[i].fingerId = rightfingerId;
                    SetAngle(this.flickAngle);
                }
            }

            //指を画面から離したときの状態
            if (Input.touches[i].phase == TouchPhase.Ended)
            {
                //画面の左半分をタッチした指を画面から離したとき左フリッパーを元に戻す
                if (Input.touches[i].fingerId==leftfingerId && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
                //画面の右半分をタッチした指を画面から離したとき右フリッパーを元に戻す
                else if (Input.touches[i].fingerId == rightfingerId && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }
        }
    }

    //フリッパーの傾きの設定
    public void SetAngle(float angle)
    {
        JointSpring jointspr = this.myHingeJoint.spring;
        jointspr.targetPosition = angle;
        this.myHingeJoint.spring = jointspr;
    }

}
