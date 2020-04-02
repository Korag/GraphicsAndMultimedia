using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRelatedDoorByColliderTrigger : MonoBehaviour
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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ThirdPersonControllerPlayer") && animator.GetBool("DoorOpened"))
        {
            animator.SetBool("DoorClosed", true);
            animator.SetBool("DoorOpened", false);
            
            ScoreController scoreController = other.gameObject.GetComponent<ScoreController>();
            scoreController.SetScore();
        }
    }
}
