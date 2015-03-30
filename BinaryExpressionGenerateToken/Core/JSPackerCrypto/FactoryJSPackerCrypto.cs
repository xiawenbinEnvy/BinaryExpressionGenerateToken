
namespace Core
{
    /// <summary>
    /// js混淆加密工厂
    /// </summary>
    class FactoryJSPackerCrypto
    {
        public static string Process(string rawJS)
        {
            if (string.IsNullOrEmpty(rawJS)) return rawJS;

            IJSPackerCrypto end = new StandardJSStyle();
            IJSPackerCrypto first = new DeanEdwardPackerCrypto(end);
            return first.JSPackerCrypto(rawJS);
        }
    }
}
