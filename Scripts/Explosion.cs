using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void ExplosionSound() => Locator<IAudioPlayer>.I.BoomSound();

    public void DestroyObj() => Destroy(gameObject);//アニメーションんが終わり次第自身を消す機能
}
