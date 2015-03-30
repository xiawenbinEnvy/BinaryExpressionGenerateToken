using System;
using System.Linq;

namespace Core
{
    /// <summary>
    /// 字符b
    /// </summary>
    class Alpha_b : IAlpha
    {
        public string Get(Random ran)
        {
            return GetCryptoElement.Get(
                RawMetadata.metadataAlpha.GetValues("[object Object]"),
                RawMetadata.metadataNumber.GetValues("2").Union(RawMetadata.metadataNumber.GetValues("9")), ran);
        }
    }
}
