using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemover : MonoBehaviour {

	private GameObject unitychan;

	private const int BACK_DISTANCE = 5;
	
	// Use this for initialization
	void Start () {
		this.unitychan = GameObject.Find("unitychan");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - BACK_DISTANCE);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "CarTag"         || 
		    other.gameObject.tag == "TrafficConeTag" || 
			other.gameObject.tag == "CoinTag")
		{
			Destroy(other.gameObject);
		}
	}
}
