using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200001D RID: 29
public class UIElementDragger : MonoBehaviour
{
	// Token: 0x06000076 RID: 118 RVA: 0x00003CDC File Offset: 0x00001EDC
	private void Update()
	{
		if (Input.GetButtonDown("Fire"))
		{
			this.objectToDrag = this.GetDraggableTransformUnderMouse();
			if (this.objectToDrag != null)
			{
				this.dragging = true;
				this.originalPosition = this.objectToDrag.position;
				this.objecttoDragImage = this.objectToDrag.GetComponent<Image>();
				this.objecttoDragImage.raycastTarget = false;
			}
		}
		if (this.dragging)
		{
			this.objectToDrag.position = Input.mousePosition;
		}
		if (Input.GetButtonUp("Fire") && this.dragging)
		{
			this.dragging = false;
			this.objecttoDragImage.raycastTarget = true;
		}
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00003D88 File Offset: 0x00001F88
	private GameObject GetObjectUnderMouse()
	{
		PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
		pointerEventData.position = Input.mousePosition;
		EventSystem.current.RaycastAll(pointerEventData, this.hitObjects);
		if (this.hitObjects.Count <= 0)
		{
			return null;
		}
		return this.hitObjects.First<RaycastResult>().gameObject;
	}

	// Token: 0x06000078 RID: 120 RVA: 0x00003DE4 File Offset: 0x00001FE4
	private Transform GetDraggableTransformUnderMouse()
	{
		GameObject objectUnderMouse = this.GetObjectUnderMouse();
		if (objectUnderMouse != null && objectUnderMouse.tag == "UIDrag")
		{
			return objectUnderMouse.transform;
		}
		return null;
	}

	// Token: 0x0400007C RID: 124
	public const string DRAGGABLE_TAG = "UIDrag";

	// Token: 0x0400007D RID: 125
	private bool dragging;

	// Token: 0x0400007E RID: 126
	private Vector2 originalPosition;

	// Token: 0x0400007F RID: 127
	private Transform objectToDrag;

	// Token: 0x04000080 RID: 128
	private Image objecttoDragImage;

	// Token: 0x04000081 RID: 129
	private List<RaycastResult> hitObjects = new List<RaycastResult>();
}
