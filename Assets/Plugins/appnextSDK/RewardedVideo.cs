using UnityEngine;
using System.Collections;

namespace appnext
{

    #if UNITY_ANDROID
    public class RewardedVideo : MonoBehaviour
    {


        public const string PROGRESS_CLOCK = "clock";
        public const string PROGRESS_BAR = "bar";
        public const string PROGRESS_NONE = "none";
        public const string PROGRESS_DEFAULT = "default";

        public const string VIDEO_LENGTH_SHORT = "15";
        public const string VIDEO_LENGTH_LONG = "30";
        public const string VIDEO_LENGTH_DEFAULT = "default";

        public const string ORIENTATION_DEFAULT = "not_set";
        public const string ORIENTATION_LANDSCAPE = "landscape";
        public const string ORIENTATION_PORTRAIT = "portrait";
        public const string ORIENTATION_AUTO = "automatic";

        public delegate void ErrorDelegate(string error);
        public static event ErrorDelegate errorDelegate;

        private static AndroidJavaObject instance;

        public RewardedVideo(string placementID)
        {
            if (Application.platform != RuntimePlatform.Android)
                return;

            using (var pluginClass = new AndroidJavaClass("com.appnext.unityplugin.AdBuilder"))
                instance = pluginClass.CallStatic<AndroidJavaObject>("getRewardedVideo", placementID);

            init();
        }

        public RewardedVideo(string placementID, RewardedConfig config)
        {
            if (Application.platform != RuntimePlatform.Android)
                return;

            using (var pluginClass = new AndroidJavaClass("com.appnext.unityplugin.AdBuilder"))
                instance = pluginClass.CallStatic<AndroidJavaObject>("getRewardedVideo", placementID);

            init();

            setBackButtonCanClose(config.isBackButtonCanClose());
            setButtonColor(config.getButtonColor());
            setButtonText(config.getButtonText());
            setCategories(config.getCategories());
            setMute(config.getMute());
            setPostback(config.getPostback());
            setProgressColor(config.getProgressColor());
            setProgressType(config.getProgressType());
            setShowClose(config.isShowClose(), config.getCloseDelay());
            setVideoLength(config.getVideoLength());
            setOrientation(config.getOrientation());
        }

        private void init()
        {
            GameObject interstitialGameObject = GameObject.Find("appnext_rewarded_gameobject");
            if (interstitialGameObject == null)
            {
                interstitialGameObject = new GameObject("appnext_rewarded_gameobject");
                GameObject.DontDestroyOnLoad(interstitialGameObject);
                interstitialGameObject.AddComponent(GetType());
                instance.Call("registerEvent", interstitialGameObject.transform.name, "onError");
            }
        }

        public void onError(string error)
        {
            if (errorDelegate != null)
            {
                errorDelegate(error);
            }
        }

        public void loadAd()
        {
            instance.Call("loadAd");
        }

        public void showAd()
        {
            instance.Call("showAd");
        }

        public void setOnAdLoadedCallback(string gameObject, string method)
        {
            instance.Call("setOnAdLoadedCallback", gameObject, method);
        }

        public void setOnAdErrorCallback(string gameObject, string method)
        {
            instance.Call("setOnAdErrorCallback", gameObject, method);
        }

        public void setOnAdClickedCallback(string gameObject, string method)
        {
            instance.Call("setOnAdClickedCallback", gameObject, method);
        }

        public void setOnAdClosedCallback(string gameObject, string method)
        {
            instance.Call("setOnAdClosedCallback", gameObject, method);
        }

        public void setOnVideoEndedCallback(string gameObject, string method)
        {
            instance.Call("setOnVideoEndedCallback", gameObject, method);
        }

        public void setCategories(string categories)
        {
            instance.Call("setCategories", categories);
        }

        public void setPostback(string postback)
        {
            instance.Call("setPostback", postback);
        }

        public void setButtonText(string buttonText)
        {
            instance.Call("setButtonText", buttonText);
        }

        public void setButtonColor(string buttonColor)
        {
            instance.Call("setButtonColor", buttonColor);
        }

        public void setMute(bool mute)
        {
            instance.Call("setMute", mute);
        }

        public bool isAdLoaded()
        {
            return AndroidJNI.CallBooleanMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "isAdLoaded", "()Z"), new jvalue[0] { });
        }

        public void setBackButtonCanClose(bool backButtonCanClose)
        {
            instance.Call("setBackButtonCanClose", backButtonCanClose);
        }

        public void setProgressType(string progressType)
        {
            instance.Call("setProgressType", progressType);
        }

        public void setVideoLength(string videoLength)
        {
            instance.Call("setVideoLength", videoLength);
        }

        public void setProgressColor(string progressColor)
        {
            instance.Call("setProgressColor", progressColor);
        }

        public void setOrientation(string orientation)
        {
            instance.Call("setOrientation", orientation);
        }

        public void setShowClose(bool showClose)
        {
            instance.Call("setShowClose", showClose);
        }

        public void setShowClose(bool showClose, long delay)
        {
            instance.Call("setShowClose", showClose, delay);
        }

        public void setRewardedServerSidePostback(string rewardsTransactionId, string rewardsUserId,
                                                  string rewardsRewardTypeCurrency, string rewardsAmountRewarded,
                                                  string rewardsCustomParameter)
        {
            instance.Call("setRewardedServerSidePostback", rewardsTransactionId, rewardsUserId, rewardsRewardTypeCurrency, rewardsAmountRewarded, rewardsCustomParameter);
        }

    }

    #endif
}