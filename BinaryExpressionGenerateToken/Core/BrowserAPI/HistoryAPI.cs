
namespace Core
{
    /// <summary>
    /// 历史浏览记录api
    /// 可用性：所有浏览器
    /// JS引擎可用性：no
    /// </summary>
    class HistoryAPI : IBrowserAPI
    {
        public string GetAPIJSCode()
        {
            return "try { if( typeof window.history != 'object') throw { message:'err' };} catch(e) { var err = function() { return " + errorCode + "; }; return err; } ";
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
            get { return "40000000000"; }
        }
    }
}
