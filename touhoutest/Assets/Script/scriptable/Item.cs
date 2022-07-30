using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject {

    public string objectName;
    public Sprite sprite;

    public int quantity;

    public bool stackable;

    public enum ItemType
    {
        Ppoint,
        HEALTH,
        MONEY
    }

    public ItemType itemType;
}