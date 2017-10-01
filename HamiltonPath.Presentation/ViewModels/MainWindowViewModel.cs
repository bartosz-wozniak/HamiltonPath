using System;
using Caliburn.Micro;
using HamiltonPath.BusinessLogic.Algorithm;
using HamiltonPath.BusinessLogic.Serialization;
using HamiltonPath.BusinessLogic.TaskGenerator;
using HamiltonPath.Presentation.Common;
using Microsoft.Win32;

namespace HamiltonPath.Presentation.ViewModels
{
    internal sealed class MainWindowViewModel : Screen
    {
        private readonly ISerializer _serializer;

        private readonly IAlgorithmProvider _algorithmProvider;

        private readonly ITaskGenerator _taskGenerator;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        /// <param name="serializer">Serializer</param>
        /// <param name="algorithmProvider">Algorithm Provider</param>
        /// <param name="taskGenerator">Task Generator</param>
        public MainWindowViewModel(ISerializer serializer, IAlgorithmProvider algorithmProvider, ITaskGenerator taskGenerator)
        {
            _serializer = serializer;
            _algorithmProvider = algorithmProvider;
            _taskGenerator = taskGenerator;
        }

        /// <summary>
        ///     Graph Status parameter
        /// </summary>
        public string GraphLabel { get; set; } = Consts.Labels.GraphNotLoaded;

        /// <summary>
        ///     Found hamilton path result
        /// </summary>
        public string HamiltonPathLabel { get; set; } = Consts.Labels.EmptyHamiltonPath;

        /// <summary>
        ///     Matrix representing graph parameter
        /// </summary>
        public int[,] GraphMatrix { get; set; }

        /// <summary>
        ///     Verticles Count parameter
        /// </summary>
        public int Verticles { get; set; } = 1;

        /// <summary>
        ///     Load file button onclick handler
        /// </summary>
        public async void Load()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = Consts.FileFilters.Txt
            };
            if (openFileDialog.ShowDialog() != true)
            {
                return;
            }
            try
            {
                GraphMatrix = _serializer.Deserialize(openFileDialog.FileName);
                Verticles = GraphMatrix.GetLength(0);
                HamiltonPathLabel = Consts.Labels.EmptyHamiltonPath;
                GraphLabel = Consts.Labels.GraphLoaded;
            }
            catch (Exception ex)
            {
                var dialogManager = IoC.Get<ICustomDialogManager>();
                await dialogManager.DisplayMessageBox(Consts.Errors.Title, Consts.Errors.Info + ex.Message);
            }
        }

        /// <summary>
        ///     Save button onclick handler
        /// </summary>
        public void Save()
        {
            var openFileDialog = new SaveFileDialog
            {
                Filter = Consts.FileFilters.Txt
            };
            if (openFileDialog.ShowDialog() != true)
            {
                return;
            }
            try
            {
                _serializer.Serialize(openFileDialog.FileName, GraphMatrix, HamiltonPathLabel);
            }
            catch (Exception ex)
            {
                var dialogManager = IoC.Get<ICustomDialogManager>();
                dialogManager.DisplayMessageBox(Consts.Errors.Title, Consts.Errors.Info + ex.Message);
            }
        }

        /// <summary>
        ///     Save button onclick handler
        /// </summary>
        public void Generate()
        {
            var openFileDialog = new SaveFileDialog
            {
                Filter = Consts.FileFilters.Txt
            };
            if (openFileDialog.ShowDialog() != true)
            {
                return;
            }
            try
            {
                _taskGenerator.GenerateAndSave(Verticles, openFileDialog.FileName);
            }
            catch (Exception ex)
            {
                var dialogManager = IoC.Get<ICustomDialogManager>();
                dialogManager.DisplayMessageBox(Consts.Errors.Title, Consts.Errors.Info + ex.Message);
            }
        }

        /// <summary>
        ///     Compute button onclick handler
        /// </summary>
        public void Compute()
        {
            try
            {
                HamiltonPathLabel = _algorithmProvider.Compute(GraphMatrix).ToString();
            }
            catch (Exception ex)
            {
                var dialogManager = IoC.Get<ICustomDialogManager>();
                dialogManager.DisplayMessageBox(Consts.Errors.Title, Consts.Errors.Info + ex.Message);
            }
        }
    }
}
