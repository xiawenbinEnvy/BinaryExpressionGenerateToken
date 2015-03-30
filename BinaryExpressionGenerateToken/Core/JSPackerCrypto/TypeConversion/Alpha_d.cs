using System;
using System.Linq;

namespace Core
{
    /// <summary>
    /// 字符d
    /// </summary>
    class Alpha_d : IAlpha
    {
        public string Get(Random ran)
        {
            return GetCryptoElement.Get(
                RawMetadata.metadataAlpha.GetValues("undefined"),
                RawMetadata.metadataNumber.GetValues("2").Union(RawMetadata.metadataNumber.GetValues("8")), ran);
        }
    }
}
