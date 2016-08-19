using UnityEngine;

namespace appnext
{
#if UNITY_ANDROID
    public class InterstitialConfig
    {
        public string buttonText = "";
        public string buttonColor = "";
        public string categories = "";
        public string postback = "";
        public bool backButtonCanClose = false;
        public bool mute = true;
        public string creativeType = Interstitial.TYPE_MANAGED;
        public string skipText = "";
        public bool autoPlay = true;

        public InterstitialConfig()
        {
            AndroidJavaObject instance = new AndroidJavaObject("com.appnext.ads.interstitial.InterstitialConfig");

            buttonText = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getButtonText", "()Ljava/lang/String"), new jvalue[0] { });
            buttonColor = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getButtonColor", "()Ljava/lang/String"), new jvalue[0] { });
            categories = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getCategories", "()Ljava/lang/String"), new jvalue[0] { });
            postback = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getPostback", "()Ljava/lang/String"), new jvalue[0] { });
            backButtonCanClose = AndroidJNI.CallBooleanMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "isBackButtonCanClose", "()Z"), new jvalue[0] { });
            mute = AndroidJNI.CallBooleanMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getMute", "()Z"), new jvalue[0] { });
            creativeType = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getCreativeType", "()Ljava/lang/String"), new jvalue[0] { });
            skipText = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getSkipText", "()Ljava/lang/String"), new jvalue[0] { });
            autoPlay = AndroidJNI.CallBooleanMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "isAutoPlay", "()Z"), new jvalue[0] { });
        }

        public void setButtonText(string buttonText)
        {
            if (buttonText == null)
                buttonText = "";
            this.buttonText = buttonText;
        }

        public void setButtonColor(string buttonColor)
        {
            if (buttonColor == null)
            {
                buttonColor = "";
            }
            this.buttonColor = buttonColor;
        }

        public string getButtonText()
        {
            return buttonText;
        }

        public string getButtonColor()
        {
            return buttonColor;
        }

        public void setBackButtonCanClose(bool canClose)
        {
            backButtonCanClose = canClose;
        }

        public bool isBackButtonCanClose()
        {
            return backButtonCanClose;
        }

        public void setCategories(string category)
        {
            if (category == null)
                category = "";
            categories = category;
        }

        public void setPostback(string postback)
        {
            if (postback == null)
                postback = "";
            
            this.postback = postback;
        }

        public void setMute(bool mute)
        {
            this.mute = mute;
        }

        public string getCategories()
        {
            return categories;
        }

        public string getPostback()
        {
            return postback;
        }

        public bool getMute()
        {
            return mute;
        }

        public void setCreativeType(string creativeType)
        {
            this.creativeType = creativeType;
        }

        public string getCreativeType()
        {
            return creativeType;
        }

        public bool isAutoPlay()
        {
            return autoPlay;
        }

        public void setAutoPlay(bool autoPlay)
        {
            this.autoPlay = autoPlay;
        }

        public void setSkipText(string skip)
        {
            if (skip == null)
                skip = "";
            skipText = skip;
        }

        public string getSkipText()
        {
            return skipText;
        }
    }
#endif
}
