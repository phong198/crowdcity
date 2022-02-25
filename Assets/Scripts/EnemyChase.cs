using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    Animator m_Animator;
    public Transform closestpeople;
    public GameObject[] people;
    public bool contact;
    NavMeshAgent nav;
    private float timer;

    private void OnEnable()
    {
        timer = 15;
    }

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        m_Animator = gameObject.GetComponent<Animator>();
        closestpeople = null;
        contact = false;
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 15)
        {
            closestpeople = getClosestPeople();
            nav.SetDestination(closestpeople.position);
            timer = 0;
        }
    }

    private Transform getClosestPeople()
    {
        people = GameObject.FindGameObjectsWithTag("People");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject person in people)
        {
            float currentDistane;
            currentDistane = Vector3.Distance(transform.position, person.transform.position);
            if (currentDistane < closestDistance)
            {
                closestDistance = currentDistane;
                trans = person.transform;
            }
        }
        return trans;
    }
}