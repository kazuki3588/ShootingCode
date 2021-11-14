using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//ゲームの進行を管理する
public class GameManager : MonoBehaviour,IGameManager
{
    [SerializeField]
    Text scoreText;
    [SerializeField]
    GameObject gameOverText;
    int score = 0;
    [SerializeField]
    Text clearText;

    void OnEnable() => Locator<IGameManager>.Bind(this); //サービスロケータに登録


    void OnDisable() => Locator<IGameManager>.Unbind(this);//サービスロケータから削除
  
    void Start()
    {
        if (!Locator<IAudioPlayer>.IsValid())
        {
            Locator<IAudioPlayer>.Bind(new DummyAudioPlayer());
        }
        else if (!Locator<IGameManager>.IsValid())
        {
            Locator<IGameManager>.Bind(new DummyGameManager());
        }
        scoreText.text = "SCORE:" + score;
        gameOverText.SetActive(false);
    }
    void Update()
    {
        if(gameOverText.activeSelf == true && Input.GetKeyDown(KeyCode.R))//Retryが表示されているかつspaceキーを押したら、サイドシーンの読み込み
        {
            SceneManager.LoadScene("Main");
        } 
    }
    public void AddScore()
    {
        score += 100;
        scoreText.text = "SCORE:" + score;
    }

    public void GameOver() => gameOverText.SetActive(true);

    public void GameClear()
    {
        clearText.text = "GameClear";
        StartCoroutine("MoveTitle");
    }

    IEnumerator MoveTitle()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Title");
    }
}
