﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour
{
    private Animator myAnimator;

    private Rigidbody myRigidbody;

    private float forwardForce = 800.0f;

    private float turnForce = 500.0f;

    private float upForce = 500.0f;

    private float movableRange = 3.4f;

	private float coefficient = 0.95f;

	private bool isEnd = false;

	private GameObject stateText;

    // Use this for initialization
    void Start()
    {
        this.myAnimator = GetComponent<Animator>();

        this.myAnimator.SetFloat("Speed", 1);

        this.myRigidbody = GetComponent<Rigidbody>();

		this.stateText = GameObject.Find("GameResultText");
    }

    // Update is called once per frame
    void Update()
    {
		if (this.isEnd) {
			this.forwardForce *= this.coefficient;
			this.turnForce *= this.coefficient;
			this.upForce *= this.coefficient;
			this.myAnimator.speed *= this.coefficient;
		}

        // 前進
        this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);

        // 左右移動
        if (Input.GetKey(KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x)
        {
            this.myRigidbody.AddForce(-this.turnForce, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < this.movableRange)
        {
            this.myRigidbody.AddForce(this.turnForce, 0, 0);
        }

        // ジャンプ
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f)
        {
            this.myAnimator.SetBool("Jump", true);

            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
		{
			this.isEnd = true;
			this.stateText.GetComponent<Text>().text = "GAME OVER";
		}

		if (other.gameObject.tag == "GoalTag")
		{
			this.isEnd = true;
			this.stateText.GetComponent<Text>().text = "CLEAR!!";
		}

		if (other.gameObject.tag == "CoinTag")
		{
			GetComponent<ParticleSystem>().Play();

			Destroy(other.gameObject);
		}
	}
}
