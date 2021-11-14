using UnityEngine;

//弾の動きを管理する
public class Bullet : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(0, 3f, 0)*Time.deltaTime;
        if(transform.position.y > 2.4)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if(collision.tag == "Enemy")
        {
            Locator<IAudioPlayer>.I.BoomSound();
        }
    }
}
