/// <summary>
/// Stack Fonksiyon ve Propertyleri tanimlayan interface
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IStack<T>
{
    /// <summary>
    /// Eleman adedini Tutar.
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Yığına öğeyi ekleme islemi yapar.
    /// </summary>
    /// <param name="item">Eklenmek istenen deger</param>
    void Push(T item);

    /// <summary>
    /// Yigin yapisinin bosaltilmasi.
    /// </summary>
    void Clear();

    /// <summary>
    /// Yigin yapisindaki en son degeri getirir.
    /// </summary>
    /// <returns>T degeri</returns>
    T Peek();

    /// <summary>
    /// Yigindan en son ogeyi kaldirir ve degeri geri donderir
    /// </summary>
    /// <returns>T value</returns>
    T Pop();
    
}
