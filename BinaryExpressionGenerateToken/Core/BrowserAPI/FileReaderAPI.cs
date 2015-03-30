
namespace Core
{
    /// <summary>
    /// FileReader API
    /// 可用性：
    /// Firefox (Gecko)	Chrome	Internet Explorer*	Opera*	Safari
    ///   3.6 (1.9.2)	  7	          10	        未实现	未实现
    /// js引擎可用性:no
    /// </summary>
    class FileReaderAPI : IBrowserAPI
    {
        public string GetAPIJSCode()
        {
            return "try { new FileReader(); } catch (e) { var err = function() { return " + errorCode + "; }; return err;  }"; 
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
            if (browser is Firefox) return true;
            if (browser is Opera) return false;
            if (browser is Safari) return false;

            return false;
        }

        public string errorCode
        {
            get { return "60000000000"; }
        }
    }
}
