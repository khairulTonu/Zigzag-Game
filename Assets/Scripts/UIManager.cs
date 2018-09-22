using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager instance;
    public GameObject zigzagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public GameObject tapImg;
    public Text score;
    public Text highScore1;
    public Text highScore2;
    public Text DiamondScore;
    


    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    public void GameStart()
    {
        tapText.SetActive(false);
        tapImg.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("panelUp");
        
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        DiamondScore.text = PlayerPrefs.GetInt("DiamondScore").ToString();
        //Debug.Log(PlayerPrefs.GetInt("DiamondScore").ToString());
        gameOverPanel.SetActive(true);
        
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
