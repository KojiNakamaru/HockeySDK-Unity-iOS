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
