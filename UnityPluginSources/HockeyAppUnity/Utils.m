/*
 * Author: Christoph Wendt
 *
 * Version: 1.0.9
 *
 * Copyright (c) 2013-2014 HockeyApp, Bit Stadium GmbH.
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

#import "Utils.h"

@implementation Utils

+ (BITAuthenticatorIdentificationType)identificationTypeForString:(NSString *)typeString{
  
  if ([typeString isEqualToString:@"BITAuthenticatorIdentificationTypeDevice"]){
    
    return BITAuthenticatorIdentificationTypeDevice;
  }else if ([typeString isEqualToString:@"BITAuthenticatorIdentificationTypeHockeyAppUser"]){
    
    return BITAuthenticatorIdentificationTypeHockeyAppUser;
  }else if ([typeString isEqualToString:@"BITAuthenticatorIdentificationTypeHockeyAppEmail"]){
    
    return BITAuthenticatorIdentificationTypeHockeyAppEmail;
  }else if ([typeString isEqualToString:@"BITAuthenticatorIdentificationTypeWebAuth"]){
    
    return BITAuthenticatorIdentificationTypeWebAuth;
  }else{
    
    return BITAuthenticatorIdentificationTypeAnonymous;
  }
}

+ (BITCrashManagerStatus)statusForAutoSendEnabled:(BOOL)autoSendEnabled{
  
  if (autoSendEnabled){
    return BITCrashManagerStatusAutoSend;
  }
  
  return BITCrashManagerStatusAlwaysAsk;
}

+ (NSDictionary *)dictionaryFromString:(NSString *)dictString{
	
	NSArray *keyValuePairs = [dictString componentsSeparatedByString:@"\n"];
	NSMutableDictionary *dict = [NSMutableDictionary new];
	
	for(NSString *pair in keyValuePairs){
		NSRange range = [pair rangeOfString:@"="];
		if (range.location != NSNotFound) {
			NSString *key = [pair substringToIndex:range.location];
			NSString *value = [pair substringFromIndex:range.location+1];
			dict[key] = value;
		}
	}
	return dict;
}

@end
