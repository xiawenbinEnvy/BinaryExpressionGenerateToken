using System;

namespace Core
{
    /// <summary>
    /// 字符s
    /// </summary>
    class Alpha_s : IAlpha
    {
        public string Get(Random ran)
        {
            return GetCryptoElement.Get(
                RawMetadata.metadataAlpha.GetValues("false"),
                RawMetadata.metadataNumber.GetValues("3"), ran);
        }
    }
}
