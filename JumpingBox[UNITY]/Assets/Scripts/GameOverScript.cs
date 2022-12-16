using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{

    public GameObject image;
    bool isActive;
    public Animator transitionAnim;

    float elapsed;
   
    //score
    public Text ScoreText; 
    // Start is called before the first frame update
    void Start()
    {

        isActive = false;
        elapsed = 0;
        if (isActive == false)
        {
            image.SetActive(false);
            ScoreText.GetComponent<Text>().enabled = false;

        }
        MenuHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == true)
        {
            
            image.SetActive(true);
            ScoreText.GetComponent<Text>().enabled = true;

            ScoreText.text = PlayerPrefs.GetInt("score").ToString();

            if (Input.GetKey(KeyCode.Space))
            {             

                StartCoroutine(LoadScene());
            }
            
            if (Input.GetKey(KeyCode.Escape))
            {
               
                SceneManager.LoadScene("Start");
            }

            elapsed += 0.1f;
            if (elapsed > 100.0f)
            {
                SceneManager.LoadScene("Start");
            }
        }
    }
    IEnumerator LoadScene()
    {
       
        transitionAnim.SetTrigger("LoadGame");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("Start");
        isActive = false;


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == ("Ground"))
        {
            isActive = true;
        }
    }

    void MenuHighScore()
    {
        int newRank = 0;
        if (newRank < PlayerController.number)
        {
            newRank = PlayerController.number;
            PlayerPrefs.SetInt("Highscore", newRank);
        }
    }
}
