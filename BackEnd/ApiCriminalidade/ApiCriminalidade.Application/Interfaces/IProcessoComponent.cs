namespace ApiCriminalidade.Application.Interfaces
{
    public interface IProcessoComponent
    {
        public void Run();

        IProcessoComponent Create();
    }
}
