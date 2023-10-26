namespace projeto_busca.Exceptions
{
    [System.Serializable]
    public class OberPremioExeption : System.Exception
    {
        public OberPremioExeption() { }
        public OberPremioExeption(string message) : base(message) { }
        public OberPremioExeption(string message, System.Exception inner) : base(message, inner) { }
        protected OberPremioExeption(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }

}
