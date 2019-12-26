using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DevInfoSet
{
    public SinaWeiboDevInfo sinaweibo;
}

[Serializable]
public class SinaWeiboDevInfo
{
#if UNITY_ANDROID
		public const int type = 1;
		public string SortId = "4";
		public string AppKey = "4191425580";
		public string AppSecret = "4e7c497303ba9487b8f5912f82c5f10f";
		public string RedirectUrl = "http://www.zizouqi.com";
		public bool ShareByAppClient = true;
#elif UNITY_IPHONE
		public const int type = 2;
		public string app_key = "4191425580";
		public string app_secret = "4e7c497303ba9487b8f5912f82c5f10f";
		public string redirect_uri = "http://www.zizouqi.com";
//		public string auth_type = "both";	//can pass "both","sso",or "web"  
#endif
}