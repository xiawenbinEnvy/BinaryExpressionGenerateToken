
namespace Core
{
    /// <summary>
    /// MessageChannelAPI
    /// 可用性：
    /// Chrome	Firefox (Gecko)	Internet Explorer	Opera	Safari (WebKit)
    ///   4	    Not supported	     10.0	         10.6	      5
    /// js引擎可用性：no
    /// </summary>
    class MessageChannelAPI : IBrowserAPI
    {
        public string GetAPIJSCode()
        {
            return "try { if ( typeof new MessageChannel() != 'object') throw { message : 'no...'}; } catch (e) { var err = function() { return " + errorCode + "; }; return err;  }";
        }


        public bool IsThisBrowserEnableThisBrowserAPI(IBrowser browser)
        {
            if (browser == null) return false;

            if (browser is IE6) return false;
            if (browser is IE7) return false;
            if (browser is IE8) return false;
            if (browser is IE9) return false;
            if (browser is IE10) return true;
            if (browser is IE11) return true;
            if (browser is Chrome) return true;
            if (browser is Firefox) return false;
            if (browser is Opera) return true;
            if (browser is Safari) return true;

            return false;
        }

        public string errorCode
        {
            get { return "20000000000"; }
        }
    }
}
