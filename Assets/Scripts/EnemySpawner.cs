using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemy;
    public Transform enemy2;
    public int enemyCount;
    public float rate;
    public float waveCountDown = 5f;
    public enum spawnState { SPAWNING, WAITING, COUNTING };
    private spawnState state = spawnState.COUNTING;
    private void Update()
    {
        if (state == spawnState.WAITING)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                //next level
                FindObjectOfType<GameManager>().CompleteLevel();
                Invoke("InvokeMethod", 2f);
            }
            else
            {
                return;
            }
        }

        if (waveCountDown <= 0)
        {
            //start spawning wave
           
            if (state != spawnState.SPAWNING)
            {
                //start spawning wave
                StartCoroutine(SpawnWave());
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }

    }
    IEnumerator SpawnWave()
    {
        state = spawnState.SPAWNING;
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f / rate);
        }

        state = spawnState.WAITING;
        yield break;
    }

    void SpawnEnemy()
    {
        //spawn enemy
        float spawnPointX = Random.Range(-10f, 10f);
        float spawnPointY = Random.Range(-3f, 6f);
        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, 100f);
        Instantiate(enemy, spawnPosition, transform.rotation);

        float spawnPointX2 = Random.Range(-10f, 10f);
        float spawnPointY2 = Random.Range(-3f, 6f);
        Vector3 spawnPosition2 = new Vector3(spawnPointX2, spawnPointY2, 100f);
        Instantiate(enemy2, spawnPosition2, transform.rotation);
    }
    public void InvokeMethod()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
