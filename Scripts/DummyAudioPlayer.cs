using UnityEngine;

//nullにならないために、空の実装をしておく
class DummyAudioPlayer : MonoBehaviour,IAudioPlayer
{
    public void BoomSound() => Debug.Log("DummyAudio");  

    public void ShootSound() => Debug.Log("DummyAudio");
}
