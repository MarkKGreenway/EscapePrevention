namespace EscapePrevention.EscapeKinds
{
    public class UrlSpaceReplacementStrategy : UrlEscapeStrategy
    {
        public UrlSpaceReplacementStrategy() : base(EscapePreventionKind.UrlSpaceReplacement, "_")
        {}
    }
}