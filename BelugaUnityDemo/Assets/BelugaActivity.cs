using UnityEngine;
using System.IO;
using System.Diagnostics;
using System.Collections;
using UnityEngine.UI;
using DajiaGame;
using GoogleMobileAds.Api;
using GooglePlayGameService;

public class BelugaActivity : MonoBehaviour {

    byte[] GameLogobytes;
    public Texture2D testTex;
    public string stringToEdit;
    AdSize adsize;
    BannerView ADBV;
    AdRequest request;
    InterstitialAd ADLB;
    AdRequest ADLBreq;
    GPGService gpgService;

    // Use this for initialization
    void Start () {

        gpgService = new GPGService();
        DJBeluga.GetInstance().Init("MEMBER", "a0c5560931b60786a9190a29c03a38bc", message);
        //GameLogobytes = testTex.EncodeToPNG();
        //print(GameLogobytes.Length);
        print("call google ads");
        //TT.text = "sTART";
        adsize = new AdSize(300, 50);
        ADBV = new BannerView("ca-app-pub-8757418816557505/7494005598", adsize, AdPosition.Bottom);
        //request = new AdRequest.Builder().Build();
        request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("2E8B2CCE503B3B15EE7E53F3C0E62CE4").Build();
        ADBV.LoadAd(request);
        ADBV.Show();
        //TT.text = "adS";

        ADLB = new InterstitialAd("ca-app-pub-5456471891541902/7764244277");
        ADLBreq = new AdRequest.Builder().Build();
        ADLB.LoadAd(ADLBreq);

        


    }

    // Update is called once per frame
    void Update () {
        //当用户按下手机的返回键或home键退出游戏
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home))
        {
            Application.Quit();
        }

    }


    void OnGUI()
    {
        
        stringToEdit = GUILayout.TextArea(stringToEdit, 200, GUILayout.Width(300), GUILayout.Height(100));

        if (GUILayout.Button("Beluga Login Page", GUILayout.Width(200), GUILayout.Height(50)))
        {
            string appid = "fanadv3";
            string apikey = "4fbc7b551f8ab63d4dadd8694ff261bf";
            string packageID = "com.hosengamers.chee";
            bool inMaintain = false;
            string dialogTitle = "Warnings";// if inMaintain is false setDialog title null
            string dialogMessage = "server in maintain...";// if inMaintain is false setDialog message null
            DJBeluga.GetInstance().AuthClient(appid, apikey, GameLogobytes, packageID, inMaintain, dialogTitle, dialogMessage);
        }

        if (GUILayout.Button("gooogle pay", GUILayout.Width(200), GUILayout.Height(50)))
        {
            string SKU_GAS = "beluga.gold";
            string base64 = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAn2J6q0hd9FhArBYBcKSJabarKunSudfg/LUAwstUY/6UN581eoXEKBo7U2Kd2IA1GaAAXS3vAx4Nv9DAJrurBNof6JpCaEKjhzHLI8TWRqXh77K9dwM8mNMBnN83pP05pRLOMUz33Q/gd1wpQgFzumjl2ai/wAaIqb2YLCvOCUKPIBz5F4RedIySdMfSvIVsDt1FrIOxmPgyL7PFfU42nJMGle7o01hB+vvcMoOaOJu6Kmjkgbru6X6TRWXFfVXY/27iTbCmF1ASsS6btJgQAZr49Km23lZUlV4T+Po9CFfy04PS+uBXJvleUJPuKQe4GMLtcEfUkhQDZpllUvEI7wIDAQAB";
            string UserId = "1030176"; //user id
            string serverId = "server1";
            string role = "leo";
            string orderId = "order123";
            DJBeluga.GetInstance().GooglePayment(SKU_GAS, base64, UserId, serverId, role, orderId);
        }
        if (GUILayout.Button("MOL", GUILayout.Width(200), GUILayout.Height(50)))
        {
            string user_id = "1000005";
            string game_id = "04101786";
            string app_id = "herinv";
            string PackageID = "com.beluga";
            string server_id = "999";
            string role = "leo";
            DJBeluga.GetInstance().MOLPayment(user_id, game_id, app_id,PackageID, server_id, role);
        }
        if (GUILayout.Button("Mycard small pay", GUILayout.Width(200), GUILayout.Height(50)))
        {
            string apikey = "412c1bd510967dce3b050842a35fae18";
            string appid = "kilmasa";
            string uid = "1040714";
            string server_id = "Server1";
            string role = "leo";
            string itemId = "Testing";
            string orderId = "Order123";
            DJBeluga.GetInstance().MyCardSmallPayment(apikey, appid, uid, server_id, role, itemId, orderId);
        }
        if (GUILayout.Button("MyCard s number", GUILayout.Width(200), GUILayout.Height(50)))
        {
            string apikey = "412c1bd510967dce3b050842a35fae18";
            string appid = "kilmasa";
            string uid = "1040714";
            string server_id = "Server1";
            string role = "leo";
            string itemId = "Testing";
            string orderId = "Order123";
            DJBeluga.GetInstance().MyCardSerialNumberPayment(apikey, appid, uid, server_id, role, itemId, orderId);
        }

        if (GUILayout.Button("FB app invite", GUILayout.Width(200), GUILayout.Height(50)))
        {
            DJBeluga.GetInstance().fbAppInvite("","");
        }

        if (GUILayout.Button("FB game invite", GUILayout.Width(200), GUILayout.Height(50)))
        {
            DJBeluga.GetInstance().fbGameInvite("hello","hello");
        }

        if (GUILayout.Button("FB share", GUILayout.Width(200), GUILayout.Height(50)))
        {
            DJBeluga.GetInstance().fbShare("","","","");
        }

        if (GUILayout.Button("Interstitial", GUILayout.Width(200), GUILayout.Height(50)))
        {
            if (ADLB.IsLoaded())
            {
                ADLB.Show();
            }
        }

        if (GUILayout.Button("gpg", GUILayout.Width(200), GUILayout.Height(50))) {
            
            print("test obj:"+ gpgService);
            gpgService.create();
        }

        if (GUILayout.Button("gpg Login", GUILayout.Width(200), GUILayout.Height(50)))
        {
            gpgService.signin();
        }

        if (GUILayout.Button("gpg logout", GUILayout.Width(200), GUILayout.Height(50)))
        {
            gpgService.signout();
        }

        if (GUILayout.Button("gpg showAchievements", GUILayout.Width(200), GUILayout.Height(50)))
        {
            gpgService.showAchievements();
        }

        if (GUILayout.Button("gpg showLeaderboards", GUILayout.Width(200), GUILayout.Height(50)))
        {

            gpgService.showLeaderboards();
        }

        if (GUILayout.Button("gpg unlockAchievements", GUILayout.Width(200), GUILayout.Height(50)))
        {
            string achievements_id = "CgkI1beZi9MBEAIQAQ";
            gpgService.unlockAchievements(achievements_id);
        }

        if (GUILayout.Button("gpg unlockLeaderboards", GUILayout.Width(200), GUILayout.Height(50)))
        {
            string leaderboards_id = "CgkI1beZi9MBEAIQBw";
            long score = 1337;
            gpgService.unlockLeaderboards(leaderboards_id,score);
        }

    }

    //注解2
    void message(string str)
    {
        stringToEdit = str;
    }

    void OnDestroy()
    {
        print("exe disconnect start...");
        gpgService.disconnect();
        print("exe disconnect end...");
    }

}
