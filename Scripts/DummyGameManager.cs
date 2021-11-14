using UnityEngine;
//nullにならないために、空の実装をしておく

public class DummyGameManager : IGameManager
{
    public void AddScore()
    {
        Debug.Log("Dummy AddScore");
    }
    public void GameOver()
    {
        Debug.Log("Game over");
    }
    public void GameClear()
    {
        Debug.Log("GameClear");
    }
}
