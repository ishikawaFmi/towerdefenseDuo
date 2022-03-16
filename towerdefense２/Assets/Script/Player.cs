using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class Player : MonoBehaviour
{
    [SerializeField] int _characterId;

    [SerializeField] int _attackDamage;

    [SerializeField] float _attackSpeed = 1.0f;

    [SerializeField] int _cost;

    Subject<Unit> _attack = new Subject<Unit>();

    void Start()
    {
        _attack.Subscribe(_ => Damage(_attackDamage));
    }

 

    IEnumerator Attack()
    {
        while (true)
        {
            _attack.OnNext(Unit.Default);
            yield return new WaitForSeconds(_attackSpeed);
        }
    }
  
    void Damage(int damageValue)
    {

    }



}
