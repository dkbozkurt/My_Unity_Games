// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject attackPrefab;
    private float _shootSpeed = 20f;
    private float destroyShootTime = 5f;

    public void Shoot(GameObject Enemy)
    {
        GameObject bullet = Instantiate(attackPrefab);
        bullet.transform.position = new Vector3(Enemy.transform.position.x,
            Enemy.transform.position.y+Enemy.transform.localScale.y,
            Enemy.transform.position.z);
        bullet.GetComponent<Rigidbody>().velocity = Enemy.transform.forward * _shootSpeed;
        Destroy(bullet,destroyShootTime);
    }

}
