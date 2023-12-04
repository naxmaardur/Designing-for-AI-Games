using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class AIActorData : MonoBehaviour
{
    public Transform holdingPoint;
    public AIActorData selfRef;
    public float health;
    public float hunger;
    public float energy;
    public TextMeshProUGUI stateText;
    public Animator animator;
    private NavMeshAgent agent;
    public Village Village;
    public float SearchRange;
    public House preferedHouse;

    private void Start()
    {
        selfRef = this;
        agent = GetComponent<NavMeshAgent>();
        Village = FindObjectOfType<Village>();
        Village.AddActor(this);
        SearchRange = Village.SearchRange;
        StartCoroutine(hungerTick());
    }


    private void Update()
    {
        if(agent.velocity != Vector3.zero)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }


    IEnumerator hungerTick()
    {

        while (true)
        {

            yield return new WaitForSeconds(3);
            if(hunger > 0)
            {
                hunger -= 1;
            } 
        }


    }

    public void Teleport(Vector3 position)
    {
        if(agent == null) { return; }
        agent.enabled = false;
        transform.position = position;
        agent.enabled = true;
    }


}
