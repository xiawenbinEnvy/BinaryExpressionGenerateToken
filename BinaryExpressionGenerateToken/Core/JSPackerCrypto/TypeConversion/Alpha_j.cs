
using System;
namespace Core
{
    /// <summary>
    /// 字符j
    /// </summary>
    class Alpha_j : IAlpha
    {
        public string Get(Random ran)
        {
            return GetCryptoElement.Get(
                RawMetadata.metadataAlpha.GetValues("[object Object]"),
                RawMetadata.metadataNumber.GetValues("3"), ran);
        }
    }
}
