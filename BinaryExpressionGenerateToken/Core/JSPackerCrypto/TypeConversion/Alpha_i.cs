
using System;

namespace Core
{
    /// <summary>
    /// 字符i
    /// </summary>
    class Alpha_i : IAlpha
    {
        public string Get(Random ran)
        {
            return GetCryptoElement.Get(
                RawMetadata.metadataAlpha.GetValues("undefined"),
                RawMetadata.metadataNumber.GetValues("5"), ran);
        }
    }
}
