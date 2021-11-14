using UnityEngine;

//敵を生成
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab,bossEnemyPrefab;
    
    void Start()
    {
        InvokeRepeating("Spawn", 2f, 0.5f);//2秒後に0.5秒間隔で敵を生成
        Invoke("BossSpawn", 60f);
    }

    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-3.8f,3.8f),
            transform.position.y,
            transform.position.z
            );
        Instantiate(
            enemyPrefab,
            spawnPosition,
            transform.rotation
            );
    }
    void BossSpawn()
    {
        Instantiate(bossEnemyPrefab, transform.position, transform.rotation);
        CancelInvoke();
    }
}
