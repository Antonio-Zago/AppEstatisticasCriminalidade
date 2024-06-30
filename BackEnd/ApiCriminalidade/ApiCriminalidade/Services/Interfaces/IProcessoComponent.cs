namespace ApiCriminalidade.Services.Interfaces
{
    public interface IProcessoComponent
    {
        public void Run();

        IProcessoComponent Create();
    }
}
