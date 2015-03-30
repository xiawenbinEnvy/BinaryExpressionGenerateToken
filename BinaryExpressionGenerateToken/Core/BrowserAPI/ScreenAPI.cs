using System;

namespace Core
{
    /// <summary>
    /// 屏幕api
    /// 可用性：所有浏览器
    /// js引擎可用性：no
    /// </summary>
    class ScreenAPI : IBrowserAPI
    {
        public string GetAPIJSCode()
        {
            string[] s = new string[3] 
            {
                "try {if (typeof window.screen.colorDepth == 'undefined') throw { message : 'error'}; } catch (e) { var err = function() { return "+errorCode+"; }; return err; }",
                "try {if (typeof window.screen.height == 'undefined') throw { message : 'error'}; } catch (e) { var err = function() { return "+errorCode+"; }; return err;  }",
                "try {if (typeof window.screen.width == 'undefined') throw { message : 'error'}; } catch (e) { var err = function() { return "+errorCode+"; }; return err;  }"
            };
            Random ran = new Random();
            int i = ran.Next(0, s.Length);
            return s[i];
        }

        public bool IsThisBrowserEnableThisBrowserAPI(IBrowser browser)
        {
            if (browser == null) return false;

            if (browser is IE6) return true;
            if (browser is IE7) return true;
            if (browser is IE8) return true;
            if (browser is IE9) return true;
            if (browser is IE10) return true;
            if (browser is IE11) return true;
            if (browser is Chrome) return true;
            if (browser is Firefox) return true;
            if (browser is Opera) return true;
            if (browser is Safari) return true;

            return false;
        }


        public string errorCode
        {
            get { return "10000000000"; }
        }
    }
}
