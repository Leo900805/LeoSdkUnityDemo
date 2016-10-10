using System;
using UnityEngine;


namespace DajiaGame
{
    public class DJBeluga : MonoBehaviour
    {
        private static DJBeluga _instance;
        public TextMesh textMesh;
        public static DJBeluga GetInstance()
        {
            if (_instance != null)
            {
                return _instance;
            }

            DJBeluga pay = FindObjectOfType<DJBeluga>();
            if (pay == null)
            {
                pay = new GameObject("DJBeluga").AddComponent<DJBeluga>();
            }
            _instance = pay;

            return _instance;
        }

        private static AndroidJavaClass unityClass;
        private static AndroidJavaClass payClass;

        private static string UNITIY_CLASS = "com.unity3d.player.UnityPlayer";
        //private static string Pay_CLASS = "com.hosengamers.beluga.unity.port";
        private static string Pay_CLASS = "beluga.com.unityandroidport.port";
        //private static string Pay_CLASS = "com.hosengamers.chee.UnityActivity";

        private static string AppID = "";
        private static string Apikey = "";

        private Action<string> result;

        public void Init(string appid, string apikey,Action<string> onResult)
        {
            AppID = appid;
            Apikey = apikey;
            result = onResult;
            #if UNITY_ANDROID && !UNITY_EDITOR
                        unityClass = new AndroidJavaClass(UNITIY_CLASS);
                        payClass = new AndroidJavaClass(Pay_CLASS);
                        Debug.LogWarning("unityClass is init");
            #endif
             

        }

        public void AuthClient(string appid, string apikey, byte[] gameLogo, string packageID, bool InMaintain, string DialogTitle, string DialogMessage)
        {
        
            
            Debug.LogWarning(payClass.ToString());
            Debug.LogWarning("payClass is init");
#if UNITY_ANDROID && !UNITY_EDITOR
                                    bool inMaintain = false;
                                    string dialogTitle = "Warnings";// if inMaintain is false setDialog title null
                                    string dialogMessage = "server in maintain...";// if inMaintain is false setDialog message null

                                    payClass.CallStatic("StartAuthClient", gameObject.name, "OnResult", appid, apikey, gameLogo, packageID, InMaintain, DialogTitle, DialogMessage);

#else

            Debug.LogWarning("For Android only. It will not work inside the Unity editor!");
#endif
        }

        public void GooglePayment(string SKU_GAS, string base64, string userId, string serverId, string role, string orderId)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
          
           payClass.CallStatic("startGooglePaymentButtonPress", gameObject.name, "OnResult", SKU_GAS,  base64,  userId,
                                               serverId,  role,  orderId);
#else
            Debug.LogWarning("For Android only. It will not work inside the Unity editor!");
#endif
        }

        public void MOLPayment(string user_id, string game_id, string app_id,
                                           string PackageID, string server_id, string role)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
           payClass.CallStatic("startMOLPaymentButtonPress", gameObject.name, "OnResult", user_id,  game_id,  app_id,
                                            PackageID,  server_id,  role);
#else
            Debug.LogWarning("For Android only. It will not work inside the Unity editor!");

#endif
        }

        public void MyCardSmallPayment(string apikey, string appid, string uid,
                                                   string server_id, string role, string itemId, string orderId)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            payClass.CallStatic("startMyCardSmallPaymentButtonPress", gameObject.name, "OnResult",  apikey,  appid,  uid,
                                                    server_id,  role,  itemId,  orderId);
#else

            Debug.LogWarning("For Android only. It will not work inside the Unity editor!");
#endif
        }

        public void MyCardSerialNumberPayment(string apikey, string appid, string uid,
                                           string server_id, string role, string itemId, string orderId)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            payClass.CallStatic("startMyCardSerialNumberButtonPress", gameObject.name, "OnResult",  apikey,  appid,  uid,
                                                    server_id,  role,  itemId,  orderId);
#else

            Debug.LogWarning("For Android only. It will not work inside the Unity editor!");
#endif
        }

        public void fbAppInvite (string appUrl, string preImageUrl)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            payClass.CallStatic("callFacebookInvite", gameObject.name, appUrl, preImageUrl);
#else

            Debug.LogWarning("For Android only. It will not work inside the Unity editor!");
#endif
        }

        public void fbGameInvite(string title, string description)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            payClass.CallStatic("callFacebookGameInvite", gameObject.name, title, description);
#else

            Debug.LogWarning("For Android only. It will not work inside the Unity editor!");
#endif
        }

        public void fbShare(string title, string description, string contentUrl, string imageUrl)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            payClass.CallStatic("callFacebookShare", gameObject.name, title, description, contentUrl, imageUrl);
#else

            Debug.LogWarning("For Android only. It will not work inside the Unity editor!");
#endif
        }

        


        public void OnResult(string resp)
        {
            string respJson = "";
            respJson = resp;
            //if (resp.IndexOf("Data:")!=-1)
            //{
            //    respJson = resp.Substring(resp.IndexOf("Data:"));
            //}else if (resp.IndexOf("order:") != -1)
            //{

            //}
            textMesh.text= respJson;
            Debug.Log("result:"+ respJson);
            result(respJson);
        }
    }

   
}
