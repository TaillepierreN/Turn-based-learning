using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseTracking : MonoBehaviour
{
	[SerializeField] private LayerMask mousePlaneLayerMask;
	private static MouseTracking instance;

	private void Awake()
	{
		instance = this;	
	}
    private void Update()
    {
        transform.position = MouseTracking.GetPosition();
    }
	public static Vector3 GetPosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
		return raycastHit.point;
	}

}
