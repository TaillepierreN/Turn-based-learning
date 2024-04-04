using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
	[SerializeField]private Animator unitAnimator;
	private Vector3 targetPosition;
	float stoppingDistance = .1f;
	float moveSpeed = 4f;

	private void Update()
	{
		if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
		{
			Vector3 moveDirection = (targetPosition - transform.position).normalized;
			transform.position += moveDirection * moveSpeed * Time.deltaTime;
			unitAnimator.SetBool("IsWalking", true);
		}
		else {
		unitAnimator.SetBool("IsWalking", false);
		}
		if (Input.GetMouseButtonDown(0))
		{
			Move(MouseTracking.GetPosition());
		}
	}
	private void Move(Vector3 targetPosition)
	{
		this.targetPosition = targetPosition;
	}
}