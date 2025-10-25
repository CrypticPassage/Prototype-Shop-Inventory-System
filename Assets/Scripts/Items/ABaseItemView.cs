using Enums;
using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public abstract class ABaseItemView : MonoBehaviour
    {
        [SerializeField] protected Image iconImage;
        [SerializeField] protected Image activeImage;
        [SerializeField] protected Button clickButton;

        public Button ClickButton => clickButton;
        public EItemType Type { get; protected set; }

        public virtual void SetData(ItemVo data)
        {
            iconImage.sprite = data.Icon;
            Type = data.Type;
        }

        public void ChangeItemActivity() =>
            activeImage.gameObject.SetActive(!activeImage.gameObject.activeSelf);
    }
}