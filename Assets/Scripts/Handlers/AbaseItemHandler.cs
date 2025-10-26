using Items;
using UnityEngine;

namespace Handlers
{
    /// <summary>
    /// Abstraction for Handlers.
    /// Needed to be supplemented. It's an simple abstraction.
    /// </summary>
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