
using System;
namespace Core
{
    /// <summary>
    /// 空格
    /// </summary>
    class Space : IAlpha
    {
        public string Get(Random ran)
        {
            return GetCryptoElement.Get(
                RawMetadata.metadataAlpha.GetValues("[object Object]"),
                RawMetadata.metadataNumber.GetValues("7"), ran);
        }
    }
}
