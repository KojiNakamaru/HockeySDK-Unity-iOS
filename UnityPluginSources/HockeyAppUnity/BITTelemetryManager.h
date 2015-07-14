/*
 * Author: Christoph Wendt
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
 */

#import "BITHockeyBaseManager.h"
@class MSAIUser;
@class MSAINullability;

NS_ASSUME_NONNULL_BEGIN

@interface BITTelemetryManager : BITHockeyBaseManager

///-----------------------------------------------------------------------------
/// @name Common Properties
///-----------------------------------------------------------------------------

/**
 *  Set any dictionary of key-value pairs which will then be attached to every telemetry item that is sent.
 *
 *  @param commonProperties The dictionary containing the key-value pairs.
 *
 *  @warning All of the values in this dictionary have to be NSJSONSerialization compatible!
 */
- (void)setCommonProperties:(NSDictionary *)commonProperties;

/**
 *  The dictionary of key-value pares that will be attached to every telemetry item.
 *
 *  @warning All of the values in this dictionary have to be NSJSONSerialization compatible!
 */
- (NSDictionary *)commonProperties;

///-----------------------------------------------------------------------------
/// @name Track data
///-----------------------------------------------------------------------------

/**
 *  Track the event by event name.
 *
 *  @param eventName the name of the event, which should be tracked.
 */
- (void)trackEventWithName:(NSString *)eventName;

/**
 *  Track the event by event name and customized properties.
 *
 *  @param eventName the name of the event, which should be tracked.
 *  @param properties key value pairs with additional info about the event.
 */
- (void)trackEventWithName:(NSString *)eventName properties:(nullable NSDictionary *)properties;

/**
 *  Track the event by event name and customized properties and metrics.
 *
 *  @param eventName the name of the event, which should be tracked.
 *  @param properties key value pairs with additional info about the event.
 *  @param measurements key value pairs, which contain custom metrics.
 */
- (void)trackEventWithName:(NSString *)eventName properties:(nullable NSDictionary *)properties measurements:(nullable NSDictionary *)measurements;

/**
 *  Track by message.
 *
 *  @param message a message, which should be tracked.
 */
- (void)trackTraceWithMessage:(NSString *)message;

/**
 *  Track with the message and custom properties.
 *
 *  @param message a message, which should be tracked.
 *  @param properties key value pairs with additional info about the trace.
 */
- (void)trackTraceWithMessage:(NSString *)message properties:(nullable NSDictionary *)properties;

/**
 *  Track metric by name and value.
 *
 *  @param metricName the name of the metric.
 *  @param value a numeric value, which should be tracked.
 */
- (void)trackMetricWithName:(NSString *)metricName value:(double)value;

/**
 *  Track metric by name and value and custom properties.
 *
 *  @param metricName the name of the metric.
 *  @param value a numeric value, which should be tracked.
 *  @param properties key value pairs with additional info about the metric.
 */
- (void)trackMetricWithName:(NSString *)metricName value:(double)value properties:(nullable NSDictionary *)properties;

/**
 * Track pageView by name of the page.
 *
 *  @param pageName Name of the page/view which is being tracked.
 */
- (void)trackPageView:(NSString *)pageName;

/**
 *  Track pageView by name of the page.
 *
 *  @param pageName Name of the page/view which is being tracked.
 *  @param duration Time the page has been viewed in milliseconds. This method is ideally called when a page view ends where the time has to be calculated by the developer.
 */
- (void)trackPageView:(NSString *)pageName duration:(long)duration;

/**
 * Track pageView by name of the page.
 *
 *  @param pageName Name of the page/view which is being tracked.
 *  @param duration time the page has been viewed. This method is ideally called when a page view ends. The time has to be calculated by the developer.
 *  @param properties key-value pairs which can contain additional information about the page view
 */
- (void)trackPageView:(NSString *)pageName duration:(long)duration properties:(nullable NSDictionary *)properties;

/**
 *  Track handled exception.
 *
 *  @param exception the handled exception, which should be send to the server.
 */
- (void)trackException:(NSException *)exception;

/**
 *  Enable (NO) or disable (YES) auto collection of page views. This should be called before `start`.
 *
 *  @param autoPageViewTrackingDisabled Flag which determines whether the page view collection should be disabled
 */
- (void)setAutoPageViewTrackingDisabled:(BOOL)autoPageViewTrackingDisabled;

/**
 *  Disable (YES) automatic session management and renewal.
 *
 *  @param autoSessionManagementDisabled Flag that determines whether automatic session management should be disabled.
 */
- (void)setAutoSessionManagementDisabled:(BOOL)autoSessionManagementDisabled;

- (void)setServerURL:(NSString *)serverURL;

/**
 *  Use this method to configure the current user's context.
 *
 *  @param userConfigurationBlock This block gets the current user as an input.
 *  Within the block you can update the user object's values to up-to-date.
 */
- (void)setUserWithConfigurationBlock:(void (^)(MSAIUser *user))userConfigurationBlock;

/**
 *  Manually trigger a new session start.
 */
- (void)startNewSession;

/**
 *  Set the time which the app has to have been in the background for before a new session is started.
 *  This time is only used when automatic session management is not disabled.
 *
 *  @param appBackgroundTimeBeforeSessionExpires The time in seconds the app has to be in the background before a new session is started.
 */
- (void)setAppBackgroundTimeBeforeSessionExpires:(NSUInteger)appBackgroundTimeBeforeSessionExpires;

/**
 *  This starts a new session with the given session ID.
 *
 *  @param sessionId The session ID which should be attached to all future telemetry and crash events.
 *
 *  @warning Using this method automatically disables automatic session management!
 *  @see autoSessionManagementDisabled
 */
- (void)renewSessionWithId:(NSString *)sessionId;

@end

NS_ASSUME_NONNULL_END
