using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartScript : MonoBehaviour
{
    public Animator transitionAnim;
    public GameObject Player;
    public Text HighScoreMenu;
    // Start is called before the first frame update


    void Start()
    {
        HighScoreMenu.text = PlayerPrefs.GetInt("Highscore").ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(LoadScene());
        }
        if (Input.GetKey(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }

    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("LoadGame");
        yield return new WaitForSeconds(1.2f);
        int num = Random.Range(1, 6);
        //Debug.Log(num);
        SceneManager.LoadScene(num);
    }
}
