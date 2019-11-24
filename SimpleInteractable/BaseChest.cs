using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base Chest class, used to control actions for Treasure Chests
/// </summary>
public class BaseChest : MonoBehaviour, IInteractable
{
    /// <summary>
    /// Defined in the Editor. This is the loot the chest drops
    /// </summary>
    public GameObject Loot;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
    }

    /// <summary>
    /// Inherited method. Tells the animator to respond and drops loot
    /// </summary>
    public void Interact()
    {
        _animator.SetTrigger("OpenChest");
        DropLoot();
    }

    private void DropLoot()
    {
        if (Loot != null)
        {
            var spawn = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            Instantiate(Loot, spawn, Quaternion.identity);
        }
    }

    /// <summary>
    /// This message is sent back to the player.
    /// </summary>
    /// <returns>Message</returns>
    public string GetMessage()
    {
        return "Press F to Open";
    }
}
