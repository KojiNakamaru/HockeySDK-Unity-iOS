#import "HockeyAppUnity.h"
#import "HockeyAppUnityWrapper.h"

// Helper
char* createStringCopy(const char *string){
	char* res = (char*)malloc(strlen(string) + 1);
	strcpy(res, string);
	return res;
}

void HockeyApp_StartHockeyManager(char *appID, char *serverURL, char *authType, char *secret, bool updateManagerEnabled, bool autoSendEnabled) {
	[HockeyAppUnity startManagerWithIdentifier:[NSString stringWithUTF8String:appID]
																	 serverURL:[NSString stringWithUTF8String:serverURL]
																		authType:[NSString stringWithUTF8String:authType]
																			secret:[NSString stringWithUTF8String:secret]
												updateManagerEnabled:updateManagerEnabled
														 autoSendEnabled:autoSendEnabled];
}

void HockeyApp_ShowFeedbackListView() {
	[HockeyAppUnity showFeedbackListView];
}

char* HockeyApp_GetVersionCode() {
	const char* versionCode = [[HockeyAppUnity versionCode] UTF8String];
	return createStringCopy(versionCode);
}

char* HockeyApp_GetVersionName() {
	const char* versionName = [[HockeyAppUnity versionName] UTF8String];
	return createStringCopy(versionName);
}

char* HockeyApp_GetSdkVersion() {
	const char* sdkVersion = [[HockeyAppUnity sdkVersion] UTF8String];
	return createStringCopy(sdkVersion);
}

char* HockeyApp_GetSdkName() {
	const char* sdkName = [[HockeyAppUnity sdkName] UTF8String];
	return createStringCopy(sdkName);
}

char* HockeyApp_GetBundleIdentifier() {
	const char* bundleIdentifier = [[HockeyAppUnity bundleIdentifier] UTF8String];
	return createStringCopy(bundleIdentifier);
}

//Telemetry

void HockeyApp_setCommonProperties(char *properties){
	[HockeyAppUnity setCommonProperties:[NSString stringWithUTF8String:properties]];
}

void HockeyApp_trackEvent1(char *eventName) {
	[HockeyAppUnity trackEventWithName:[NSString stringWithUTF8String:eventName]];
}

void HockeyApp_trackEvent2(char *eventName, char *properties) {
	[HockeyAppUnity trackEventWithName:[NSString stringWithUTF8String:eventName]
													properties:[NSString stringWithUTF8String:properties]];
}

void HockeyApp_trackTrace1(char *message) {
	[HockeyAppUnity trackTraceWithMessage:[NSString stringWithUTF8String:message]];
}

void HockeyApp_trackTrace2(char *message, char *properties) {
	[HockeyAppUnity trackTraceWithMessage:[NSString stringWithUTF8String:message]
														 properties:[NSString stringWithUTF8String:properties]];
}

void HockeyApp_trackMetric1(char *metricName, double metric) {
	[HockeyAppUnity trackMetricWithName:[NSString stringWithUTF8String:metricName]
																value:metric];
}

void HockeyApp_trackMetric2(char *metricName, double metric, char *properties) {
	[HockeyAppUnity trackMetricWithName:[NSString stringWithUTF8String:metricName]
																value:metric
													 properties:[NSString stringWithUTF8String:properties]];
}

void HockeyApp_trackPageView1(char *pageName) {
	[HockeyAppUnity trackPageView:[NSString stringWithUTF8String:pageName]];
}

void HockeyApp_trackPageView2(char *pageName, long duration) {
	[HockeyAppUnity trackPageView:[NSString stringWithUTF8String:pageName]
											 duration:duration];
}

void HockeyApp_trackPageView3(char *pageName, long duration, char *properties) {
	[HockeyAppUnity trackPageView:[NSString stringWithUTF8String:pageName]
											 duration:duration
										 properties:[NSString stringWithUTF8String:properties]];
}

void HockeyApp_setAutoPageViewTrackingDisabled(bool autoPageViewTrackingDisabled){
	[HockeyAppUnity setAutoPageViewTrackingDisabled:autoPageViewTrackingDisabled];
}

void HockeyApp_setAutoSessionManagementDisabled(bool autoSessionManagementDisabled){
	[HockeyAppUnity setAutoSessionManagementDisabled:autoSessionManagementDisabled];
}

void HockeyApp_setServerURL(char *serverURL){
	[HockeyAppUnity setServerURL:[NSString stringWithUTF8String:serverURL]];
}

void HockeyApp_setAppBackgroundTimeBeforeSessionExpires(int appBackgroundTime){
	[HockeyAppUnity setAppBackgroundTimeBeforeSessionExpires:appBackgroundTime];
}

void HockeyApp_renewSession(char *sessionId){
	[HockeyAppUnity renewSessionWithId:[NSString stringWithUTF8String:sessionId]];
}
