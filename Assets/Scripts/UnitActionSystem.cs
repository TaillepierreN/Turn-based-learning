using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
	[SerializeField]private Unit selectedUnit;
	[SerializeField] private LayerMask UnitLayerMask;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (TryHandleUnitSelection()) return;
			selectedUnit.Move(MouseTracking.GetPosition());
		}
	}

	private bool TryHandleUnitSelection()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, UnitLayerMask))
		{
			if (raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
			{
				selectedUnit = unit;
				return true;
			}
		}
		return false;
	}
}
