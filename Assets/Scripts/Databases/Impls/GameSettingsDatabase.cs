using UnityEngine;

namespace Databases.Impls
{
    /// <summary>
    /// This Database contains all of the basic game settings, including currency amount at start.
    /// </summary>
    [CreateAssetMenu(menuName = "Databases/GameSettingsDatabase", fileName = "GameSettingsDatabase")] 
    public class GameSettingsDatabase : ScriptableObject, IGameSettingsDatabase
    {
        [SerializeField] private float currencyAmountAtStart;

        public float CurrencyAmountAtStart => currencyAmountAtStart;
    }
}