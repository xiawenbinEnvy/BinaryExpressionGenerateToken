
namespace Core
{
    /// <summary>
    /// 标准化js格式
    /// </summary>
    class StandardJSStyle : IJSPackerCrypto
    {
        public string JSPackerCrypto(string js)
        {
            return "<script>" + js + "</script>";
        }

        public IJSPackerCrypto next
        {
            get;
            set;
        }
    }
}
