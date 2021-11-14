using UnityEngine;

//雑魚敵の弾を管理
class EnemyBullet : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(0, -3f, 0) * Time.deltaTime;
        if(transform.position.y < -2.6f)
        {
            Destroy(gameObject);
        }
    }
}
