using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject ball;
    Vector3 offset;
    public float lerpRate;
    public bool gameOverCamera;
    public bool test;

	// Use this for initialization
	void Start () {
        offset = ball.transform.position - transform.position;
        gameOverCamera = false;
        test = false;
	}
	
	// Update is called once per frame
	void Update () {
        gameOverCamera = BallController.gameOver;
        if (!gameOverCamera)
        {
            Follow();
        }
	}

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
