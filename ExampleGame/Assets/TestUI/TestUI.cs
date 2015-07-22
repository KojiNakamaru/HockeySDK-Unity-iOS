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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using HockeyApp.Unity.Shared;

namespace HockeyApp.Unity.Example.iOS {
	public class TestUI : MonoBehaviour{
		
		public GUISkin customUISkin;
		private int controlHeight = 64;
		private int horizontalMargin = 20;
		private int space = 20;
		
		#if (UNITY_IPHONE && !UNITY_EDITOR)
		[DllImport("__Internal")]
		private static extern void ExamplePlugin_ForceAppCrash();
		[DllImport("__Internal")]
		private static extern void HockeyApp_ShowFeedbackListView();
		#endif
		
		void OnGUI(){	
			
			AutoResize (640, 1136);
			GUI.skin = customUISkin;
			
			GUI.Label(GetControlRect(1), "HockeyApp Unity");
			
			if(GUI.Button(GetControlRect(2), "Index Out Of Range"))
			{
				string[] arr	= new string[3];
				arr[4]	= "Out of Range";
			}
			
			if(GUI.Button(GetControlRect(3), "Native Code Crash"))
			{	
				ForceAppCrash();	
			}

			if(GUI.Button(GetControlRect(4), "Track Event"))
			{	
				Dictionary<string,string> properties = new Dictionary<string,string>();
				properties.Add("Custom event property", "Custom value");
				TelemetryManager.TrackEvent("My custom event", properties);
			}

			if(GUI.Button(GetControlRect(5), "Track Message"))
			{	
				Dictionary<string,string> properties = new Dictionary<string,string>();
				properties.Add("Custom message property", "Custom value");
				TelemetryManager.TrackTrace("My custom message", properties);
			}
			
			if(GUI.Button(GetControlRect(6), "Track metric"))
			{	
				Dictionary<string,string> properties = new Dictionary<string,string>();
				properties.Add("Custom metric property", "Custom value");
				TelemetryManager.TrackMetric("My custom metric", 2.2);	
			}
			
			if(GUI.Button(GetControlRect(7), "Track page view"))
			{	
				Dictionary<string,string> properties = new Dictionary<string,string>();
				properties.Add("Custom page view property", "Custom value");
				TelemetryManager.TrackPageView("Menu page", 20000, properties);	
			}
			
			if(GUI.Button(GetControlRect(8), "Start new Session"))
			{	
				TelemetryManager.StartNewSession();	
			}
			
			GUI.Label(GetControlRect(9), "Features");
			
			if(GUI.Button(GetControlRect(10), "Show Feedback Form"))
			{	
				ShowFeedbackForm();
			}
		}
		public void AutoResize(int screenWidth, int screenHeight){
			
			Vector2 resizeRatio = new Vector2((float)Screen.width / screenWidth, (float)Screen.height / screenHeight);
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(resizeRatio.x, resizeRatio.y, 1.0f));
		}
		
		System.Collections.IEnumerator CorutineNullCrash(){
			
			string crash = null;
			crash	= crash.ToLower();
			yield break;
		}
		
		System.Collections.IEnumerator CorutineCrash(){	
			
			throw new Exception("Custom Coroutine Exception");
		}
		
		private Rect GetControlRect(int controlIndex){
			
			return new Rect (horizontalMargin,
			                 controlIndex * (controlHeight + space),
			                 640 - (2 * horizontalMargin),
			                 controlHeight);
		}
		
		public void NullReferenceException(){
			object testObject = null;
			testObject.GetHashCode();
		}
		
		public void ForceAppCrash(){
			
			#if (UNITY_IPHONE && !UNITY_EDITOR)
			ExamplePlugin_ForceAppCrash();
			#endif
		}
		
		public void ShowFeedbackForm(){
			
			#if (UNITY_IPHONE && !UNITY_EDITOR)
			HockeyApp_ShowFeedbackListView();
			#endif
		}
	}
}

