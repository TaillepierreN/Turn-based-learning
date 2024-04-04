using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
	[SerializeField]private Unit selectedUnit;
	[SerializeField] private LayerMask UnitLayerMask;
	public event EventHandler OnSelectedUnitChanged;
	public static UnitActionSystem Instance { get; private set;}

	private void Awake() {
		if (Instance != null)
		{
			Debug.LogError("There's more than one UnitActionSystem! " + transform + " - " + Instance);
			Destroy(gameObject);
			return;
		}
		Instance = this;
	}

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
				SetSelectedUnit(unit);
				return true;
			}
		}
		return false;
	}

	private void SetSelectedUnit(Unit unit)
	{
		selectedUnit = unit;
		if (OnSelectedUnitChanged != null)
		{
		OnSelectedUnitChanged(this, EventArgs.Empty);
		}
		//OnSelectedUnitChanger?.Invoke(this, EventArgs.Empty) does the same
	}

	public Unit GetSelectedUnit()
	{
		return selectedUnit;
	}
}
