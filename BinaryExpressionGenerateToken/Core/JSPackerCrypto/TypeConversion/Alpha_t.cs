
using System;

namespace Core
{
    /// <summary>
    /// 字符t
    /// </summary>
    class Alpha_t : IAlpha
    {
        public string Get(Random ran)
        {
            return GetCryptoElement.Get(
                 RawMetadata.metadataAlpha.GetValues("true"),
                 RawMetadata.metadataNumber.GetValues("0"), ran);
        }
    }
}
