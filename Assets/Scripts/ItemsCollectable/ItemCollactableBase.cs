using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem ParticleSystem;
    public float TimeToHide = 3f;
    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;



    private void Awake()
    {
        if (ParticleSystem != null) ParticleSystem.transform.SetParent(null);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag)) 
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideOnObject", TimeToHide);
        OnCollect();

    }
    public void HideOnObject()
    {
        gameObject.SetActive(false);
    }
    

    protected virtual void OnCollect()
    {
        if (ParticleSystem != null) ParticleSystem.Play();
        if (audioSource != null) audioSource.Play();
    }
}
