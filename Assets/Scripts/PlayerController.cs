using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

class PlayerController : Entity
{
    // Temporary during testing
    [NonSerialized]
    private float damage = 1f;

    [Header("Movement")]
    // Player movement speed
    public float speed = 1f;

    private void BasicAttack()
    {
        var position = transform.position;
        Collider[] colliders = Physics.OverlapSphere(position, .8f);
        int collidersSize = colliders.Length;
        Vector3 aim = position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        for (int i = 0; i < collidersSize; ++i)
        {
            if (colliders[i].CompareTag("Entity") && colliders[i].gameObject != gameObject)
            {
                Vector3 hitPoint = position - colliders[i].ClosestPointOnBounds(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (Vector2.Angle(new Vector2(aim.x,aim.z), new Vector2(hitPoint.x,hitPoint.z)) < 35f)
                {
                    colliders[i].gameObject.SendMessage("Damage", damage);
                    Vector3 knockBack = colliders[i].transform.position - position;
                    knockBack.y = 0;
                    knockBack.Normalize();
                    knockBack /= Vector3.Distance(colliders[i].transform.position, position);
                    knockBack *= 2;
                    colliders[i].GetComponent<Entity>().velocity += knockBack;
                }
            }
        }
    }

    private float swingTimer = 0f;

    public void FixedUpdate()
    {
        if (swingTimer > 0f) swingTimer -= Time.fixedDeltaTime;
        if (swingTimer < 0f) swingTimer = 0f;
        if (swingTimer == 0f && Input.GetAxis("Fire1") >= 1f)
        {
            BasicAttack();
            swingTimer = .75f;
        }
        // Movement
        controller.Move(Time.fixedDeltaTime * speed *
                        new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized);
    }
}