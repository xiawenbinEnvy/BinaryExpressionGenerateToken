
namespace Core
{
    /// <summary>
    /// MediaDeviceAPI
    /// 可用性：firefox可用，ie和chrome都不行
    /// js引擎可用性：no
    /// </summary>
    class MediaDeviceAPI : IBrowserAPI
    {
        public string GetAPIJSCode()
        {
            return "try { if (typeof navigator.mediaDevices != 'object') throw { message : 'what?'}; } catch (e) { var err = function() { return " + errorCode + "; }; return err;  }";
        }

        public bool IsThisBrowserEnableThisBrowserAPI(IBrowser browser)
        {
            if (browser == null) return false;

            if (browser is IE6) return false;
            if (browser is IE7) return false;
            if (browser is IE8) return false;
            if (browser is IE9) return false;
            if (browser is IE10) return false;
            if (browser is IE11) return false;
            if (browser is Chrome) return false;
            if (browser is Firefox) return true;
            if (browser is Opera) return false;
            if (browser is Safari) return false;

            return false;
        }

        public string errorCode
        {
            get { return "30000000000"; }
        }
    }
}
