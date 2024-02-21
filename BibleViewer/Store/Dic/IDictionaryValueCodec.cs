namespace BibleViewer.Store.Dic
{
    public interface IDictionaryValueCodec<T>
    {
        string Encode(T value);

        T Decode(string s);
    }
}
