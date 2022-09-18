using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000009 RID: 9
public class Fox : MonoBehaviour
{
	// Token: 0x0600001D RID: 29 RVA: 0x0000282B File Offset: 0x00000A2B
	private void Awake()
	{
		this.rb2d = base.GetComponent<Rigidbody2D>();
		this.animator = base.GetComponent<Animator>();
		AudioManager.instance.PlayMusic("Main_Soundtrack");
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00002854 File Offset: 0x00000A54
	private void Update()
	{
		if (Object.FindObjectOfType<LevelManager>().endLVL)
		{
			return;
		}
		if (!this.CanMoveOrInteract())
		{
			this.horizontalValue = 0f;
			return;
		}
		this.horizontalValue = Input.GetAxisRaw("Horizontal");
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			this.isRunning = true;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			this.isRunning = false;
		}
		if (this.isGrounded)
		{
			this.coyoteCounter = this.coyoteJumpDelay;
		}
		else
		{
			this.coyoteCounter -= Time.deltaTime;
		}
		if (Input.GetButtonDown("Jump"))
		{
			this.jumpBufferCount = this.jumpBufferLenght;
		}
		else
		{
			this.jumpBufferCount -= Time.deltaTime;
		}
		if (this.jumpBufferCount >= 0f && this.coyoteCounter > 0f)
		{
			if (this.jumpBufferCount == this.jumpBufferLenght)
			{
				AudioManager.instance.PlaySFX("jump");
			}
			this.rb2d.velocity = new Vector2(this.rb2d.velocity.x, this.jumpPower);
			this.jumpBufferCount = 0f;
		}
		if (Input.GetButtonUp("Jump") && this.rb2d.velocity.y > 0f)
		{
			this.rb2d.velocity = new Vector2(this.rb2d.velocity.x, this.rb2d.velocity.y * 0.5f);
		}
		if (Input.GetButtonDown("Crouch"))
		{
			this.isCrouching = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			this.isCrouching = false;
		}
		this.animator.SetFloat("yVelocity", this.rb2d.velocity.y);
		this.WallCheck();
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00002A1B File Offset: 0x00000C1B
	private void FixedUpdate()
	{
		if (this.knockbackCount <= 0f)
		{
			this.GroundCheck();
			this.Move(this.horizontalValue, this.isCrouching);
			return;
		}
		this.Knockback();
	}

	// Token: 0x06000020 RID: 32 RVA: 0x00002A49 File Offset: 0x00000C49
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(this.groundCheckCollider.position, 0.2f);
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(this.ceilingCheckCollider.position, 0.2f);
	}

	// Token: 0x06000021 RID: 33 RVA: 0x00002A8C File Offset: 0x00000C8C
	private bool CanMoveOrInteract()
	{
		bool result = true;
		if (Object.FindObjectOfType<InteractionSystem>().isExamining)
		{
			result = false;
		}
		if (Object.FindObjectOfType<InventorySystem>().isOpen)
		{
			result = false;
		}
		if (this.isDead)
		{
			result = false;
		}
		if (this.knockbackCount > 0f)
		{
			result = false;
		}
		if (Object.FindObjectOfType<PausedMenu>().isPaused)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00002AE0 File Offset: 0x00000CE0
	private void GroundCheck()
	{
		bool flag = this.isGrounded;
		this.isGrounded = false;
		Collider2D[] array = Physics2D.OverlapCircleAll(this.groundCheckCollider.position, 0.2f, this.groundLayer);
		Collider2D[] array2 = Physics2D.OverlapCircleAll(this.groundCheckCollider.position, 0.2f, this.wallLayer);
		if (array.Length != 0 || array2.Length != 0)
		{
			this.isGrounded = true;
			if (!flag)
			{
				AudioManager.instance.PlaySFX("land");
			}
			foreach (Collider2D collider2D in array)
			{
				if (collider2D.tag == "Moving Platform")
				{
					base.transform.parent = collider2D.transform;
				}
			}
			foreach (Collider2D collider2D2 in array2)
			{
				if (collider2D2.tag == "Moving Platform")
				{
					base.transform.parent = collider2D2.transform;
				}
			}
		}
		else
		{
			base.transform.parent = null;
		}
		this.animator.SetBool("Jump", !this.isGrounded);
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00002C10 File Offset: 0x00000E10
	private void WallCheck()
	{
		if (Physics2D.OverlapCircle(this.wallCheckCollider.position, 0.2f, this.wallLayer) && Mathf.Abs(this.horizontalValue) > 0f && this.rb2d.velocity.y < 0f && !this.isGrounded)
		{
			this.animator.SetBool("Slide", this.isSliding);
			Vector2 velocity = this.rb2d.velocity;
			velocity.y = -this.slideFactor;
			this.rb2d.velocity = velocity;
			this.isSliding = true;
			if (Input.GetButtonDown("Jump"))
			{
				this.rb2d.velocity = Vector2.up * this.jumpPower;
				AudioManager.instance.PlaySFX("jump");
				this.animator.SetBool("Jump", true);
			}
		}
		else
		{
			this.isSliding = false;
			this.animator.SetBool("Slide", this.isSliding);
		}
		if (Physics2D.OverlapCircle(this.groundCheckCollider.position, 0.2f, this.groundLayer))
		{
			this.animator.SetBool("Slide", false);
		}
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00002D6C File Offset: 0x00000F6C
	private void Move(float direction, bool crouchFlag)
	{
		if (!crouchFlag)
		{
			if (Physics2D.OverlapCircle(this.ceilingCheckCollider.position, 0.2f, this.groundLayer))
			{
				crouchFlag = true;
			}
			if (Physics2D.OverlapCircle(this.ceilingCheckCollider.position, 0.2f, this.wallLayer))
			{
				crouchFlag = true;
			}
		}
		this.animator.SetBool("Crouch", crouchFlag);
		this.standingCollider.enabled = !crouchFlag;
		this.crouchingCollider.enabled = crouchFlag;
		float num = direction * this.speed * 100f * Time.fixedDeltaTime;
		if (this.isRunning)
		{
			num *= this.runSpeedModifier;
		}
		if (crouchFlag)
		{
			num *= this.crouchSpeedModifier;
		}
		this.rb2d.velocity = new Vector2(num, this.rb2d.velocity.y);
		if (this.facingRight && direction < 0f)
		{
			this.Flip();
		}
		else if (!this.facingRight && direction > 0f)
		{
			this.Flip();
		}
		if (!this.runAudio.isPlaying && Mathf.Abs(this.rb2d.velocity.x) > 10f && this.isGrounded)
		{
			this.runAudio.Play();
		}
		if (!this.walkAudio.isPlaying && Mathf.Abs(this.rb2d.velocity.x) < 10f && Mathf.Abs(this.rb2d.velocity.x) > 5f && this.isGrounded && !this.isCrouching)
		{
			this.walkAudio.Play();
		}
		if (this.runAudio.isPlaying && (Mathf.Abs(this.rb2d.velocity.x) < 10f || !this.isGrounded))
		{
			this.runAudio.Stop();
		}
		if (this.walkAudio.isPlaying && (Mathf.Abs(this.rb2d.velocity.x) < 5f || Mathf.Abs(this.rb2d.velocity.x) > 10f || !this.isGrounded || this.isCrouching))
		{
			this.walkAudio.Stop();
		}
		this.animator.SetFloat("xVelocity", Mathf.Abs(this.rb2d.velocity.x));
	}

	// Token: 0x06000025 RID: 37 RVA: 0x00002FE4 File Offset: 0x000011E4
	private void Flip()
	{
		this.facingRight = !this.facingRight;
		base.transform.localScale = new Vector3(this.horizontalValue, 1f, 1f);
	}

	// Token: 0x06000026 RID: 38 RVA: 0x00003015 File Offset: 0x00001215
	public void Die()
	{
		base.StartCoroutine("RespawnDelay");
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00003023 File Offset: 0x00001223
	public void ResetPlayer()
	{
		this.isDead = false;
		this.animator.SetBool("Dead", this.isDead);
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00003044 File Offset: 0x00001244
	public void Knockback()
	{
		if (this.knockFromRight)
		{
			this.rb2d.velocity = new Vector2(-this.knockback, this.knockback);
		}
		else if (!this.knockFromRight)
		{
			this.rb2d.velocity = new Vector2(this.knockback, this.knockback);
		}
		if (!this.isDead)
		{
			this.animator.SetBool("isHurt", true);
		}
		this.animator.SetFloat("Knockback", this.knockbackCount);
		this.knockbackCount -= Time.fixedDeltaTime;
		if (this.knockbackCount <= 0f)
		{
			this.animator.SetBool("isHurt", false);
		}
	}

	// Token: 0x06000029 RID: 41 RVA: 0x000030FB File Offset: 0x000012FB
	public IEnumerator RespawnDelay()
	{
		this.isDead = true;
		this.animator.SetBool("Dead", this.isDead);
		yield return new WaitForSeconds(1f);
		Object.FindObjectOfType<LevelManager>().Restart();
		yield break;
	}

	// Token: 0x0400001D RID: 29
	private Rigidbody2D rb2d;

	// Token: 0x0400001E RID: 30
	private Animator animator;

	// Token: 0x0400001F RID: 31
	[Header("Audio Source")]
	public AudioSource runAudio;

	// Token: 0x04000020 RID: 32
	public AudioSource walkAudio;

	// Token: 0x04000021 RID: 33
	[Header("Colliders, Layers & Radius")]
	public Collider2D standingCollider;

	// Token: 0x04000022 RID: 34
	public Collider2D crouchingCollider;

	// Token: 0x04000023 RID: 35
	public Transform ceilingCheckCollider;

	// Token: 0x04000024 RID: 36
	public Transform groundCheckCollider;

	// Token: 0x04000025 RID: 37
	public LayerMask groundLayer;

	// Token: 0x04000026 RID: 38
	public Transform wallCheckCollider;

	// Token: 0x04000027 RID: 39
	public LayerMask wallLayer;

	// Token: 0x04000028 RID: 40
	private const float groundCheckRadius = 0.2f;

	// Token: 0x04000029 RID: 41
	private const float ceilingCheckRadius = 0.2f;

	// Token: 0x0400002A RID: 42
	private const float wallCheckRadius = 0.2f;

	// Token: 0x0400002B RID: 43
	[Header("Movement")]
	[SerializeField]
	private float speed = 300f;

	// Token: 0x0400002C RID: 44
	[SerializeField]
	private float runSpeedModifier = 2f;

	// Token: 0x0400002D RID: 45
	private float horizontalValue;

	// Token: 0x0400002E RID: 46
	private float crouchSpeedModifier = 0.7f;

	// Token: 0x0400002F RID: 47
	[Header("Jump & CoyoteJ")]
	[SerializeField]
	private float jumpPower = 500f;

	// Token: 0x04000030 RID: 48
	[SerializeField]
	private float jumpBufferLenght = 0.1f;

	// Token: 0x04000031 RID: 49
	[SerializeField]
	private float coyoteJumpDelay = 0.2f;

	// Token: 0x04000032 RID: 50
	private float coyoteCounter;

	// Token: 0x04000033 RID: 51
	private float jumpBufferCount;

	// Token: 0x04000034 RID: 52
	[Header("WallJumping")]
	[SerializeField]
	private float slideFactor = 0.2f;

	// Token: 0x04000035 RID: 53
	[Header("Knockback")]
	public float knockback;

	// Token: 0x04000036 RID: 54
	public float knockbackLength;

	// Token: 0x04000037 RID: 55
	public float knockbackCount;

	// Token: 0x04000038 RID: 56
	private bool isGrounded;

	// Token: 0x04000039 RID: 57
	private bool isRunning;

	// Token: 0x0400003A RID: 58
	private bool facingRight = true;

	// Token: 0x0400003B RID: 59
	private bool isCrouching;

	// Token: 0x0400003C RID: 60
	private bool isSliding;

	// Token: 0x0400003D RID: 61
	private bool isDead;

	// Token: 0x0400003E RID: 62
	public bool knockFromRight;
}
