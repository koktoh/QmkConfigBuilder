using QmkConfigBuilder.Models.KeyboardDefinitions.Matrix;

namespace QmkConfigBuilder.StateContainer
{
    public interface IMatrixStateContainer
    {
        bool EditingMatrixRow { get; set; }
        bool EditingMatrixColumn { get; set; }
        bool EditingMatrix { get; }
        MatrixDefinitions? SelectedMatrix { get; set; }

        event Action? OnMatrixEditingStateChanged;
        event Action? OnSelectedMatrixChanged;
        event Action? OnMatrixChanged;


        IEnumerable<MatrixDefinitions> GetMatrixDefinitions(MatrixType matrixType);
        void AddMatrixRow();
        void AddMatrixRow(MatrixDefinitions matrixDefinitions);
        void AddMatrixColumn();
        void AddMatrixColumn(MatrixDefinitions matrixDefinitions);
        void RemoveMatrixRow();
        void RemoveMatrixRow(MatrixDefinitions matrixDefinitions);
        void RemoveMatrixColumn();
        void RemoveMatrixColumn(MatrixDefinitions matrixDefinitions);
    }
}
