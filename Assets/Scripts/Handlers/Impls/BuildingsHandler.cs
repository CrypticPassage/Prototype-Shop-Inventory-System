using Collections;
using Databases.Impls;
using Listeners;
using Objects;
using UnityEngine;

namespace Handlers.Impls
{
    public class BuildingsHandler : MonoBehaviour, IBuildingsHandler
    {
        [SerializeField] private Actions _actions;
        [SerializeField] private BuildingsCollection _buildingsCollection;
        [SerializeField] private BuildingsDatabase _buildingsDatabase;
        
        public void InitializeBuildings()
        {
            for (var i = 0; i < _buildingsDatabase.Buildings.Length; i++)
            {
                var building = _buildingsCollection.Items[i];
                
                building.SetData(_buildingsDatabase.Buildings[i]);
                building.ClickButton.onClick.AddListener(() => OnBuildingClick(building));
            }
        }

        private void OnBuildingClick(Building building) 
            => _actions.OnBuildingClick?.Invoke(building);
    }
}