using System;

namespace Core
{
    /// <summary>
    /// 字符f
    /// </summary>
    class Alpha_f : IAlpha
    {
        public string Get(Random ran)
        {
            return GetCryptoElement.Get(
                RawMetadata.metadataAlpha.GetValues("false"),
                RawMetadata.metadataNumber.GetValues("0"), ran);
        }
    }
}
