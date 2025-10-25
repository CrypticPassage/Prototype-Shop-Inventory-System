using Objects;
using UnityEngine;

namespace Collections
{
    public class BuildingsCollection : MonoBehaviour
    {
        [SerializeField] private Building[] _buildings;

        public Building[] Buildings => _buildings;
    }
}