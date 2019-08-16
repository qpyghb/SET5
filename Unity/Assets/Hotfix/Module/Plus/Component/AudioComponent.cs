using ETModel;
using UnityEngine;

namespace ETHotfix
{
	[ObjectSystem]
	public class AudioComponentAwakeSystem : AwakeSystem<AudioComponent>
	{
		public override void Awake(AudioComponent self)
		{
			self.Awake();
		}
	}

	[ObjectSystem]
	public class AudioComponentStartSystem : StartSystem<AudioComponent>
	{
		public override void Start(AudioComponent self)
		{
			self.Start();
		}
	}

	[ObjectSystem]
	public class AudioComponentUpdateSystem : UpdateSystem<AudioComponent>
	{
		public override void Update(AudioComponent self)
		{
			self.Update();
		}
	}

	[ObjectSystem]
	public class AudioComponentDestroySystem : DestroySystem<AudioComponent>
	{
		public override void Destroy(AudioComponent self)
		{
			self.OnDestroy();
		}
	}

	public class AudioComponent: Component
	{
		private string mBGMName = "";

		private AudioSource mAudioSource;

		public void Awake()
		{
			mAudioSource = GameObject.AddComponent<AudioSource>();
			mAudioSource.loop = true;
		}

		public void Start()
		{

		}

		public void Update()
		{

		}

		public void OnDestroy()
		{

		}

		/// <summary>
		/// 播放一段声音
		/// </summary>
		/// <param name="soundName">声音名</param>
		public void PlayOneShot(string soundName)
		{
			mAudioSource.PlayOneShot(ResourceUtil.Load<AudioClip>(soundName));
			ResourceUtil.Unload(soundName);
		}

		public void SetBGM(string bgmName)
		{
			if (bgmName == mBGMName) return;
			if (string.IsNullOrEmpty(mBGMName) == false)
			{
				ResourceUtil.Unload(mBGMName);
			}

			mAudioSource.clip = ResourceUtil.Load<AudioClip>(bgmName);
			mAudioSource.Play();
		}
	}
}
