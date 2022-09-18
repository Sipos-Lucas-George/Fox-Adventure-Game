using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000007 RID: 7
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour
{
	// Token: 0x06000011 RID: 17 RVA: 0x000023B2 File Offset: 0x000005B2
	private void Reset()
	{
		this.Init();
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000023BC File Offset: 0x000005BC
	private void Init()
	{
		base.GetComponent<BoxCollider2D>().isTrigger = true;
		GameObject gameObject = new GameObject(base.name + "_Root");
		gameObject.transform.position = base.transform.position;
		base.transform.SetParent(gameObject.transform);
		GameObject gameObject2 = new GameObject("Waypoints");
		gameObject2.transform.SetParent(gameObject.transform);
		gameObject2.transform.position = gameObject.transform.position;
		GameObject gameObject3 = new GameObject("Point1");
		gameObject3.transform.SetParent(gameObject2.transform);
		gameObject3.transform.position = gameObject.transform.position;
		GameObject gameObject4 = new GameObject("Point2");
		gameObject4.transform.SetParent(gameObject2.transform);
		gameObject4.transform.position = gameObject.transform.position;
		this.points = new List<Transform>();
		this.points.Add(gameObject3.transform);
		this.points.Add(gameObject4.transform);
	}

	// Token: 0x06000013 RID: 19 RVA: 0x000024D5 File Offset: 0x000006D5
	private void Update()
	{
		this.MoveToNextPoint();
	}

	// Token: 0x06000014 RID: 20 RVA: 0x000024E0 File Offset: 0x000006E0
	private void MoveToNextPoint()
	{
		if (this.isDead)
		{
			return;
		}
		Transform transform = this.points[this.nextID];
		if (transform.transform.position.x > base.transform.position.x)
		{
			base.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		else
		{
			base.transform.localScale = new Vector3(1f, 1f, 1f);
		}
		base.transform.position = Vector2.MoveTowards(base.transform.position, transform.position, this.speed * Time.deltaTime);
		if (Vector2.Distance(base.transform.position, transform.position) < 0.2f)
		{
			if (this.nextID == this.points.Count - 1)
			{
				this.IDChangeValue = -1;
			}
			if (this.nextID == 0)
			{
				this.IDChangeValue = 1;
			}
			this.nextID += this.IDChangeValue;
		}
	}

	// Token: 0x06000015 RID: 21 RVA: 0x0000260C File Offset: 0x0000080C
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

	// Token: 0x06000016 RID: 22 RVA: 0x0000267C File Offset: 0x0000087C
	public void DeadEnemy(GameObject enemy)
	{
		this.isDead = true;
		this.firstColl.enabled = false;
		this.secondColl.enabled = false;
		this.rigidB.bodyType = RigidbodyType2D.Static;
		enemy.GetComponent<Animator>().Play("Enemy_Death");
		Object.Destroy(enemy.transform.parent.gameObject, 0.5f);
	}

	// Token: 0x04000012 RID: 18
	public List<Transform> points;

	// Token: 0x04000013 RID: 19
	public int nextID;

	// Token: 0x04000014 RID: 20
	private int IDChangeValue = 1;

	// Token: 0x04000015 RID: 21
	public float speed = 2f;

	// Token: 0x04000016 RID: 22
	public BoxCollider2D firstColl;

	// Token: 0x04000017 RID: 23
	public BoxCollider2D secondColl;

	// Token: 0x04000018 RID: 24
	public Rigidbody2D rigidB;

	// Token: 0x04000019 RID: 25
	private bool isDead;
}
