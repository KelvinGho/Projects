using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class Controller : MonoBehaviour {
    float movement = 0f;
    public float movementSpeed = 10f;
    public float SideLimit = 3.5f;
    float NewPosX;
    Rigidbody2D rb;


    public Text scoreText;
    static public int topscore;

    int[] Rank = new int[6];


    // Use this for initialization
    void Start()
    {
        topscore = 0;
       
        if (PlayerPrefs.HasKey("R1"))
        {
            for (int ix = 1;ix <= 5; ix ++ )
            {
                Rank[ix] = PlayerPrefs.GetInt("R" + ix);
            }
        } else
        {
            for (int ix = 1; ix <= 5; ix++)
            {
                PlayerPrefs.SetInt("R" + ix , 0);
                Rank[ix] = 0;
            }

        }

        Debug.Log("" + Rank[1] + "/" + Rank[2] + "/" + Rank[3] + "/" + Rank[4] + "/" + Rank[5] + "/");

        rb = GetComponent<Rigidbody2D>();
      
    }



    // Update is called once per frame
    void Update() {
       

        if (Application.platform ==RuntimePlatform.Android|| Application.platform == RuntimePlatform.IPhonePlayer)
        {
            movement = Input.acceleration.x;


        }
        else movement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        NewPosX = transform.position.x + movement;
        if (NewPosX > SideLimit)
        {

            NewPosX = -SideLimit;
        }
        if (NewPosX < -SideLimit)
        {

            NewPosX = SideLimit;
        }
        transform.position = new Vector3(NewPosX, transform.position.y, 0);

        if (rb.velocity.y > 0 && transform.position.y > topscore)
        {
            topscore =(int) transform.position.y;
        }
        //scoreText.text = Mathf.Round(topscore).ToString();
       

       
        scoreText.text = "" + topscore;
        //PlayerPrefs.SetInt("R", topscore);
        //GameOverStage();
    }

    //void GameOverStage()
    //{
    //    int newRank = 0; //まず今回のタイムを0位と仮定する
    //    for (int idx = 5; idx > 0; idx--)
    //    { //逆順 5...1
    //        if (Rank[idx] <topscore)
    //        { // 不等号（＊）
    //            newRank = idx; // 新しいランクとして判定する
    //        }
    //    }
    //    if (newRank != 0)
    //    { // 0位のままでなかったらランクイン確定
    //        for (int idx = 5; idx > newRank; idx--)
    //        { // 不等号（＊）
    //            Rank[idx] = Rank[idx - 1]; // 繰り下げ処理
    //        }
    //        Rank[newRank] = topscore; // 新ランクに登録
    //        for (int idx = 1; idx <= 5; idx++)
    //        {
    //            PlayerPrefs.SetInt("R" + idx, Rank[idx]); // データ領域に保存
    //        }
    //    }

    //}
 //   void FixedUpdate()
	//{
	//	Vector2 velocity = rb.velocity;
	//	velocity.x = movement;
	//	rb.velocity = velocity;

        
	//}
}
