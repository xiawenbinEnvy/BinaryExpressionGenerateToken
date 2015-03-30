
using System;
namespace Core
{
    /// <summary>
    /// 字符c
    /// </summary>
    class Alpha_c : IAlpha
    {
        public string Get(Random ran)
        {
            return GetCryptoElement.Get(
                RawMetadata.metadataAlpha.GetValues("[object Object]"),
                RawMetadata.metadataNumber.GetValues("5"), ran);
        }
    }
}
