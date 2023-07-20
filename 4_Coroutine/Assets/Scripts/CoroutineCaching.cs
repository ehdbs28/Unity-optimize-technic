using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class CoroutineCaching : MonoBehaviour
{
    /*
    기본 코루틴 vs 캐싱 코루틴
    */

    public int maxSpawnCount = 100;

    public float spawnDelay = 0.1f;

    public GameObject cubeObj;

    private int spawnCount;

    private Vector3 randomPos;

    private GameObject newCube;

    private WaitForSeconds spawnWFS;
    private Coroutine spawnCoVal;

    private Stopwatch stopWatch = new Stopwatch();

    private void Start()
    {
        spawnWFS = new WaitForSeconds(spawnDelay);
        spawnCoVal = null;    
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(spawnCoVal == null)
                spawnCoVal = StartCoroutine(SpawnCo());
        }    
    }

    IEnumerator SpawnCo()
    {
        // 모든 큐브 삭제
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        stopWatch.Reset();
        stopWatch.Start();

        spawnCount = maxSpawnCount;
        while(spawnCount > 0)
        {
            randomPos = new Vector3(Random.value, Random.value, Random.value);
            newCube = Instantiate(cubeObj, randomPos, Quaternion.identity);
            newCube.GetComponent<Renderer>().material.color = Random.ColorHSV();
            newCube.transform.SetParent(this.transform);

            //yield return new WaitForSeconds(spawnDelay);
            yield return spawnWFS;

            spawnCount--;
        }

        stopWatch.Stop();
        spawnCoVal = null;

        Debug.Log($"{stopWatch.ElapsedMilliseconds / 1000f}초 걸림");
    }
}
