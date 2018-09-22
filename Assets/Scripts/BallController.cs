using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    public GameObject particle;

    [SerializeField]
    private float speed;
    public bool started;
    public static bool gameOver;
    Rigidbody rb;
    public int diamondScore;
    public int currentDiamonds;
    public Text DiamondCounter;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        started = false;
        gameOver = false;
        currentDiamonds = 0;
        if(PlayerPrefs.HasKey("DiamondScore"))
        {
            diamondScore = PlayerPrefs.GetInt("DiamondScore");
        }
        else
        {
            diamondScore = 0;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (!started)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManage.instance.StartGame();
                
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {

            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);

            GameManage.instance.GameOver();

            //Camera.main.GetComponent<CameraFollow> ().gameOverCamera = true;

        }

		if(Input.GetMouseButtonDown(0)&& !gameOver)
        {
            SwitchDirection();
        }
	}
    
    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }

        else if(rb.velocity.x>0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(part, 1f);
            diamondScore++;
            currentDiamonds++;
            PlayerPrefs.SetInt("DiamondScore", diamondScore);
            DiamondCounter.text = currentDiamonds.ToString();


        }
    }
}
