using UnityEngine;

namespace Collections
{
    public abstract class ABaseCollection<T> : MonoBehaviour
    {
        [SerializeField] private T[] _items;
        
        public T[] Items => _items;
    }
}