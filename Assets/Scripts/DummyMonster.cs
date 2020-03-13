using System;
using TMPro;
using UnityEngine;

class DummyMonster : Entity
{
    protected override void Awake()
    {
        base.Awake();
        Stats.armorScale = .1f;
    }

    protected override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }

    private void LateUpdate()
    {
        GetComponentInChildren<TextMeshPro>().SetText(Health.ToString());
    }
}

