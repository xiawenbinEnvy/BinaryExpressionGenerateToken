


namespace Core
{
    class DeanEdwardPackerCrypto : IJSPackerCrypto
    {
        public DeanEdwardPackerCrypto(IJSPackerCrypto next)
        {
            this.next = next;
        }

        public string JSPackerCrypto(string js)
        {
            string after = new ECMAScriptPacker().Pack(js);
            if (next != null) return next.JSPackerCrypto(after);
            return after;
        }

        public IJSPackerCrypto next
        {
            get;
            set;
        }
    }
}
