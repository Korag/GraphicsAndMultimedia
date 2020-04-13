﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRelatedDoorByTrigger : MonoBehaviour
{
    public GameObject doorPanel;

    [HideInInspector]
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator = doorPanel.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ThirdPersonControllerPlayer"))
        {
            animator.SetBool("DoorOpened", true);
            animator.SetBool("DoorClosed", false);

            this.gameObject.SetActive(false);
        }
    }
}
