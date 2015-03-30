using System;
using System.Linq;

namespace Core
{
    /// <summary>
    /// 字符n
    /// </summary>
    class Alpha_n : IAlpha
    {
        public string Get(Random ran)
        {
            return GetCryptoElement.Get(
                RawMetadata.metadataAlpha.GetValues("undefined"),
                RawMetadata.metadataNumber.GetValues("1").Union(RawMetadata.metadataNumber.GetValues("6")), ran);
        }
    }
}
