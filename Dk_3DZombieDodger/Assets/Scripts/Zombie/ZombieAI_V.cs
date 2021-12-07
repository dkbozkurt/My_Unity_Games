//Dogukan Kaan Bozkurt
//      github.com/dknbozkurt

//Zombie/Dusmana yapay zeka programi. Bizi bulup saldirsin.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Stateleri karistirmamak icin bir tane enum tanimladik.
enum ZombieState
{
    Idle =0,
    Walk =1,
    Dead=2,
    Attack=3
}
public class ZombieAI_V : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    ZombieState zombieState;
    GameObject playerObject;
    //Burada PlayerHealth classimizi import ediyoruz.
    PlayerHealth_VI playerHealth;
    //Zombie Can classini import ettik.
    ZombieHealth_III zombieHealth;
    void Start()
    {
        //Bana sahnede tag i Player olan objeyi bul.
        playerObject = GameObject.FindWithTag("Player");
        //Player healthe erisebilmek icin.
        playerHealth = playerObject.GetComponent<PlayerHealth_VI>();
        //Zombie canini erisebilmek icin
        zombieHealth = GetComponent<ZombieHealth_III>();

        zombieState = ZombieState.Idle;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        //Zombie canini kontrol ediyoruz olmesi gerekli mi diye.
        //Zombie health scriptinden de yapilabilirdi.
        if (zombieHealth.GetHealth()<= 0)
        {
            SetState(ZombieState.Dead);
        }
        //switch case yapisi ile zombie animasyonlarini ayarliyoruz.
        switch (zombieState)
        {
            //Buradaki duzun onemli cunku ilk gordugunden sonrakilere girmeden cikar func.tan.
            case ZombieState.Dead:
                KillZombie();
                break;
            case ZombieState.Attack:
                Attack();
                break;             
            case ZombieState.Walk:
                SearchForTarget();
                break; 
            case ZombieState.Idle:
                SearchForTarget();
                break;
            default:
                break;
        }

    }

    private void Attack()
    {
        SetState(ZombieState.Attack);
        agent.isStopped = true;
    }
    void MakeAttack()
    {
        //Player cani azaltma komutu.
        playerHealth.DeductHealth(10);
        //Attack yaptiktan sonra targeti hala yakinda mi diye kontrol etmesi icin gerekli !!!
        SearchForTarget();
    }
    private void SearchForTarget() 
    {
        float distance = Vector3.Distance(transform.position, playerObject.transform.position);
        //Eger Player ile zombie arasinda 10m den az mesafe var ise zombie playere dogru hareket etsin;
        if(distance < 1.5f)
        {
            Attack();
        }
        else if (distance <10)
        {
            MoveToPlayer();
        }
        else
        {
            SetState(ZombieState.Idle);
            //Eger alttaki kod olmazsa, NavMeshAgenti durdurmadigimiz icin bir sure daha yurumeye devam edecek(bizi son gordugu yere kadar).  
            agent.isStopped=true;
        }
    }

    private void SetState(ZombieState state)
    {
        //stater yi class icerisinde de set ettik.
        zombieState = state;
        //Animatorde de state degisikligi yapiyoruz.
        animator.SetInteger("state", (int)state);

    }

    private void MoveToPlayer()
    {
        //Yürütmek icin NavMeshAgentin durdurma ozelligini kapattik bu sayede gordugunde tekrardan kovalama devam edecek.
        agent.isStopped = false;
        agent.SetDestination(playerObject.transform.position);
        SetState(ZombieState.Walk);
    }

    private void KillZombie()
    {
        SetState(ZombieState.Dead);
        //Olu haldeyken hareket etmesini istemedigimiz icin bunu yazdik.
        agent.isStopped = true;
        //Zombie oldukten 5sn sonra cesetini kaldir.
        Destroy(gameObject, 5);
    }
}
