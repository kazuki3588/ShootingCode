using UnityEngine;

//bossの弾を管理
class BossEnemyBullet : MonoBehaviour
{
    float dx;
    float dy;
    public void Setting (float angle, float speed)
    {
        dx = Mathf.Cos(angle) * speed;
        dy = Mathf.Sin(angle) * speed;
    }

    void Update()
    {
        transform.position += new Vector3(dx, dy, 0) * Time.deltaTime;

        if (transform.position.x < -3.8 || transform.position.x > 3.8 || transform.position.y < -2 || transform.position.y > 2)
        {
            Destroy(gameObject);
        }
    }
}
