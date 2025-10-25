using Models;
using UnityEngine;

namespace Databases.Impls
{
    [CreateAssetMenu(menuName = "Databases/BuildingsDatabase", fileName = "BuildingsDatabase")] 
    public class BuildingsDatabase : ScriptableObject, IBuildingsDatabase
    {
        [SerializeField] private BuildingVo[] _buildings;

        public BuildingVo[] Buildings => _buildings;
    }
}