using System;
using UnityEngine;

// Token: 0x0200001A RID: 26
public class ShootingItem : MonoBehaviour
{
	// Token: 0x0600006F RID: 111 RVA: 0x00003B7C File Offset: 0x00001D7C
	private void Update()
	{
		if (this.coll)
		{
			return;
		}
		base.transform.Translate(base.transform.right * base.transform.localScale.x * this.speed * Time.deltaTime);
	}

	// Token: 0x06000070 RID: 112 RVA: 0x00003BD4 File Offset: 0x00001DD4
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			return;
		}
		if (collision.GetComponent<ShootingAction>())
		{
			collision.GetComponent<ShootingAction>().Action();
		}
		this.coll = true;
		base.GetComponent<BoxCollider2D>().enabled = false;
		base.GetComponent<Animator>().Play("Fireball_Explosion");
		Object.Destroy(base.gameObject, 0.25f);
	}

	// Token: 0x04000079 RID: 121
	public float speed;

	// Token: 0x0400007A RID: 122
	private bool coll;
}
