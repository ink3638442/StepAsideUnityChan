using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
	// プレファブはインスペクタ上で配置
	public GameObject treePrefab;


	private int startPos = -250;

    private int endPos = 150;

	private float posRange = 6.5f;


	private GameObject unitychan;

	// unityちゃんからジェネレータの距離
	private int frontDistance = 50;

	// 木を生成する位置
	private int leftSideGeneratePos;
	private int rightSideGeneratePos;
	

    // Use this for initialization
    void Start()
    {
		this.unitychan = GameObject.Find("unitychan");

		//木を生成する位置の初期値
		this.leftSideGeneratePos = this.startPos;
		this.rightSideGeneratePos = this.startPos;

		// ジェネレータをunityちゃんより前方50m先に設置
		transform.position = new Vector3(0, 0, unitychan.transform.position.z + frontDistance);

		// 開始時、事前にジェネレータ位置まで作成(左サイド)
		while (transform.position.z > this.leftSideGeneratePos)
		{
			GenerateTree(leftSideGeneratePos);
		}
		
		// 開始時、事前にジェネレータ位置まで作成(右サイド)
		while (transform.position.z > this.rightSideGeneratePos)
		{
			GenerateTree(rightSideGeneratePos);
		}
    }

    // Update is called once per frame
    void Update()
    {
		// ジェネレータをunityちゃんより前方50m先に設置
		transform.position = new Vector3(0, 0, unitychan.transform.position.z + frontDistance);


		// ジェネレータが生成位置に到達したら生成する
		if ((this.leftSideGeneratePos <= transform.position.z) && (transform.position.z < this.endPos))
		{
			GenerateTree(leftSideGeneratePos);
		}

		if ((this.rightSideGeneratePos < transform.position.z) && (transform.position.z < this.endPos))
		{
			GenerateTree(rightSideGeneratePos);
		}
    }

	void GenerateTree(int generatePos)
	{
		// 木を作成
		GameObject tree = Instantiate(treePrefab) as GameObject;

		// 呼び出し元が左サイド
		if (generatePos == leftSideGeneratePos)
		{
			tree.transform.position = new Vector3(-posRange, tree.transform.position.y, generatePos);

			// 次回、木を生成する位置を10~20m先に更新
			this.leftSideGeneratePos += Random.Range(1, 20);
		}

		// 呼び出し元が右サイド
		if (generatePos == rightSideGeneratePos)
		{
			tree.transform.position = new Vector3(posRange, tree.transform.position.y, generatePos);

			// 次回、木を生成する位置を10~20m先に更新
			this.rightSideGeneratePos += Random.Range(1, 20);
		}
	}
}
