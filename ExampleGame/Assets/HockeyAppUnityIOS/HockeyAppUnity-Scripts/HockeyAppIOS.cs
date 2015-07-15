/*******************************************************************************
 *
 * Author: Christoph Wendt
 * 
 * Version 1.0.9
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

public class TelemetryManager {

	public TelemetryManager(){

	}

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
	private static extern void HockeyApp_trackPageView1(string message, string properties);
	[DllImport("__Internal")]
	private static extern void HockeyApp_trackPageView2(string message, long duration);
	[DllImport("__Internal")]
	private static extern void HockeyApp_trackPageView3(string message, long duration, string properties);
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
	#endif

	public static void TrackEvent(string eventName){

	}

	public static void TrackEvent(string eventName, Dictionary<string,string> properties){
		
	}

	public static void TrackTrace(string message){
		
	}

	public static void TrackTrace(string message, Dictionary<string,string> properties){
		
	}

	public static void TrackPageView(string pageName){
		
	}

	public static void TrackPageView(string pageName, long duraction){
		
	}

	public static void TrackPageView(string message, long duraction, Dictionary<string,string> properties){
		
	}

	public static void SetAutoPageViewTrackingDisabled(bool autoPageViewTrackingDisabled){
		
	}

	public static void SetAutoSessionManagementDisabled(bool autoSessionManagementDisabled){
		
	}
	
	public static void SetServerURL(string serverURL){
		
	}

	public static void StartNewSession(){
		
	}

	public static void SetAppBackgroundTimeBeforeSessionExpires(int backgroundTime){
		
	}

	public static void RenewSession(string sessionId){
		
	}



}