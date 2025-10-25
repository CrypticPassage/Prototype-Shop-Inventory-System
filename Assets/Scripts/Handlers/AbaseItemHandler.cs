using Items;
using UnityEngine;

namespace Handlers
{
    public abstract class ABaseItemHandler<TItem> : MonoBehaviour where TItem : ABaseItemView
    {
        protected TItem _activeItem;
        public TItem ActiveItem => _activeItem;

        protected virtual void OnItemClick(TItem item)
        {
            if (_activeItem == item)
            {
                _activeItem.ChangeItemActivity();
                _activeItem = null;
                
                return;
            }

            _activeItem?.ChangeItemActivity();

            item.ChangeItemActivity();
            _activeItem = item;
        }
    }
}