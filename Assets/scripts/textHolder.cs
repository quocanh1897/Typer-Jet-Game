using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class textHolder : MonoBehaviour
{
    public Text keyOfJet;
    public Canvas pjCanvas;
    public Text textUI;
    public int diffOfWord;
    private string connectionString;
    void Awake()
    {
        connectionString = "URI=file:" + Application.dataPath + "/words.db";
        get_difficult_of_word();
        pjCanvas = Canvas.FindObjectOfType<Canvas>();//add canvas vao bien pjCanvas
        textUI = CreateText(pjCanvas.transform, 12210f, 0f,getWords(diffOfWord), 40, Color.black);//khoi tao dong doi tuong textUI
        keyOfJet = textUI;
    }
    void Update()
    {
        if (keyOfJet != null)
        {
            Vector3 keyPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            keyOfJet.transform.position = keyPosition;
        }
    }
    public string randomText()
    {
        string res = "";
        int row = UnityEngine.Random.Range(0,5);
        int col= UnityEngine.Random.Range(0,3);
        access_key_database(row, col, ref res);
        return res;
    }
    public string getWords(int difficultOfWordIn)//get random word from database
    {
        string res = "";
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                int num =UnityEngine.Random.Range(1, 1223);
                string sqlQuery = "SELECT * from keyOfJet where ID = '" + num + "' ";
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res = reader.GetString(difficultOfWordIn);
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
        return res;
    }
   
    Text CreateText(Transform canvas_transform, float x, float y,
        string text_to_print, int font_size, Color text_color)
    {
        GameObject UItextGO = new GameObject("Text2");
        UItextGO.transform.SetParent(canvas_transform);
        RectTransform trans = UItextGO.AddComponent<RectTransform>();
        trans.anchoredPosition = new Vector2(x, y);
        Text text = UItextGO.AddComponent<Text>();
        text.text = text_to_print;
        text.fontSize = font_size;
        text.color = text_color;
        text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        text.rectTransform.sizeDelta = new Vector2(400, 90);
        return text;
    }
    public void access_key_database(int row,int col,ref string key)
    {
         SqliteConnection sql_con;//bien ket noi database
         SqliteDataAdapter DB;// chuyen hoa bang database thanh bang trong c# :))
         DataTable DT = new DataTable();// Bang chua cac tu trong database
         DataSet DS = new DataSet();// Tap hop cac bang (array cac bang )
         sql_con = new SqliteConnection("Data Source="+Application.dataPath+"\\dbkey.db;"+"Version=3;New=False;Compress=True");
         sql_con.Open();
         string cmd = "SELECT *" + "FROM keytable";// cau lenh truy xuat database
         DB = new SqliteDataAdapter(cmd, sql_con);// chuyen hoa bang database
         DS.Clear();
         DB.Fill(DS);// luu vao dataset
         DT = DS.Tables[0];
         sql_con.Close();
         key = DT.Rows[row][col].ToString();// chon 1 o ngau nhien trong database de lay lam key
    }

    void OnDestroy()
    {
        Destroy(keyOfJet, 0.01f);
    }
    void get_difficult_of_word()
    {
        if (gameObject.transform.parent.gameObject.GetComponent<jetFall>())
        { diffOfWord = gameObject.transform.parent.gameObject.GetComponent<jetFall>().difficultOfWord; }
        else if (gameObject.transform.parent.gameObject.GetComponent<bossscene1>())
        { diffOfWord = gameObject.transform.parent.gameObject.GetComponent<bossscene1>().difficultOfWord; }
        else if(gameObject.transform.parent.gameObject.GetComponent<jets_scene2>())
        {
            diffOfWord = gameObject.transform.parent.gameObject.GetComponent<jets_scene2>().difficultOfWord;
        }
        else if(gameObject.transform.parent.gameObject.GetComponent<BossScene2>())
        {
            diffOfWord = gameObject.transform.parent.gameObject.GetComponent<BossScene2>().difficultOfWord;
        }
	else if(gameObject.transform.parent.gameObject.GetComponent<Boss_scene3>())
	{
	    diffOfWord = gameObject.transform.parent.gameObject.GetComponent<Boss_scene3>().difficultOfWord;
	}
	else if(gameObject.transform.parent.gameObject.GetComponent<Child_Jet>())
	{
             diffOfWord = gameObject.transform.parent.gameObject.GetComponent<Child_Jet>().difficultOfWord;
	}
    }
}