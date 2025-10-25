using System;
using Enums;
using UnityEngine;

namespace Listeners
{
    public class Actions : MonoBehaviour
    {
        public Action<EItemType, float> OnItemBuy;
        public Action<EItemType, float> OnItemUse;
    }
}