
using UnityEngine;

namespace appnext
{
#if UNITY_ANDROID
    public class FullscreenConfig
    {
        public string buttonText;
        public string buttonColor;
        public string categories;
        public string postback;
        public string orientation;
        public bool backButtonCanClose = false;
        public bool mute = true;
        public string progressType;
        public string videoLength;
        public string progressColor;
        public long delay;
        public bool showClose = false;

        public FullscreenConfig()
        {
            AndroidJavaObject instance = new AndroidJavaObject("com.appnext.ads.fullscreen.FullscreenConfig");

            buttonText = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getButtonText", "()Ljava/lang/String"), new jvalue[0] { });
            buttonColor = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getButtonColor", "()Ljava/lang/String"), new jvalue[0] { });
            categories = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getCategories", "()Ljava/lang/String"), new jvalue[0] { });
            postback = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getPostback", "()Ljava/lang/String"), new jvalue[0] { });
            backButtonCanClose = AndroidJNI.CallBooleanMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "isBackButtonCanClose", "()Z"), new jvalue[0] { });
            mute = AndroidJNI.CallBooleanMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getMute", "()Z"), new jvalue[0] { });
            progressType = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getProgressType", "()Ljava/lang/String"), new jvalue[0] { });
            videoLength = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getVideoLength", "()Ljava/lang/String"), new jvalue[0] { });
            progressColor = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getProgressColor", "()Ljava/lang/String"), new jvalue[0] { });
            delay = AndroidJNI.CallLongMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getCloseDelay", "()J"), new jvalue[0] { });
            showClose = AndroidJNI.CallBooleanMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "isShowClose", "()Z"), new jvalue[0] { });
            orientation = AndroidJNI.CallStringMethod(instance.GetRawObject(), AndroidJNIHelper.GetMethodID(instance.GetRawClass(), "getOrientation", "()Ljava/lang/String"), new jvalue[0] { });
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

        public string getProgressType()
        {
            return progressType;
        }

        public void setProgressType(string progressType)
        {
            this.progressType = progressType;
        }

        public string getVideoLength()
        {
            return videoLength;
        }

        public void setVideoLength(string videoLength)
        {
            this.videoLength = videoLength;
        }

        public string getProgressColor()
        {
            return progressColor;
        }

        public void setProgressColor(string progressColor)
        {
            if (progressColor == null)
            {
                progressColor = "";
            }
            this.progressColor = progressColor;
        }

        public bool isShowClose()
        {
            return showClose;
        }

        public void setShowClose(bool showClose)
        {
            this.showClose = showClose;
        }

        public void setShowClose(bool showClose, long delay)
        {
            this.showClose = showClose;
            this.delay = delay;
        }

        public long getCloseDelay()
        {
            return delay;
        }

        public void setOrientation(string orientation)
        {
            this.orientation = orientation;
        }

        public string getOrientation()
        {
            return orientation;
        }
    }
#endif
}
