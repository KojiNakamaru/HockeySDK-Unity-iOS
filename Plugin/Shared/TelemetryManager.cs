/*******************************************************************************
 *
 * Author: Christoph Wendt
 * 
 * Version 1.1.0
 *
 * Copyright (c) 2013-2015 HockeyApp, Bit Stadium GmbH.
 * All rights reserved.
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 * 
 ******************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace HockeyApp.Unity.Shared {

	public class TelemetryManager {
		
		public TelemetryManager(){}
		
		#if (UNITY_IPHONE && !UNITY_EDITOR)
		[DllImport("__Internal")]
		private static extern void HockeyApp_trackEvent1(string eventName);
		[DllImport("__Internal")]
		private static extern void HockeyApp_trackEvent2(string eventName, string properties);
		[DllImport("__Internal")]
		private static extern void HockeyApp_trackTrace1(string message);
		[DllImport("__Internal")]
		private static extern void HockeyApp_trackTrace2(string message, string properties);
		[DllImport("__Internal")]
		private static extern void HockeyApp_trackMetric1(string metricName, double value);
		[DllImport("__Internal")]
		private static extern void HockeyApp_trackMetric2(string message, double value, string properties);
		[DllImport("__Internal")]
		private static extern void HockeyApp_trackPageView1(string pageName);
		[DllImport("__Internal")]
		private static extern void HockeyApp_trackPageView2(string pageName, long duration);
		[DllImport("__Internal")]
		private static extern void HockeyApp_trackPageView3(string pageName, long duration, string properties);
		[DllImport("__Internal")]
		private static extern void HockeyApp_setAutoPageViewTrackingDisabled(bool autoPageViewTrackingDisabled);
		[DllImport("__Internal")]
		private static extern void HockeyApp_setAutoSessionManagementDisabled(bool autoSessionManagementDisabled);
		[DllImport("__Internal")]
		private static extern void HockeyApp_setServerURL(string serverURL);
		[DllImport("__Internal")]
		private static extern void HockeyApp_startNewSession();
		[DllImport("__Internal")]
		private static extern void HockeyApp_setAppBackgroundTimeBeforeSessionExpires(int backgroundTime);
		[DllImport("__Internal")]
		private static extern void HockeyApp_renewSession(string sessionId);
		#elif (UNITY_ANDROID && !UNITY_EDITOR)
		private static AndroidJavaClass getPluginClass(){
			AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
			AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
			AndroidJavaClass pluginClass = new AndroidJavaClass("net.hockeyapp.unity.HockeyUnityPlugin"); 
			return pluginClass;
		}
		#endif	
		
		public static void TrackEvent(string eventName){
			#if (UNITY_IPHONE && !UNITY_EDITOR)
			HockeyApp_trackEvent1(eventName);
			#elif (UNITY_ANDROID && !UNITY_EDITOR)
			getPluginClass().CallStatic("trackEvent", eventName);
			#endif
		}
		
		public static void TrackEvent(string eventName, Dictionary<string,string> properties){
			#if (UNITY_IPHONE && !UNITY_EDITOR)
			HockeyApp_trackEvent2 (eventName, ConvertToString(properties));
			#elif (UNITY_ANDROID && !UNITY_EDITOR)
			getPluginClass().CallStatic("trackEvent", eventName, properties);
			#endif
		}
		
		public static void TrackTrace(string message){
			#if (UNITY_IPHONE && !UNITY_EDITOR)
			HockeyApp_trackTrace1 (message);
			#elif (UNITY_ANDROID && !UNITY_EDITOR)
			getPluginClass().CallStatic("trackTrace", message);
			#endif
		}
		
		public static void TrackTrace(string message, Dictionary<string,string> properties){
			#if (UNITY_IPHONE && !UNITY_EDITOR)
			HockeyApp_trackTrace2 (message, ConvertToString(properties));
			#elif (UNITY_ANDROID && !UNITY_EDITOR)
			getPluginClass().CallStatic("trackTrace", message, properties);
			#endif
		}

		public static void TrackMetric(string metricName, double value){
			#if (UNITY_IPHONE && !UNITY_EDITOR)
			HockeyApp_trackMetric1 (metricName, value);
			#elif (UNITY_ANDROID && !UNITY_EDITOR)
			getPluginClass().CallStatic("trackMetric", metricName, value);
			#endif
		}
		
		public static void TrackMetric(string metricName, double value, Dictionary<string,string> properties){
			#if (UNITY_IPHONE && !UNITY_EDITOR)
			HockeyApp_trackMetric2 (metricName, value, ConvertToString(properties));
			#elif (UNITY_ANDROID && !UNITY_EDITOR)
			getPluginClass().CallStatic("trackMetric", metricName, value, properties);
			#endif
		}
		
		public static void TrackPageView(string pageName){
			#if (UNITY_IPHONE && !UNITY_EDITOR)
			HockeyApp_trackPageView1 (pageName);
			#elif (UNITY_ANDROID && !UNITY_EDITOR)
			getPluginClass().CallStatic("trackPageView", pageName);
			#endif
		}
		
		public static void TrackPageView(string pageName, long duration){
			#if (UNITY_IPHONE && !UNITY_EDITOR)
			HockeyApp_trackPageView2 (pageName, duration);
			#elif (UNITY_ANDROID && !UNITY_EDITOR)
			getPluginClass().CallStatic("trackPageView", pageName, duration);
			#endif
		}
		
		public static void TrackPageView(string pageName, long duration, Dictionary<string,string> properties){
			#if (UNITY_IPHONE && !UNITY_EDITOR)
			HockeyApp_trackPageView3 (pageName, duration, ConvertToString(properties));
			#elif (UNITY_ANDROID && !UNITY_EDITOR)
			getPluginClass().CallStatic("trackPageView", pageName, duration, properties);
			#endif
		}
		
		public static void SetAutoPageViewTrackingDisabled(bool autoPageViewTrackingDisabled){
			#if (UNITY_IPHONE && !UNITY_EDITOR)
			HockeyApp_setAutoPageViewTrackingDisabled (autoPageViewTrackingDisabled);
			#elif (UNITY_ANDROID && !UNITY_EDITOR)
			getPluginClass().CallStatic("setAutoPageViewTrackingDisabled", autoPageViewTrackingDisabled);
			#endif
		}
		
		public static void SetAutoSessionManagementDisabled(bool autoSessionManagementDisabled){
			#if (UNITY_IPHONE && !UNITY_EDITOR)
			HockeyApp_setAutoSessionManagementDisabled (autoSessionManagementDisabled);
			#elif (UNITY_ANDROID && !UNITY_EDITOR)
			getPluginClass().CallStatic("setAutoSessionManagementDisabled", autoSessionManagementDisabled);
			#endif
		}
		
		public static void SetServerURL(string serverURL){
			#if (UNITY_IPHONE && !UNITY_EDITOR)
			HockeyApp_setServerURL (serverURL);
			#elif (UNITY_ANDROID && !UNITY_EDITOR)
			getPluginClass().CallStatic("setServerURL", serverURL);
			#endif
		}
		
		public static void SetAppBackgroundTimeBeforeSessionExpires(int backgroundTime){
			#if (UNITY_IPHONE && !UNITY_EDITOR)
			HockeyApp_setAppBackgroundTimeBeforeSessionExpires (backgroundTime);
			#elif (UNITY_ANDROID && !UNITY_EDITOR)
			getPluginClass().CallStatic("setAppBackgroundTimeBeforeSessionExpires", backgroundTime);
			#endif
		}
		
		public static void RenewSession(string sessionId){
			#if (UNITY_IPHONE && !UNITY_EDITOR)
			HockeyApp_renewSession (sessionId);
			#elif (UNITY_ANDROID && !UNITY_EDITOR)
			getPluginClass().CallStatic("renewSession", sessionId);
			#endif
		}
		
		//Helper

		#if (UNITY_IPHONE && !UNITY_EDITOR)
		private static string ConvertToString(Dictionary<string,string> dict){
			string dictString = "";
			if (dict != null) {
				foreach(KeyValuePair<string, string> pair in dict)
				{
					dictString += pair.Key + "=" + pair.Value + "\n";
				}
			}
			return dictString;
		}
		#endif

	}
}
