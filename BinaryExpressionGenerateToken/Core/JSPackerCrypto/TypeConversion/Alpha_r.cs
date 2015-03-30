
using System;
namespace Core
{
    /// <summary>
    /// 字符r
    /// </summary>
    class Alpha_r : IAlpha
    {
        public string Get(Random ran)
        {
            return GetCryptoElement.Get(
                RawMetadata.metadataAlpha.GetValues("true"),
                RawMetadata.metadataNumber.GetValues("1"), ran);
        }
    }
}
