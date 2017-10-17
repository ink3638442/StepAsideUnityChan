using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    // プレファブはインスペクタ上で配置
    public GameObject carPrefab;

    public GameObject coinPrefab;

    public GameObject conePrefab;


    private int startPos = -160;

    private int goalPos = 120;

    private float posRange = 3.4f;


    private GameObject unitychan;

	// unityちゃんからジェネレータの距離
    private int frontDistance = 50;

    // アイテムを生成する位置
    int itemGeneratePos;


    // Use this for initialization
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");

        //生成する位置の初期値
        this.itemGeneratePos = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        // ジェネレータをunityちゃんより前方50m先に設置
        transform.position = new Vector3(0, 0, this.unitychan.transform.position.z + frontDistance);

        // ジェネレータが生成位置に到達したら生成する
        if ((this.itemGeneratePos <= transform.position.z) && (transform.position.z < goalPos))
        {
            int num = Random.Range(0, 10);
            if (num <= 1)
            {
                for (float j = -1; j <= 1; j += 0.4f)
                {
					// コーンを作成
                    GameObject cone = Instantiate(conePrefab) as GameObject;
					// Destroy機能をオブジェクトに持たせる
					cone.AddComponent<DestroyObjectController>();

                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, transform.position.z);
                }
            }
            else
            {
                for (int j = -1; j < 2; j++)
                {
                    int item = Random.Range(1, 11);
                    int offsetZ = Random.Range(-5, 6);

                    if (1 <= item && item <= 6)
                    {
						// コインを作成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
						// Destroy機能をオブジェクトに持たせる
						coin.AddComponent<DestroyObjectController>();

                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, transform.position.z + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
						// クルマを作成
                        GameObject car = Instantiate(carPrefab) as GameObject;
						// Destroy機能をオブジェクトに持たせる
						car.AddComponent<DestroyObjectController>();

                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, transform.position.z + offsetZ);
                    }
                }
            }

            // 次回、アイテムを生成する位置を更新
            this.itemGeneratePos += 15;
        }
    }
}
