
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _maxHP = 100;
    private int _currentHP;

    public int MaxHP => _maxHP;

    public int Hp
    {
        get => _currentHP;
        private set
        {
            var isDamage = value < _currentHP;
            _currentHP = Mathf.Clamp(value, min:0, _maxHP);
            if (isDamage)
            {
                Damaged?.Invoke(_currentHP);
            }
            else
            {
                Healed?.Invoke(_currentHP);
            }
            if (_currentHP<=0)
            {
                Died?.Invoke();
            }
        }
    }

    public UnityEvent<int> Healed;
    public UnityEvent<int> Damaged;
    public UnityEvent Died;

    private void Awake()
    {
        _currentHP = _maxHP;
    }

    public void Damage(int amount) 
    {
        Hp -= amount;
    } 
    public void Heal(int amount) => Hp += amount;
    public void HealFull() => Hp = _maxHP;
    public void Kill() => Hp = 0; 
    public void Adjust(int amount) => Hp = amount;

}
