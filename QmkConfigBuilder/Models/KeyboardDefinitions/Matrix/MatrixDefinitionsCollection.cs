using System.Collections;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout;

namespace QmkConfigBuilder.Models.KeyboardDefinitions.Matrix
{
    public class MatrixDefinitionsCollection : IMatrixDefinitionsCollection
    {
        private readonly IList<MatrixDefinitions> _matrixDefinitionsList;

        public MatrixDefinitionsCollection()
        {
            this._matrixDefinitionsList = new List<MatrixDefinitions>();
        }

        public void AddMatrix(MatrixDefinitions matrixDefinitions)
        {
            if (this._matrixDefinitionsList.Contains(matrixDefinitions))
            {
                return;
            }

            this._matrixDefinitionsList.Add(matrixDefinitions);
        }

        public void RemoveMatrix()
        {
            if (!this._matrixDefinitionsList.Any())
            {
                return;
            }

            var last = this._matrixDefinitionsList.Last();

            this._matrixDefinitionsList.Remove(last);
        }

        public void RemoveMatrix(MatrixDefinitions matrixDefinitions)
        {
            if (!this._matrixDefinitionsList.Contains(matrixDefinitions))
            {
                return;
            }

            this._matrixDefinitionsList.Remove(matrixDefinitions);
        }

        public void SetPin(MatrixDefinitions matrixDefinitions, int index, IPin pin)
        {
            if (!this._matrixDefinitionsList.Contains(matrixDefinitions))
            {
                return;
            }

            var mdIndex = this._matrixDefinitionsList.IndexOf(matrixDefinitions);

            this._matrixDefinitionsList[mdIndex].SetPin(index, pin);
        }

        public void AddPin(MatrixDefinitions matrixDefinitions, IPin pin)
        {
            if (!this._matrixDefinitionsList.Contains(matrixDefinitions))
            {
                return;
            }

            var mdIndex = this._matrixDefinitionsList.IndexOf(matrixDefinitions);

            this._matrixDefinitionsList[mdIndex].AddPin(pin);
        }

        public void RemovePin(MatrixDefinitions matrixDefinitions)
        {
            if (!this._matrixDefinitionsList.Contains(matrixDefinitions))
            {
                return;
            }

            var mdIndex = this._matrixDefinitionsList.IndexOf(matrixDefinitions);

            this._matrixDefinitionsList[mdIndex].RemovePin();
        }

        public void RemovePin(MatrixDefinitions matrixDefinitions, IPin pin)
        {
            if (!this._matrixDefinitionsList.Contains(matrixDefinitions))
            {
                return;
            }

            var mdIndex = this._matrixDefinitionsList.IndexOf(matrixDefinitions);

            this._matrixDefinitionsList[mdIndex].RemovePin(pin);
        }

        public bool ContainsPin(MatrixDefinitions matrixDefinitions, IPin pin)
        {
            if (!this._matrixDefinitionsList.Contains(matrixDefinitions))
            {
                return false;
            }

            var mdIndex = this._matrixDefinitionsList.IndexOf(matrixDefinitions);

            return this._matrixDefinitionsList[mdIndex].ContainsPin(pin);
        }

        public IEnumerator<MatrixDefinitions> GetEnumerator()
        {
            return this._matrixDefinitionsList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
