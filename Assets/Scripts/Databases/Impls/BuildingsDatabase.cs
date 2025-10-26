using Models;
using UnityEngine;

namespace Databases.Impls
{
    /// <summary>
    /// This Database contains all of the game buildings.
    /// </summary>
    [CreateAssetMenu(menuName = "Databases/BuildingsDatabase", fileName = "BuildingsDatabase")] 
    public class BuildingsDatabase : ScriptableObject, IBuildingsDatabase
    {
        [SerializeField] private BuildingVo[] _buildings;

        public BuildingVo[] Buildings => _buildings;
    }
}