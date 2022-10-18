using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab1;
    [SerializeField]
    private GameObject swarmerPrefab2;

    [SerializeField]
    private float swarmerInterval1 = 3.5f;
    [SerializeField]
    private float swarmerInterval2 = 10f;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval1, swarmerPrefab1));
        StartCoroutine(spawnEnemy(swarmerInterval2, swarmerPrefab2));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, 6f), 0), Quaternion.identity);
        counter++;
        if (counter < 10)
            StartCoroutine(spawnEnemy(interval, enemy));
    }
}
