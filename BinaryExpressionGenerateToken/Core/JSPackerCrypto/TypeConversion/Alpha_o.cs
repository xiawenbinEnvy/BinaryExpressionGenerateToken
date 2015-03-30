using System;
namespace Core
{
    /// <summary>
    /// 字符o
    /// </summary>
    class Alpha_o : IAlpha
    {
        public string Get(Random ran)
        {
            return GetCryptoElement.Get(
                RawMetadata.metadataAlpha.GetValues("[object Object]"),
                RawMetadata.metadataNumber.GetValues("1"), ran);
        }
    }
}