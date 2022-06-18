using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _powerupPrefab;
    [SerializeField] int _enemyCount;
    [SerializeField] int _waveNumber = 1;
    [SerializeField] Text _levelText;


    float _spawnRange = 9.0f;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(_waveNumber);
        Instantiate(_powerupPrefab, GenerateSpawnPosition(), _powerupPrefab.transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        _enemyCount = FindObjectsOfType<Enemy>().Length;

        if( _enemyCount == 0){
            _waveNumber++;
            _levelText.text = _waveNumber.ToString();
            SpawnEnemyWave(_waveNumber);
            Instantiate(_powerupPrefab, GenerateSpawnPosition(), _powerupPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++){
            Instantiate(_enemyPrefab, GenerateSpawnPosition(), _enemyPrefab.transform.rotation);
        }

    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-_spawnRange, _spawnRange);
        float spawnPosZ = Random.Range(-_spawnRange, _spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ );
        return randomPos;
    }

}
