using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngryMode : MonoBehaviour
{
    public AngryBar angryBar;
    private int _maxValue = 100;
    private int _value = 0;
    
    private bool _startcoroutine;
    private bool _stopcoroutine;

    private int _iValue=0;

    private int _valueCount;
    public Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateNumber());
        angryBar.SetMinValue(_iValue);
    }

    // Update is called once per frame
    void Update()
    {
        if (_iValue >= 100 && Player_health.currentHealth>0 && Input.GetKeyDown(KeyCode.E))
        {
            _animator.SetBool("ControlEnraged",true);
            PlayerCombat.blockAttack = 0.2f;
            StartCoroutine(Exitvalue());
        }
        if (_iValue<=0)
        {
            _animator.SetBool("ControlEnraged",false);
            _animator.ResetTrigger("Enraged");
            PlayerCombat.blockAttack = 0.9f;
            StartCoroutine(UpdateNumber());
            
        }
    }

    IEnumerator UpdateNumber()
    {
        for (int i = 1; i < 26; i++)
        {
            _iValue = i * 4;
            angryBar.SetValue(_iValue);
            yield return new WaitForSeconds(1f);
            Debug.Log("sayı"+_iValue);
        }
        
    }

    private IEnumerator Exitvalue()
    {
        for (int i = 5; i > -1; i--)
        {
            _iValue = i * 20;
            angryBar.SetValue(_iValue);
            Debug.Log("sayıı"+_iValue);
            yield return new WaitForSeconds(1f);
        }
    }
    private void IncreaseValue(int amount)
    {
        _value += amount;
        Debug.Log("Total Value: " + _value);

        if (_value >= _maxValue)
        {
            
        }
    }

}
