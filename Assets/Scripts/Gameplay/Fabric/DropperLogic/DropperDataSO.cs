using Common;
using Gameplay.Common;
using Gameplay.Fabric.ProductLogic;
using UnityEngine;

namespace Gameplay.Fabric.DropperLogic
{
    [CreateAssetMenu(fileName = "DropperData 1", menuName = "ScriptableObjects/Dropper", order = 0)]
    public class DropperDataSO : DataSO
    {
        [SerializeField] private float spawnRate = 3f;
        [SerializeField] private Product productPrefab;

        public float SpawnRate => spawnRate;
        public Product ProductPrefab => productPrefab;
    }
}