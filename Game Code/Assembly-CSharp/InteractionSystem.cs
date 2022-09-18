using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200000B RID: 11
public class InteractionSystem : MonoBehaviour
{
	// Token: 0x0600002D RID: 45 RVA: 0x000031D4 File Offset: 0x000013D4
	private void Update()
	{
		if (this.DetectObeject() && this.InteractInput())
		{
			this.detectedObeject.GetComponent<Item>().Interact();
		}
	}

	// Token: 0x0600002E RID: 46 RVA: 0x000031F6 File Offset: 0x000013F6
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(this.detectionPoint.position, 0.2f);
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00003217 File Offset: 0x00001417
	private bool InteractInput()
	{
		return Input.GetKeyDown(KeyCode.E);
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00003220 File Offset: 0x00001420
	private bool DetectObeject()
	{
		Collider2D collider2D = Physics2D.OverlapCircle(this.detectionPoint.position, 0.2f, this.detectionLayer);
		if (collider2D == null)
		{
			this.detectedObeject = null;
			return false;
		}
		this.detectedObeject = collider2D.gameObject;
		return true;
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00003274 File Offset: 0x00001474
	public void ExamineItem(Item item)
	{
		if (this.isExamining)
		{
			this.examineWindow.SetActive(false);
			this.isExamining = false;
			return;
		}
		this.examineImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
		this.examineText.text = item.descriptionText;
		this.examineWindow.SetActive(true);
		this.isExamining = true;
	}

	// Token: 0x04000041 RID: 65
	public Transform detectionPoint;

	// Token: 0x04000042 RID: 66
	private const float detectionRadius = 0.2f;

	// Token: 0x04000043 RID: 67
	public LayerMask detectionLayer;

	// Token: 0x04000044 RID: 68
	public GameObject detectedObeject;

	// Token: 0x04000045 RID: 69
	public GameObject examineWindow;

	// Token: 0x04000046 RID: 70
	public Image examineImage;

	// Token: 0x04000047 RID: 71
	public Text examineText;

	// Token: 0x04000048 RID: 72
	public bool isExamining;
}
