using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //uGUIを扱うのに必要
using UnityEngine.SceneManagement; //シーンのロードに必要
public class Ranking : MonoBehaviour
{
    public Text[] txtRank;
    void Start()
    {
        for (int idx = 1; idx <= 5; idx++)
        {


            txtRank[idx - 1].text = PlayerPrefs.GetInt("R" + idx).ToString();


            //if (PlayerPrefs.GetInt("R" + idx)>=int.MaxValue)
            //{
            //    txtRank[idx - 1].text = "0";
            //}
            //else
            //{
            //    txtRank[idx - 1].text = PlayerPrefs.GetInt("R" + idx).ToString("D");
            //}
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.DeleteAll();
        }

    }
}