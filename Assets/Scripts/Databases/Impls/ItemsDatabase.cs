using System;
using System.Collections.Generic;
using Enums;
using Models;
using UnityEngine;

namespace Databases.Impls
{
    [CreateAssetMenu(menuName = "Databases/ItemsDatabase", fileName = "ItemsDatabase")] 
    public class ItemsDatabase : ScriptableObject, IItemsDatabase
    {
        [SerializeField] private ItemVo[] _items;
        private Dictionary<EItemType, ItemVo> _itemsDictionary;

        public ItemVo[] Items => _items;
        
        private void OnEnable() 
        { 
            _itemsDictionary = new Dictionary<EItemType, ItemVo>();
            
            foreach (var itemVo in _items) 
                _itemsDictionary.Add(itemVo.Type, itemVo);
        }
        
        public ItemVo GetItemDataByType(EItemType type)
        { 
            try 
            { 
                return _itemsDictionary[type];
            }
            catch (Exception e) 
            { 
                throw new Exception(
                    $"[{nameof(ItemsDatabase)}] ItemVo by type {type} is not present in the dictionary. {e.StackTrace}"); 
            } 
        } 
    }
}