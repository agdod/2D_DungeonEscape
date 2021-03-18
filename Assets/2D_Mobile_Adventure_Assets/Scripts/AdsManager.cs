using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
	[SerializeField] private string _gameId;
	[SerializeField] private bool _testMode = true;
	private string _placementId = "rewardedVideo";

	private void Start()
	{
		Advertisement.AddListener(this);
		Advertisement.Initialize(_gameId, _testMode);
	}

	public void OnUnityAdsDidError(string message)
	{
		Debug.Log(message);
	}

	public void OnUnityAdsDidFinish(string placementId, ShowResult result)
	{
		switch (result)
		{
			case ShowResult.Finished:
				// Award 100G
				Debug.Log("Ad Competed 100 Gems Rewarded.");
				break;
			case ShowResult.Skipped:
				Debug.Log("You skipped the video no gems for you!");
				break;
			case ShowResult.Failed:
				Debug.Log("Video failed, possible wasnt ready. No Reward.");
				break;
		}
	}

	public void OnUnityAdsDidStart(string placementId)
	{

	}

	public void OnUnityAdsReady(string placementId)
	{

	}

	public void PlayRewardAd()
	{
		Debug.Log("Reward Ad Playing.");
		// Check if the advertisment is ready (rewrdvideo)
		// show (rewardvideos)

		if (Advertisement.IsReady(_placementId))
		{
			Advertisement.Show(_placementId);
		}
	}
}
