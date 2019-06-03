using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour {

    public static float EnemyAlive = 0;

    public Wave[] waves;

    public GameManage gameManager;

    public Transform spawnPoint;

    public Text waveCountdownText;
    public Text CurrentRound;

    public float timeBetweenWaves = 5f;
    private float countdown = 3f;
    private int waveIndex = 0;

    

    void Update()
    {

        if (EnemyAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        CurrentRound.text = "Round : " + (waveIndex+1).ToString();

        waveCountdownText.text = Mathf.Floor(countdown).ToString();
        countdown -= Time.deltaTime;

        if(countdown <= 6f )
        {
            waveCountdownText.color = Color.red;
        }else
        {
            waveCountdownText.color = Color.white;
        }


    }      

    IEnumerator SpawnWave()
    {
        
        PlayerStats.rounds++;
        
        Wave wave = waves[waveIndex];

        EnemyAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(wave.rate);
        }

        waveIndex++;

        

    }

    void SpawnEnemy(GameObject enmy)
    {
        Instantiate(enmy,spawnPoint.position,spawnPoint.rotation);
    }
}
