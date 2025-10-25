using System;
using Enums;
using Objects;
using UnityEngine;

namespace Listeners
{
    public class Actions : MonoBehaviour
    {
        public Action<EItemType, float> OnItemBuy;
        public Action<Building> OnBuildingClick;
    }
}