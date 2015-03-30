using System;

namespace Core
{
    /// <summary>
    /// 字符u
    /// </summary>
    class Alpha_u : IAlpha
    {
        public string Get(Random ran)
        {
            return GetCryptoElement.Get(
                RawMetadata.metadataAlpha.GetValues("true"),
                RawMetadata.metadataNumber.GetValues("2"), ran);
        }
    }
}
