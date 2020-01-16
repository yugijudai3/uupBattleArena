using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMalletScript : MonoBehaviour
{
    public float speed = 0.05f;
    public float maxSpeed = 0.05f;
    public float moveSum = 0f;
    private GameObject nearObj;
    private float searchTime = 0;    //経過時間

    // Start is called before the first frame update
    void Start()
    {
        //最も近かったオブジェクトを取得
        nearObj = serchTag(gameObject, "Pack");
    }

    // Update is called once per frame
    void Update()
    {
        //経過時間を取得
        searchTime += Time.deltaTime;

        if (searchTime >= 0.1f)
        {
            //最も近かったオブジェクトを取得
            nearObj = serchTag(gameObject, "Pack");
            //経過時間を初期化
            searchTime = 0;
        }

        if (transform.localEulerAngles.y == 180)
        {
            speed = transform.position.z - nearObj.transform.position.z;
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
            if (speed < maxSpeed * -1)
            {
                speed = maxSpeed * -1;
            }
            if (nearObj.transform.position.z < 1.5f && nearObj.transform.position.z > -1.5f)
            {
                transform.Translate(Vector3.forward * speed);
            }
        }
        if (transform.localEulerAngles.y == 0)
        {
            speed = transform.position.z - nearObj.transform.position.z;
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
            if (speed < maxSpeed * -1)
            {
                speed = maxSpeed * -1;
            }
            if (nearObj.transform.position.z < 1.5f && nearObj.transform.position.z > -1.5f)
            {
                transform.Translate(Vector3.back * speed);
            }
        }
        if (transform.localEulerAngles.y == 90)
        {
            speed = nearObj.transform.position.x - transform.position.x;
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
            if (speed < maxSpeed * -1)
            {
                speed = maxSpeed * -1;
            }
            if (nearObj.transform.position.x < 1.5f && nearObj.transform.position.x > -1.5f)
            {
                transform.Translate(Vector3.forward * speed);
            }
        }
    }

    //指定されたタグの中で最も近いものを取得
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            if (transform.localEulerAngles.y == 180)
            {
                tmpDis = obs.transform.position.x - nowObj.transform.position.x;
            }

            if (transform.localEulerAngles.y == 0)
            {
                tmpDis = nowObj.transform.position.x - obs.transform.position.x;
            }

            if (transform.localEulerAngles.y == 90)
            {
                tmpDis = obs.transform.position.z - nowObj.transform.position.z;
            }
            //   tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }
}