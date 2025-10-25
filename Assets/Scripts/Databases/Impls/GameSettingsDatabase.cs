using UnityEngine;

namespace Databases.Impls
{
    [CreateAssetMenu(menuName = "Databases/GameSettingsDatabase", fileName = "GameSettingsDatabase")] 
    public class GameSettingsDatabase : ScriptableObject, IGameSettingsDatabase
    {
        [SerializeField] private float currencyAmountAtStart;

        public float CurrencyAmountAtStart => currencyAmountAtStart;
    }
}