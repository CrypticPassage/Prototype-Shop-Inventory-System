using System;
using Enums;
using UnityEngine;

namespace Listeners
{
    public class ActionListeners : MonoBehaviour
    {
        public Action<EItemType, float> OnItemBuy;
    }
}