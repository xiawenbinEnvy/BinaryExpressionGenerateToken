using System;

namespace Core
{
    /// <summary>
    /// 字符e
    /// </summary>
    class Alpha_e : IAlpha
    {
        public string Get(Random ran)
        {
            return GetCryptoElement.Get(
                RawMetadata.metadataAlpha.GetValues("true"),
                RawMetadata.metadataNumber.GetValues("3"), ran);
        }
    }
}
