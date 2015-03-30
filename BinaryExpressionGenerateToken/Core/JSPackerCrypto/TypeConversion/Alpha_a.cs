
using System;
namespace Core
{
    /// <summary>
    /// 字符a
    /// </summary>
    class Alpha_a : IAlpha
    {
        public string Get(Random ran)
        {
            return GetCryptoElement.Get(
                RawMetadata.metadataAlpha.GetValues("false"),
                RawMetadata.metadataNumber.GetValues("1"), ran);
        }
    }
}
