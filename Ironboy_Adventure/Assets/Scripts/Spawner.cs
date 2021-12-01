using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int nLane = 3;
    public float Space = 2.0f;
    public float SpawnDelay = 1.5f;
    [SerializeField]
    GameObject[] enemies;

    WaitForSeconds wait;
    bool isFinished;

    void Start()
    {
        wait = new WaitForSeconds(SpawnDelay);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(!isFinished)
        {
            GameObject newEnemy = Instantiate(GetRandomEnemy(), RandomLane(nLane), transform.rotation, transform);
            newEnemy.GetComponent<Mover>().Move(true);
            yield return wait;
        }
    }

    GameObject GetRandomEnemy()
    {
        if (enemies.Length == 0)
        { Debug.Log("Enemy Array is Empty"); return null; }

        return enemies[Random.Range(0, enemies.Length)];
    }

    // ÀÏ´Ü È¦¼ö¸¸
    Vector3 RandomLane(int nLane)
    {
        int half = nLane >> 1;
        int randomIndex = Random.Range(-half, half+1);

        Vector3 position = transform.position + new Vector3(randomIndex * Space, 0.0f, 0.0f);
        return position;
    }
    
}
