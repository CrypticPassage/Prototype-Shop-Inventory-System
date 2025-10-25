using Enums;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Objects
{
    public class Building : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private Button clickButton;
        
        private EItemType[] _acceptableItemTypes;
        
        public Button ClickButton => clickButton;

        public EItemType[] AcceptableItemTypes => _acceptableItemTypes;

        public void SetData(BuildingVo buildingVo)
        {
            iconImage.sprite = buildingVo.Icon;
            descriptionText.text = buildingVo.Description;
            _acceptableItemTypes = buildingVo.AcceptableItemTypes;
        }
    }
}