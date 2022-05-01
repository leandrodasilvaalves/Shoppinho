namespace Shoppinho.Sdk.Core.Bases
{
    public abstract class Comparavel<T> where T : class
    {

        public override bool Equals(object? obj)
        {
            var objComparar = obj as Comparavel<T>;

            if (ReferenceEquals(this, objComparar)) return true;
            if (ReferenceEquals(null, objComparar)) return false;

            return Igual(objComparar as T);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() ^ 93) + GerarHashCode();
        }

        public abstract bool Igual(T obj);
        public abstract int GerarHashCode();
    }
}