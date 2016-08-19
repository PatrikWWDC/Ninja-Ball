using UnityEngine;
using System.Collections;
using System;

namespace appnext
{

#if UNITY_ANDROID
    public class Interstitial : MonoBehaviour
    {

        public const string TYPE_MANAGED = "managed";
        public const string TYPE_VIDEO = "video";
        public const string TYPE_STATIC = "static";

        public delegate void ErrorDelegate(string error);
        public static event ErrorDelegate errorDelegate;

        private AndroidJavaObject instance;

        public Interstitial(string placementID)
        {
            if (Application.platform != RuntimePlatform.Android)
                return;

            using (var pluginClass = new AndroidJavaClass("com.appnext.unityplugin.AdBuilder"))
                instance = pluginClass.CallStatic<AndroidJavaObject>("getInterstitial", placementID);

            init();
        }

        public Interstitial(string placementID, InterstitialConfig config)
        {
            if (Application.platform != RuntimePlatform.Android)
                return;

            using (var pluginClass = new AndroidJavaClass("com.appnext.unityplugin.AdBuilder"))
                instance = pluginClass.CallStatic<AndroidJavaObject>("getInterstitial", placementID);

            init();

            setBackButtonCanClose(config.isBackButtonCanClose());
            setButtonColor(config.getButtonColor());
            setButtonText(config.getButtonText());
            setCategories(config.getCategories());
            setMute(config.getMute());
            setPostback(config.getPostback());
            setCreativeType(config.getCreativeType());
            setAutoPlay(config.isAutoPlay());
            setSkipText(config.getSkipText());
        }

        private void init()
        {
            GameObject interstitialGameObject = GameObject.Find("appnext_interstitial_gameobject");
            if (interstitialGameObject == null)
            {
                interstitialGameObject = new GameObject("appnext_interstitial_gameobject");
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

        public void setCategories(string categories)
        {
            instance.Call("setCategories", categories);
        }

        public void setSkipText(string skip)
        {
            instance.Call("setSkipText", skip);
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

        public void setCreativeType(string creativeType)
        {
            instance.Call("setCreativeType", creativeType);
        }

        public void setAutoPlay(bool autoPlay)
        {
            instance.Call("setAutoPlay", autoPlay);
        }

        public bool isAdLoaded()
        {
            return AndroidJNI.CallBooleanMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "isAdLoaded", "()Z"), new jvalue[0] { });
        }

        public void setBackButtonCanClose(bool backButtonCanClose)
        {
            instance.Call("setBackButtonCanClose", backButtonCanClose);
        }


    }
#endif
}
