using System.Collections;
using UnityEngine;

namespace Gameplay.Fabric.Dropper
{
    public class Dropper : MonoBehaviour
    {
        [Header("Spawn properties")]
        [SerializeField] private float spawnRate = 1f;
        [SerializeField] private Product productPrefab;
        [SerializeField] private Transform spawnPoint;

        private void Start()
        {
            StartCoroutine(SpawnDelay());
        }

        private void SpawnProduct()
        {
            Instantiate(productPrefab, spawnPoint.position, productPrefab.transform.rotation);
        }

        private IEnumerator SpawnDelay()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnRate);
                SpawnProduct();
            }
        }
    }
}
