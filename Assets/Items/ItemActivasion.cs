using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActivasion : MonoBehaviour
{
    public GameObject target;
    public GameObject itemObject;
    public Equipment equipment;
    // Start is called before the first frame update
    void Start()
    {
        itemObject.SetActive(false);
    }

    void Update()
    {
        if (equipment == Equippingthings.instance.activatedEquipment)
        {
            itemObject.SetActive(true);
        }
        else if (equipment == Equippingthings.instance.disabledEquipment)
        {
            itemObject.SetActive(false);
        }
    }

    void LateUpdate()
    {
        Vector2 newPosition = target.transform.position;
        itemObject.transform.position = newPosition;
    }
}
