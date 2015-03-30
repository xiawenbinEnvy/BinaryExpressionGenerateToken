
namespace Core
{
    /// <summary>
    /// JS的混淆加密接口
    /// </summary>
    interface IJSPackerCrypto
    {
        string JSPackerCrypto(string js);

        IJSPackerCrypto next { get; set; }
    }
}
