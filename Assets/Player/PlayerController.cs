using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;
    public string TagToCheckEnemy = "Enemy";
    public string TagToCheckEndline = "EndLine";


    public float speed = 1f;

    [Header("Animation")]
    public AnimatorManager animatorManager;

    [Header("Coin Setup")]
    public GameObject coinCollector;

    [Header("TextMeshPro")]
    public TextMeshPro uiTextPowerUp;

    public bool invencible = false;

    public GameObject EndScreen;

    private Vector3 _pos;
    private bool _canRun;
    private float _currentSpeed;
    private Vector3 _startPosition;
    private float _baseSpeedToAnimation = 7f;
    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
    }


    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == TagToCheckEnemy)
        {
            //MoveBack();
            if (!invencible) EndGame(AnimatorManager.animationType.DEAD);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == TagToCheckEndline)
        {
            if (!invencible) EndGame();

        }
    }


    /*private void MoveBack()
    {
        transform.DOMoveZ(-1f, 3f).SetRelative();
    }*/



    private void EndGame(AnimatorManager.animationType animationType = AnimatorManager.animationType.IDLE)
    {
        _canRun = false;
        EndScreen.SetActive(true);
        animatorManager.Play(animationType);
    }
    public void StartToRun()
    {
        _canRun = true;
        animatorManager.Play(AnimatorManager.animationType.RUN, _currentSpeed / _baseSpeedToAnimation);
    }


    #region POWER UPS
    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }
    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;*/

        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);

    }

    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.y, .1f);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }
    #endregion
}
