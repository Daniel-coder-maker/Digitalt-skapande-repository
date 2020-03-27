using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController), typeof(NavMeshObstacle))]
public class Entity : MonoBehaviour
{
    public struct StatsStruct
    {
        public float armorScale;
    }

    public CharacterController controller { get; protected set; }
    public StatsStruct Stats;
    public Vector3 velocity;

    [SerializeField]
    private float _Health = 100f;

    public float Health
    {
        get => _Health;
        protected set => _Health = value;
    }

    protected virtual void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        velocity += Physics.gravity * Time.fixedDeltaTime;
        controller.Move(velocity * Time.fixedDeltaTime);
        velocity.x *= .6f;
        velocity.z *= .6f;
    }

    /// <summary>
    /// Damages the entity according to its stats
    /// </summary>
    /// <param name="damage">Damage to apply</param>
    /// <returns></returns>
    public void Damage(float damage)
    {
        _Health -= damage;
    }

    private void Update()
    {
        if (Health <= 0) Die();
    }

    protected virtual void Die()
    {
        OnDeath?.Invoke(this);
    }

    public event Action<Entity> OnDeath;

}