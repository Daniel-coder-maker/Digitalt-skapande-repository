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

    Equipment[] currentEquipment;   //Föremål som används.

    //Callback varje gång ett föremål equippas eller unequippas.
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
   
    Inventory inventory;   //Referens till inventory.
    public Equipment activatedEquipment;
    public Equipment disabledEquipment;

    void Start()
    {
        //Inisialisera currentEquipment beroende på antalet equipment slots.
       int slots= System.Enum.GetNames(typeof(Equipmentslot)).Length;
        currentEquipment = new Equipment[slots];
        inventory=Inventory.instance;   //Skaffar en referens till inventory.
    }
    //Equippar nytt föremål.
    public void Equip(Equipment newItem)
    {
        //Tar reda på vilken slot som föremålet hör hemma i.
        int slotIndex = (int)newItem.equipslot;
        Equipment oldItem = null;
        //Byter ut förra föremålet mot nya föremålet.
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
            disabledEquipment = oldItem;
        }
        //Sätter in föremål på sin plats.
        currentEquipment[slotIndex] = newItem;
        activatedEquipment = newItem;

        //Ett föremål har equippats så man sätter igång en callback.
        if(onEquipmentChanged !=null)
        {
        onEquipmentChanged.Invoke(newItem, oldItem);
        }
    }
    //Tar bort föremålet från en specifik plats.
    public void UnEquip(int slotIndex)
    {
        //Gör det bara om ett föremål finns där.
        if (currentEquipment[slotIndex] != null)
        {
            //Läger till det i spelarens inventory igen.
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
            disabledEquipment = oldItem;
            //Tar bort föremålet från equipment array.
            currentEquipment[slotIndex] = null;

            //Sätter igång en callback.
            if (onEquipmentChanged != null)
            {
              onEquipmentChanged.Invoke(null, oldItem);
            }
        }

    }
    //Tar bort alla föremål.
    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquip(i);
        }
    }

}
