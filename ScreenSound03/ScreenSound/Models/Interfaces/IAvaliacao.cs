
namespace ScreenSound.Models.Interfaces;

internal interface IAvaliacao
{
    double Media { get; }
    public void AdicionarNota(Avaliacao nota);
}
