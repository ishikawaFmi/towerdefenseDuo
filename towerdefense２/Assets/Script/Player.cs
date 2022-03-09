using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _characterId;

    [SerializeField] int _attackDamage;

    [SerializeField] float _attackSpeed = 1.0f;

    [SerializeField] int _cost;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator Attack()
    {
        while (true)
        {


            yield return new WaitForSeconds(_attackSpeed); 
        }
    }
}
