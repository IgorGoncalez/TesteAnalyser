namespace TesteAnalyser.Repository
{
    public interface IRepository
    {
        void BulkInsert();
        void BulkInsertSLL();
        void BulkInsertIsolated();
        void BulkInsertIsolatedSLL();

        void BulkUpdate();
        void BulkUpdateSLL();
        void BulkUpdateIsolated();
        void BulkUpdateIsolatedSLL();

        void BulkDelete();
        void BulkDeleteSLL();
        void BulkDeleteIsolated();
        void BulkDeleteIsolatedSLL();

        void Save();
        void SaveSLL();
        void SaveIsolated();
        void SaveIsolatedSLL();

        void Update();
        void UpdateSLL();
        void UpdateIsolated();
        void UpdateIsolatedSLL();

        void Delete();
        void DeleteSLL();
        void DeleteIsolated();
        void DeleteIsolatedSLL();
    }
}
