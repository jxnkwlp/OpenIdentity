namespace OpenIdentity
{
    public class Secret
    {
        public virtual string Value { get; set; }
        public virtual SecretType Type { get; set; }
    }
}
