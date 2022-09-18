using System;
using UnityEngine;

// Token: 0x02000008 RID: 8
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI_Static : MonoBehaviour
{
	// Token: 0x06000018 RID: 24 RVA: 0x000026F8 File Offset: 0x000008F8
	private void Reset()
	{
		this.Init();
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002700 File Offset: 0x00000900
	private void Init()
	{
		base.GetComponent<BoxCollider2D>().isTrigger = true;
		GameObject gameObject = new GameObject(base.name + "_Root");
		gameObject.transform.position = base.transform.position;
		base.transform.SetParent(gameObject.transform);
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00002758 File Offset: 0x00000958
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			Object.FindObjectOfType<LifeCount>().LoseLife();
			Fox component = collision.GetComponent<Fox>();
			component.knockbackCount = component.knockbackLength;
			if (collision.transform.position.x < base.transform.position.x)
			{
				component.knockFromRight = true;
				return;
			}
			component.knockFromRight = false;
		}
	}

	// Token: 0x0600001B RID: 27 RVA: 0x000027C8 File Offset: 0x000009C8
	public void DeadEnemy(GameObject enemy)
	{
		this.firstColl.enabled = false;
		this.secondColl.enabled = false;
		this.rigidB.bodyType = RigidbodyType2D.Static;
		enemy.GetComponent<Animator>().Play("Enemy_Death");
		Object.Destroy(enemy.transform.parent.gameObject, 0.5f);
	}

	// Token: 0x0400001A RID: 26
	public BoxCollider2D firstColl;

	// Token: 0x0400001B RID: 27
	public BoxCollider2D secondColl;

	// Token: 0x0400001C RID: 28
	public Rigidbody2D rigidB;
}
