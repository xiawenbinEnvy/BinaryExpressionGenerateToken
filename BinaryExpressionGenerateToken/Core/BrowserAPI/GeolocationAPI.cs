using System;

namespace Core
{
    /// <summary>
    /// 地理位置api
    /// 可用性：
    /// Chrome	Firefox (Gecko)	Internet Explorer	Opera	Safari
    ///   5	     3.5 (1.9.1)	    9	            10.60     5
    /// js引擎可用性：no
    /// </summary>
    class GeolocationAPI : IBrowserAPI
    {
        public string GetAPIJSCode()
        {
            string s1 = "try { if(typeof navigator.geolocation.watchPosition != 'function') throw { message:'fk' } } catch(e) { var err = function() { return " + errorCode + "; }; return err; } ";
            string s2 = "try { if(typeof navigator.geolocation.getCurrentPosition != 'function') throw { message:'fk' } } catch(e) { var err = function() { return " + errorCode + "; }; return err; } "; 
            return DateTime.Now.Second % 2 == 0 ? s1 : s2;
        }

        public bool IsThisBrowserEnableThisBrowserAPI(IBrowser browser)
        {
            if (browser == null) return false;

            if (browser is IE6) return false;
            if (browser is IE7) return false;
            if (browser is IE8) return false;
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
            get { return "50000000000"; }
        }
    }
}
