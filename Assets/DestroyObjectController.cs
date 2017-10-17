using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectController : MonoBehaviour
{
	private GameObject unitychan;
	private int backDistance = 5;

    // Use this for initialization
    void Start()
    {
		this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
		if (this.unitychan.transform.position.z - backDistance > this.transform.position.z)
		{
			Destroy(gameObject);
		}
    }
}
