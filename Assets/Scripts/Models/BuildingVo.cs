using System;
using Enums;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class BuildingVo
    {
        public EItemType[] AcceptableItemTypes;
        public Sprite Icon;
        public string Description;
    }
}