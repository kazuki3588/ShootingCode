using UnityEngine;

//効果音を管理するクラス
class AudioPlayer : MonoBehaviour,IAudioPlayer
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip boomSound, shootSound;

    void OnEnable() => Locator<IAudioPlayer>.Bind(this); //サービスロケータに登録

    void OnDisable() => Locator<IAudioPlayer>.Unbind(this);//サービスロケータから削除

    void Awake() => audioSource = GetComponent<AudioSource>();

    public void BoomSound() => audioSource.PlayOneShot(boomSound);

    public void ShootSound() => audioSource.PlayOneShot(shootSound); 
}
