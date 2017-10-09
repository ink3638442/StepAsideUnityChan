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

	private const int FRONT_DISTANCE = 50;

	// 生成する位置
	int generatePos;

    // Use this for initialization
    void Start()
    {
		this.unitychan = GameObject.Find("unitychan");

		//生成する位置の初期値
		this.generatePos = startPos;
    }

    // Update is called once per frame
    void Update()
    {
		this.transform.position = new Vector3(0, 0, this.unitychan.transform.position.z + FRONT_DISTANCE);

		if (this.startPos < this.transform.position.z && this.transform.position.z < goalPos)
		{
			// 前回作った位置より15m以上進んだら生成
			if (this.generatePos < this.transform.position.z - 15)
			{
				Debug.Log(generatePos);

				int num = Random.Range(0, 10);
				if (num <= 1)
				{
					for (float j = -1; j <=	1; j += 0.4f)
					{
						GameObject cone = Instantiate(conePrefab) as GameObject;
						cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.transform.position.z);
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
							GameObject coin = Instantiate(coinPrefab) as GameObject;
							coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.transform.position.z + offsetZ);
						}
						else if (7 <= item && item <= 9)
						{
							GameObject car = Instantiate(carPrefab) as GameObject;
							car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.transform.position.z + offsetZ); 
						}
					}
				}
				
				// 次回生成する位置を更新
				this.generatePos += 15;
			}
		}
    }
}
