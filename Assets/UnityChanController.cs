using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    private Animator myAnimator;

	private Rigidbody myRigidbody;

	private float forwordForce = 800.0f;

    // Use this for initialization
    void Start()
    {
		this.myAnimator = GetComponent<Animator>();

		this.myAnimator.SetFloat("Speed", 1);

		this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log(this.transform.forward);
		this.myRigidbody.AddForce(this.transform.forward * this.forwordForce);
    }
}
