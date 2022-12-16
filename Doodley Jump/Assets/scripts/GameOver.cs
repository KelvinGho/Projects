using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject player;
    public RectTransform GameOverText;

    public GameObject continueBtn;
    public GameObject MenuBtn;
    public GameObject RankingBtn;

    bool PicMove;

    public Text GameOverScore;


    // Start is called before the first frame update
    void Start()
    {
        //  GameOverText = GetComponent<RectTransform>();
        PicMove = false;
        MenuBtn.SetActive(false);
        continueBtn.SetActive(false);
        RankingBtn.SetActive(false);

        GameOverScore.GetComponent<Text>().enabled = false;
       // score.GetComponent<Controller>().topscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PicMove == true)
        {
            GameOverText.anchoredPosition += Vector2.down * 8;

        }

        if (GameOverText.anchoredPosition.y < 768)
        {
            PicMove = false;
            MenuBtn.SetActive(true);
            continueBtn.SetActive(true);
            RankingBtn.SetActive(true);
            GameOverScore.GetComponent<Text>().enabled = true;

            //GameOverScore.text = " "+score.topscore; 
            GameOverScore.text = PlayerPrefs.GetInt("R").ToString("D");
        
            //GameOverScore.text = Mathf.Round(PlayerPrefs.GetInt("R")).ToString();


        }
        //GameObject.Find("Controller").SendMessage("GameOverStage");




    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Doodler"))
        {
            PicMove = true;
        }

    }
}
