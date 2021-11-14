using UnityEngine;

//敵の管理
class EnemyShip : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;//爆発オブジェクト
    [SerializeField]
    GameObject bulletPrefab;

    float offset;

    void Start()
    {
        offset = Random.Range(0, 2f * Mathf.PI);//揺れ方をランダムにする
        InvokeRepeating("Shot", 2f, 1f);
    }
    void Update()
    {
        transform.position -= new Vector3(Mathf.Cos(Time.frameCount* 0.05f + offset) * 0.01f, Time.deltaTime, 0);
        if(transform.position.y < -2.6)
        {
            Destroy(gameObject);//画面がに出たら自身を消す 
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "bullet")
        {
            Locator<IGameManager>.I.AddScore();
        }
        else if (collision.tag == "Player")
        {
            
            Locator<IGameManager>.I.GameOver();
        }
        else if(collision.tag == "EnemyBullet")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);//爆発生成
        Destroy(gameObject);
        Destroy(collision.gameObject); 
    }

    void Shot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
