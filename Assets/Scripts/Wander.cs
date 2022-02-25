using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{

    public float wanderRadius;
    public float wanderTimer;
    public Animator m_Animator;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    private bool isFollow;
    NavMeshAgent nav;


    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        m_Animator = gameObject.GetComponent<Animator>();
        isFollow = false;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }

        if (isFollow)
        {
            nav.SetDestination(target.transform.position);
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        nav = GetComponent<NavMeshAgent>();

        if (gameObject.transform.parent.tag == "spawn")
        {
            if (other.tag == "Player")
            {
                gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = other.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material;
                gameObject.transform.SetParent(other.transform.parent);
                target = other.transform.parent.Find("Player");
                m_Animator.speed = 4.25f;
                isFollow = true;
                gameObject.tag = "Player";
            }
        }
        if (gameObject.transform.parent.tag == "Crowd")
        {
            if (other.transform.parent.tag == "Crowd")
            {
                if (other.transform.parent.childCount > gameObject.transform.parent.childCount)
                {
                    gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = other.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material;
                    gameObject.transform.SetParent(other.transform.parent);
                    target = other.transform.parent.Find("Player");
                    m_Animator.speed = 4.25f;
                    isFollow = true;
                    gameObject.tag = "Player";
                }
            }
        }
    }
}
