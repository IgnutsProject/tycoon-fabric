using System.Collections;
using Gameplay.Fabric.ProductLogic;
using UnityEngine;

namespace Gameplay.Fabric.DropperLogic
{
    public class Dropper : MonoBehaviour
    {
        [Header("Audio")] 
        [SerializeField] private AudioSource audioSource;
        
        [Header("Spawn properties")] 
        [SerializeField] private DropperDataSO dropperDataSO;
        [SerializeField] private Transform spawnPoint;

        private void Start()
        {
            StartCoroutine(SpawnDelay());
        }

        private void SpawnProduct()
        {
            Instantiate(dropperDataSO.ProductPrefab, spawnPoint.position, Quaternion.identity);
            
            if (audioSource) audioSource.Play();
        }

        private IEnumerator SpawnDelay()
        {
            while (true)
            {
                yield return new WaitForSeconds(dropperDataSO.SpawnRate);
                SpawnProduct();
            }
        }
    }
}
