using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomUpdateManager
{
    public class Spawner : MonoBehaviour
    {
        // 커스텀 업데이트 토글
        public bool bUseUpdateManager = false;

        public GameObject spawnObjPrefab;

        public int spawnCount = 100;

        private void Start() 
        {
            SpawnObjs(spawnCount);    
        }

        public void SpawnObjs(int count)
        {
            for(int i = 0; i < count * 2; i = i + 2)
            {
                for(int j = 0; j < count * 2; j = j + 2)
                {
                    if(i == 2 && j == 2)
                        continue;

                    var go = Instantiate(spawnObjPrefab, new Vector3(i, 0, j), Quaternion.identity, transform);

                    if(bUseUpdateManager)
                    {
                        go.AddComponent<ManagedMover>();
                    }
                    else
                    {
                        go.AddComponent<Mover>();
                    }
                }
            }
        }
    }
}
