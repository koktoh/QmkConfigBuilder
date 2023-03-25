using System.Collections;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout;

namespace QmkConfigBuilder.Models.KeyboardDefinitions.Matrix
{
    public interface IMatrixDefinitionsCollection : IEnumerable<MatrixDefinitions>, IEnumerable
    {
        void AddMatrix(MatrixDefinitions matrixDefinitions);
        void RemoveMatrix();
        void RemoveMatrix(MatrixDefinitions matrixDefinitions);
        void SetPin(MatrixDefinitions matrixDefinitions, int index, IPin pin);
        void AddPin(MatrixDefinitions matrixDefinitions, IPin pin);
        void RemovePin(MatrixDefinitions matrixDefinitions);
        void RemovePin(MatrixDefinitions matrixDefinitions, IPin pin);
        bool ContainsPin(MatrixDefinitions matrixDefinitions, IPin pin);
    }
}
