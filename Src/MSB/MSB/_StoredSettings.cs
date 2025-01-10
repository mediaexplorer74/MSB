using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace FitBand {
    public static class StoredSettings {
        public static class StoredStringValues 
        {
            public static string RefreshToken;
            public static string ImplicitAccessToken;
        }

        public static async Task<string> TryLoad(string refreshToken) 
        {
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            string TT = "";

            try 
            {
                //refreshToken = (string)localSettings.Values["implicitAccessToken"];
                StoredStringValues.RefreshToken = (string)localSettings.Values["token"];
                StoredStringValues.ImplicitAccessToken = (string)localSettings.Values["implicitAccessToken"];

            }
            catch { }

            return TT;
        }


        public static async Task Save(string implicitAccessToken, string token) 
        {
            //throw new NotImplementedException();
            //Task Ts = null;


            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            // Save a setting locally on the device
            try 
            {
                localSettings.Values["implicitAccessToken"] = implicitAccessToken;
            }
            catch { }

            try 
            {
                localSettings.Values["token"] = token;
            }
            catch { }

            return;
        }
    }
}