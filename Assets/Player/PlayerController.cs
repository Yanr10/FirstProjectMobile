using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;
    public string TagToCheckEnemy = "Enemy";

    public float speed = 1f;

    public GameObject EndScreen;

    private Vector3 _pos;
    private bool _canRun;

   
    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == TagToCheckEnemy)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _canRun = false;
        EndScreen.SetActive(true);
    }
    public void StartToRun()
    {
        _canRun = true;
    }

}
