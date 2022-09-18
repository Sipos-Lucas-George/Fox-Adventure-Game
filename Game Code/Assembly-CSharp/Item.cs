using System;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x0200000D RID: 13
[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
	// Token: 0x0600003C RID: 60 RVA: 0x0000351A File Offset: 0x0000171A
	private void Reset()
	{
		base.GetComponent<Collider2D>().isTrigger = true;
		base.gameObject.layer = 7;
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00003534 File Offset: 0x00001734
	public void Interact()
	{
		Item.InteractionType interactionType = this.interactType;
		if (interactionType != Item.InteractionType.PickUp)
		{
			if (interactionType == Item.InteractionType.Examine)
			{
				Object.FindObjectOfType<InteractionSystem>().ExamineItem(this);
			}
		}
		else
		{
			Object.FindObjectOfType<InventorySystem>().PickUp(base.gameObject);
			base.gameObject.SetActive(false);
		}
		this.costumEvent.Invoke();
	}

	// Token: 0x04000052 RID: 82
	public Item.InteractionType interactType;

	// Token: 0x04000053 RID: 83
	public Item.ItemType type;

	// Token: 0x04000054 RID: 84
	[Header("Examine")]
	public string descriptionText;

	// Token: 0x04000055 RID: 85
	public UnityEvent costumEvent;

	// Token: 0x04000056 RID: 86
	public UnityEvent consumeEvent;

	// Token: 0x02000021 RID: 33
	public enum InteractionType
	{
		// Token: 0x040000D8 RID: 216
		NONE,
		// Token: 0x040000D9 RID: 217
		PickUp,
		// Token: 0x040000DA RID: 218
		Examine
	}

	// Token: 0x02000022 RID: 34
	public enum ItemType
	{
		// Token: 0x040000DC RID: 220
		Static,
		// Token: 0x040000DD RID: 221
		Consumables
	}
}
