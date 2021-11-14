using UnityEngine;
using System.Collections;
class BossEnemy : MonoBehaviour
{
    [SerializeField]
    BossEnemyBullet bulletPrefab;
    [SerializeField]
    GameObject explesion;

    int hp = 10;

    void Start() => StartCoroutine(CPU());

    void Shot(float angle, float speed)
    {
        BossEnemyBullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Setting(angle, speed);
    }
    IEnumerator CPU()
    {
        while (transform.position.y > 1f)
        {
            transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
            yield return null;//1フレームまつ
        }

        while (true)
        {
            yield return WaveNShotM(4,8);
            yield return new WaitForSeconds(1f);
            yield return WaveNShotMCurve(4, 16);
            yield return new WaitForSeconds(1f);
            yield return WaveNPlayerAimShot(4,6);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator WaveNShotM(int n, int m)
    {
        //4回８方向に撃つ
        for (int w = 0; w < n; w++)
        {
            yield return new WaitForSeconds(0.3f);
            ShotN(m, 2);
        }

    }

    IEnumerator WaveNShotMCurve(int n, int m)
    {
        for (int w = 0; w < n; w++)
        {
            yield return new WaitForSeconds(0.3f);
            yield return ShotNCurve(m, 2);
        }
    }

    IEnumerator WaveNPlayerAimShot(int n, int m)
    {
        for (int w = 0; w < n; w++)
        {
            yield return new WaitForSeconds(1f);
            PlayerAimShot(m, 3);
        }
    }

    void ShotN(int count, float speed)
    {
        int bulletCount = count;
        for(int i= 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount);
            Shot(angle, speed);
        }
    }

    void PlayerAimShot(int count ,float speed)
    {
        PlayerShip player = Locator<PlayerShip>.I;
        if ( player != null)
        {
            Vector3 diffPosition = player.transform.position - transform.position;
            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);
            int bulletCount = count;
            for(int i = 0; i<bulletCount; i++)
            {
                float angle = (i - bulletCount/2f)*((Mathf.PI / 2f) / bulletCount);
                Shot(angleP + angle, speed);
            }
        }
    }

    IEnumerator ShotNCurve(int count, float speed)
    {
        int bulletCount = count;
        for(int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount);
            Shot(angle - Mathf.PI / 2f, speed);
            Shot(-angle - Mathf.PI / 2f, speed);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            Instantiate(explesion, collision.transform.position, transform.rotation);
            Locator<IGameManager>.I.GameOver();
        }
        else if(collision.tag == "bullet")
        {
            hp--;
            Destroy(collision.gameObject);
            if(hp <= 0)
            {
                Destroy(gameObject);
                Instantiate(explesion, transform.position, transform.rotation);
                Locator<IGameManager>.I.GameClear();
            }
        }
    }

}
