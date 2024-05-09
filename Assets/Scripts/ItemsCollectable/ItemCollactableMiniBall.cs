using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableMiniBall : ItemCollactableBase
{

    public Collider2D collider2D;
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddMiniBall();
        collider2D.enabled = false;
    }
}
