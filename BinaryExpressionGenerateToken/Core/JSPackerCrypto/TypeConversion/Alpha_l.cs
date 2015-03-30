
using System;

namespace Core
{
    /// <summary>
    /// 字符l
    /// </summary>
    class Alpha_l : IAlpha
    {
        public string Get(Random ran)
        {
            return GetCryptoElement.Get(
                RawMetadata.metadataAlpha.GetValues("false"),
                RawMetadata.metadataNumber.GetValues("2"), ran);
        }
    }
}
