using UnityEngine;

class PlayerShip : MonoBehaviour
{
    [SerializeField]
    Transform firePoint; //球を発射する位置
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    AudioClip shootSound;
    [SerializeField]
    GameObject explosion;

    void OnEnable() => Locator<PlayerShip>.Bind(this); //サービスロケータに登録

    void OnDisable() => Locator<PlayerShip>.Unbind(this);//サービスロケータから削除

    void Update()
    {
        Shot();
        Move();
       
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 nextPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * 4f;
        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x, -3.8f, 3.8f),
            Mathf.Clamp(nextPosition.y, -2f, 2f),
            nextPosition.z
            );
        transform.position = nextPosition;
    }

    void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
    
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            Locator<IAudioPlayer>.I.ShootSound();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            Locator<IGameManager>.I.GameOver();
        }
    }
}
