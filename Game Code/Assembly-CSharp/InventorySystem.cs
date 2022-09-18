using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200000C RID: 12
public class InventorySystem : MonoBehaviour
{
	// Token: 0x06000033 RID: 51 RVA: 0x000032DF File Offset: 0x000014DF
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			this.ToggleInventory();
		}
	}

	// Token: 0x06000034 RID: 52 RVA: 0x000032F0 File Offset: 0x000014F0
	private void ToggleInventory()
	{
		this.isOpen = !this.isOpen;
		this.ui_Window.SetActive(this.isOpen);
		this.Update_UI();
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00003318 File Offset: 0x00001518
	public void PickUp(GameObject item)
	{
		this.items.Add(item);
		this.Update_UI();
	}

	// Token: 0x06000036 RID: 54 RVA: 0x0000332C File Offset: 0x0000152C
	private void Update_UI()
	{
		this.HideAll();
		for (int i = 0; i < this.items.Count; i++)
		{
			this.items_images[i].sprite = this.items[i].GetComponent<SpriteRenderer>().sprite;
			this.items_images[i].gameObject.SetActive(true);
		}
	}

	// Token: 0x06000037 RID: 55 RVA: 0x0000338C File Offset: 0x0000158C
	private void HideAll()
	{
		Image[] array = this.items_images;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(false);
		}
		this.HideDescription();
	}

	// Token: 0x06000038 RID: 56 RVA: 0x000033C4 File Offset: 0x000015C4
	public void ShowDescription(int id)
	{
		this.description_Image.sprite = this.items_images[id].sprite;
		this.description_Title.text = this.items[id].name;
		this.description_Text.text = this.items[id].GetComponent<Item>().descriptionText;
		this.description_Image.gameObject.SetActive(true);
		this.description_Title.gameObject.SetActive(true);
		this.description_Text.gameObject.SetActive(true);
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00003459 File Offset: 0x00001659
	public void HideDescription()
	{
		this.description_Image.gameObject.SetActive(false);
		this.description_Title.gameObject.SetActive(false);
		this.description_Text.gameObject.SetActive(false);
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00003490 File Offset: 0x00001690
	public void Consume(int id)
	{
		if (this.items[id].GetComponent<Item>().type == Item.ItemType.Consumables && this.lives.livesRemaning < 3)
		{
			this.items[id].GetComponent<Item>().consumeEvent.Invoke();
			Object.Destroy(this.items[id], 0.1f);
			this.items.RemoveAt(id);
			this.Update_UI();
		}
	}

	// Token: 0x04000049 RID: 73
	public List<GameObject> items = new List<GameObject>();

	// Token: 0x0400004A RID: 74
	public bool isOpen;

	// Token: 0x0400004B RID: 75
	public GameObject ui_Window;

	// Token: 0x0400004C RID: 76
	public Image[] items_images;

	// Token: 0x0400004D RID: 77
	public GameObject ui_Description_Window;

	// Token: 0x0400004E RID: 78
	public Image description_Image;

	// Token: 0x0400004F RID: 79
	public Text description_Title;

	// Token: 0x04000050 RID: 80
	public Text description_Text;

	// Token: 0x04000051 RID: 81
	public LifeCount lives;
}
