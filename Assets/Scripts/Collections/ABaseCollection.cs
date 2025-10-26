using UnityEngine;

namespace Collections
{
    /// <summary>
    /// Abstraction for collections.
    /// </summary>
    public abstract class ABaseCollection<T> : MonoBehaviour
    {
        [SerializeField] private T[] _items;
        
        public T[] Items => _items;
    }
}