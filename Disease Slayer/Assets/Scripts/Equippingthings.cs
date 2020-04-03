using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equippingthings : MonoBehaviour
{
    #region Singleton
    public static Equippingthings instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    void Start()
    {
       int slots= System.Enum.GetNames(typeof(Equipmentslot)).Length;
        currentEquipment = new Equipment[slots];
        inventory=Inventory.instance;
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipslot;
        Equipment oldItem = null;
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }
        currentEquipment[slotIndex] = newItem;

        if(onEquipmentChanged !=null)
        {
        onEquipmentChanged.Invoke(newItem, oldItem);
        }
    }

    public void UnEquip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
              onEquipmentChanged.Invoke(null, oldItem);
            }
        }

    }

}
