using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour
{

    public GameObject platformprefab;
    public GameObject springprefab;
    public GameObject player;
    
    public float levelWidth = 0;

    int[] Rank = new int[6];
    void Start()
    {
        for (int idx = 1; idx <= 5; idx++)
        {
            Rank[idx] = PlayerPrefs.GetInt("R" + idx);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Platform"))
        {

            if (Random.Range(1, 20) == 0)
            {
                Destroy(collision.gameObject);
                Instantiate(platformprefab, new Vector2(Random.Range(-levelWidth, levelWidth), player.transform.position.y + (20 + Random.Range(1f, 1.5f))), Quaternion.identity);

            }
            else
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-levelWidth, levelWidth), player.transform.position.y + (14 + Random.Range(1f, 1.5f)));

            }

        }
        else if (collision.gameObject.name.StartsWith("spring"))
        {
            if (Random.Range(1, 3) == 1)
            {
                collision.gameObject.transform.position = new Vector2(platformprefab.transform.position.x+ Random.Range(-levelWidth, levelWidth), player.transform.position.y + (20 + Random.Range(5f, 15f)));

            }
            else
            {
                Destroy(collision.gameObject);

                Instantiate(springprefab, new Vector2(platformprefab.transform.position.x+ Random.Range(-levelWidth, levelWidth), player.transform.position.y + (20 + Random.Range(5f, 15f))), Quaternion.identity);

            }


        }
        else if (collision.gameObject.name.StartsWith("Doodler"))
        {

            PlayerPrefs.SetInt("R", Controller.topscore);

            GameOverStage();



            SceneManager.LoadScene("GameOver");



        }

    }


    void GameOverStage()
    {
        int newRank = 0; //まず今回のタイムを0位と仮定する
        for (int idx = 5; idx > 0; idx--)
        { //逆順 5...1
            if (Rank[idx] < Controller.topscore)
            { // 不等号（＊）
                newRank = idx; // 新しいランクとして判定する
            }
        }
        if (newRank != 0)
        { // 0位のままでなかったらランクイン確定
            for (int idx = 5; idx > newRank; idx--)
            { // 不等号（＊）
                Rank[idx] = Rank[idx - 1]; // 繰り下げ処理
            }
            Rank[newRank] = Controller.topscore; // 新ランクに登録
            for (int idx = 1; idx <= 5; idx++)
            {
                PlayerPrefs.SetInt("R" + idx, Rank[idx]); // データ領域に保存
            }
        }

    }



}
		