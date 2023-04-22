using UnityEngine;

namespace Gameplay.Common
{
    #pragma warning disable CS0414
    
    public class DataSO : ScriptableObject
    {
        [SerializeField] private string id = "ID 1";
        
        public string ID { get; protected set; }
    }
}