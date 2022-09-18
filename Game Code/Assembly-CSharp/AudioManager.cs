using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class AudioManager : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void Awake()
	{
		AudioManager.instance = this;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
	public void PlaySFX(string sfxName)
	{
		if (sfxName != null)
		{
			if (sfxName == "land")
			{
				this.SoundObjectCreation(this.sfx_land);
				return;
			}
			if (sfxName == "jump")
			{
				this.SoundObjectCreation(this.sfx_jump);
				return;
			}
			if (sfxName == "shoot")
			{
				this.SoundObjectCreation(this.sfx_shoot);
				return;
			}
			if (!(sfxName == "collect"))
			{
				return;
			}
			this.SoundObjectCreation(this.sfx_collect);
		}
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000020D0 File Offset: 0x000002D0
	private void SoundObjectCreation(AudioClip clip)
	{
		GameObject gameObject = Object.Instantiate<GameObject>(this.soundObject, base.transform);
		gameObject.GetComponent<AudioSource>().clip = clip;
		if (clip == this.sfx_shoot)
		{
			gameObject.GetComponent<AudioSource>().volume = 0.3f;
			gameObject.GetComponent<AudioSource>().Play();
			return;
		}
		if (clip == this.sfx_collect)
		{
			gameObject.GetComponent<AudioSource>().volume = 0.1f;
			gameObject.GetComponent<AudioSource>().Play();
			return;
		}
		gameObject.GetComponent<AudioSource>().Play();
	}

	// Token: 0x06000004 RID: 4 RVA: 0x0000215A File Offset: 0x0000035A
	public void PlayMusic(string musicName)
	{
		if (musicName != null && musicName == "Main_Soundtrack")
		{
			this.MusicObjectCreation(this.music_main);
		}
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002178 File Offset: 0x00000378
	private void MusicObjectCreation(AudioClip clip)
	{
		if (this.currentMusicObject)
		{
			Object.Destroy(this.currentMusicObject);
		}
		this.currentMusicObject = Object.Instantiate<GameObject>(this.soundObject, base.transform);
		this.currentMusicObject.GetComponent<AudioSource>().clip = clip;
		this.currentMusicObject.GetComponent<AudioSource>().loop = true;
		this.currentMusicObject.GetComponent<AudioSource>().volume = 0.1f;
		this.currentMusicObject.GetComponent<AudioSource>().Play();
	}

	// Token: 0x04000001 RID: 1
	public static AudioManager instance;

	// Token: 0x04000002 RID: 2
	public AudioClip sfx_jump;

	// Token: 0x04000003 RID: 3
	public AudioClip sfx_land;

	// Token: 0x04000004 RID: 4
	public AudioClip sfx_shoot;

	// Token: 0x04000005 RID: 5
	public AudioClip sfx_collect;

	// Token: 0x04000006 RID: 6
	public AudioClip music_main;

	// Token: 0x04000007 RID: 7
	public GameObject currentMusicObject;

	// Token: 0x04000008 RID: 8
	public GameObject soundObject;
}
