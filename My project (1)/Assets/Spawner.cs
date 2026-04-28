using Unity.VisualScripting;
using UnityEngine;

public class sp : MonoBehaviour
{
    public GameObject coinPrefabs;

    [Header("스폰 타이밍 설정")]
    public float minSpawnInterval = 0.5f;
    public float maxSpawnInterwal = 2.0f;

    public float timer = 0.0f;
    public float nextSpawnTime;
    void Start()
    {
        SetNextSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > nextSpawnTime)
        {
            timer = 0.0f;
            SetNextSpawnTime();
        }
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterwal);
    }
}
