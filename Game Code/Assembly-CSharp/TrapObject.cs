using System;
using UnityEngine;

// Token: 0x0200001B RID: 27
public class TrapObject : MonoBehaviour
{
	// Token: 0x06000072 RID: 114 RVA: 0x00003C48 File Offset: 0x00001E48
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
}
