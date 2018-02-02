using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour
{
    GameObject moveFoward_obj;//navmeshAgent
    GameObject upDown_obj;
    GameObject kingyo_obj;

    //移動関連
    float speed = 1f;
    Vector3 targetPosition;
    float moveTime;

    //ジャンプ関連
    public float MotionSpeed = 0.25f;
    public float MotionAmplitude = 0.25f;

    private void Start()
    {
        moveFoward_obj = GameObject.Find("MoveFoward");
        upDown_obj = GameObject.Find("UpDown");
        kingyo_obj = GameObject.Find("kingyoModel");
        targetPosition = GetRandomPosition();
        moveTime = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        moveTime -= Time.deltaTime;

        //moveTimeが0以上なら行動する
        if (moveTime > 0)
        {
            //土台の動き
            //--位置：時間とともにY位置を上下させる
            var angle = Mathf.Repeat(Time.time * this.MotionSpeed, 1.0f) * 2.0f * Mathf.PI;
            var y = Mathf.Sin(angle) * this.MotionAmplitude;
            upDown_obj.transform.position = new Vector3(0, y, 0);

            //金魚の位置と向き
            moveFoward_obj.transform.Translate(Vector3.forward * speed * Time.deltaTime);

            //--向き
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - moveFoward_obj.transform.position);
            moveFoward_obj.transform.rotation = Quaternion.Slerp(moveFoward_obj.transform.rotation, targetRotation, Time.deltaTime / 2);

        }
        //moveTimeが0以下なら次のポイントを設定する
        if (moveTime < 0)
        {
            moveTime = MoveTime();
            targetPosition = GetRandomPosition();
            Debug.Log(targetPosition);
        }
    }

    public Vector3 GetRandomPosition()
    {
        float levelSize = 10f;
        return new Vector3(Random.Range(-levelSize, levelSize), 0, Random.Range(-levelSize, levelSize));
    }

    public float MoveTime()
    {
        return Random.Range(5, 10);
    }
}