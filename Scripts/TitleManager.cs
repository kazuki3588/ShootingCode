using UnityEngine.SceneManagement;
using UnityEngine;

//メインシーンの読み込み
public class TitleManager : MonoBehaviour
{
    public void PushStartButton() => SceneManager.LoadScene("Main");
    public void PushTitleButton() => SceneManager.LoadScene("Title");
}
