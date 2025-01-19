//модель данных
namespace backend;

public class Player
{
    public int Id { get; set; } // Первичный ключ
    public string Name { get; set; } // Имя игрока
    public float Time { get; set; } // Результат времени
}