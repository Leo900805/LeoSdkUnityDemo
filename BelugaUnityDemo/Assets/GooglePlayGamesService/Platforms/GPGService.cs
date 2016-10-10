using UnityEngine;
using GooglePlayGameService.utils;

namespace GooglePlayGameService
{
    public class GPGService
    {
        private AndroidJavaObject gpg;
        private AndroidJavaClass playerClass;
        private AndroidJavaObject activity ;

        public GPGService() {
            playerClass = new AndroidJavaClass(GPGServiceUtil.UnityActivityClassName);
            activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            gpg = new AndroidJavaObject(GPGServiceUtil.GPGViewClassName);
        }

        public void create()
        {
            gpg.CallStatic("gpg", activity);

        }

        public void signin()
        {
            gpg.CallStatic("gpgLogin");
        }

        public void signout()
        {
            gpg.CallStatic("gpgLogout");
        }

        public void showLeaderboards()
        {
            gpg.CallStatic("showLeaderboards");
        }

        public void showAchievements()
        {
            gpg.CallStatic("showAchievements");
        }

        public void unlockLeaderboards(string leaderboards_id, long score)
        {
            gpg.CallStatic("unlockLeaderboards", leaderboards_id, score);
        }

        public void unlockAchievements(string achievements_id)
        {
            gpg.CallStatic("unlockAchievements",achievements_id);
        }

        public void disconnect()
        {
            gpg.CallStatic("disconnect");
        }
    }
}

