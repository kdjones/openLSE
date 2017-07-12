// COMPILER GENERATED CODE
// THIS WILL BE OVERWRITTEN AT EACH GENERATION
// EDIT AT YOUR OWN RISK

using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ECAClientFramework;
using ECAClientUtilities;
using ECACommonUtilities;
using ECACommonUtilities.Model;
using GSF.TimeSeries;

namespace openLSE.Model
{
    [CompilerGenerated]
    public class Mapper : MapperBase
    {
        #region [ Members ]

        // Fields
        private readonly Unmapper m_unmapper;

        #endregion

        #region [ Constructors ]

        public Mapper(Framework framework)
            : base(framework, SystemSettings.InputMapping)
        {
            m_unmapper = new Unmapper(framework, MappingCompiler);
            Unmapper = m_unmapper;
        }

        #endregion

        #region [ Methods ]

        public override void Map(IDictionary<MeasurementKey, IMeasurement> measurements)
        {
            SignalLookup.UpdateMeasurementLookup(measurements);
            TypeMapping inputMapping = MappingCompiler.GetTypeMapping(InputMapping);

            Reset();
            openLSE.Model.LSE.Input inputData = CreateLSEInput(inputMapping);
            Reset();
            openLSE.Model.LSE._InputMeta inputMeta = CreateLSE_InputMeta(inputMapping);

            Algorithm.Output algorithmOutput = Algorithm.Execute(inputData, inputMeta);
            Subscriber.SendMeasurements(m_unmapper.Unmap(algorithmOutput.OutputData, algorithmOutput.OutputMeta));
        }

        private openLSE.Model.LSE.Input CreateLSEInput(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            openLSE.Model.LSE.Input obj = new openLSE.Model.LSE.Input();

            {
                // Create openLSE.Model.ECA.Digitals UDT for "Digitals" field
                FieldMapping fieldMapping = fieldLookup["Digitals"];
                TypeMapping nestedMapping = GetTypeMapping(fieldMapping);

                PushRelativeFrame(fieldMapping);
                obj.Digitals = CreateECADigitals(nestedMapping);
                PopRelativeFrame(fieldMapping);
            }

            {
                // Create openLSE.Model.ECA.StatusWords UDT for "StatusWords" field
                FieldMapping fieldMapping = fieldLookup["StatusWords"];
                TypeMapping nestedMapping = GetTypeMapping(fieldMapping);

                PushRelativeFrame(fieldMapping);
                obj.StatusWords = CreateECAStatusWords(nestedMapping);
                PopRelativeFrame(fieldMapping);
            }

            {
                // Create openLSE.Model.ECA.PhasorCollection UDT for "VoltagePhasors" field
                FieldMapping fieldMapping = fieldLookup["VoltagePhasors"];
                TypeMapping nestedMapping = GetTypeMapping(fieldMapping);

                PushRelativeFrame(fieldMapping);
                obj.VoltagePhasors = CreateECAPhasorCollection(nestedMapping);
                PopRelativeFrame(fieldMapping);
            }

            {
                // Create openLSE.Model.ECA.PhasorCollection UDT for "CurrentPhasors" field
                FieldMapping fieldMapping = fieldLookup["CurrentPhasors"];
                TypeMapping nestedMapping = GetTypeMapping(fieldMapping);

                PushRelativeFrame(fieldMapping);
                obj.CurrentPhasors = CreateECAPhasorCollection(nestedMapping);
                PopRelativeFrame(fieldMapping);
            }

            return obj;
        }

        private openLSE.Model.LSE._InputMeta CreateLSE_InputMeta(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            openLSE.Model.LSE._InputMeta obj = new openLSE.Model.LSE._InputMeta();

            {
                // Create openLSE.Model.ECA._DigitalsMeta UDT for "Digitals" field
                FieldMapping fieldMapping = fieldLookup["Digitals"];
                TypeMapping nestedMapping = GetTypeMapping(fieldMapping);

                PushRelativeFrame(fieldMapping);
                obj.Digitals = CreateECA_DigitalsMeta(nestedMapping);
                PopRelativeFrame(fieldMapping);
            }

            {
                // Create openLSE.Model.ECA._StatusWordsMeta UDT for "StatusWords" field
                FieldMapping fieldMapping = fieldLookup["StatusWords"];
                TypeMapping nestedMapping = GetTypeMapping(fieldMapping);

                PushRelativeFrame(fieldMapping);
                obj.StatusWords = CreateECA_StatusWordsMeta(nestedMapping);
                PopRelativeFrame(fieldMapping);
            }

            {
                // Create openLSE.Model.ECA._PhasorCollectionMeta UDT for "VoltagePhasors" field
                FieldMapping fieldMapping = fieldLookup["VoltagePhasors"];
                TypeMapping nestedMapping = GetTypeMapping(fieldMapping);

                PushRelativeFrame(fieldMapping);
                obj.VoltagePhasors = CreateECA_PhasorCollectionMeta(nestedMapping);
                PopRelativeFrame(fieldMapping);
            }

            {
                // Create openLSE.Model.ECA._PhasorCollectionMeta UDT for "CurrentPhasors" field
                FieldMapping fieldMapping = fieldLookup["CurrentPhasors"];
                TypeMapping nestedMapping = GetTypeMapping(fieldMapping);

                PushRelativeFrame(fieldMapping);
                obj.CurrentPhasors = CreateECA_PhasorCollectionMeta(nestedMapping);
                PopRelativeFrame(fieldMapping);
            }

            return obj;
        }

        private openLSE.Model.ECA.Digitals CreateECADigitals(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            openLSE.Model.ECA.Digitals obj = new openLSE.Model.ECA.Digitals();

            {
                // Create double array for "Values" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["Values"];

                List<double> list = new List<double>();
                int count = GetArrayMeasurementCount(arrayMapping);

                for (int i = 0; i < count; i++)
                {
                    IMeasurement measurement = GetArrayMeasurement(i);
                    list.Add((double)measurement.Value);
                }

                obj.Values = list.ToArray();
            }

            return obj;
        }

        private openLSE.Model.ECA._DigitalsMeta CreateECA_DigitalsMeta(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            openLSE.Model.ECA._DigitalsMeta obj = new openLSE.Model.ECA._DigitalsMeta();

            {
                // Create MetaValues array for "Values" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["Values"];

                List<MetaValues> list = new List<MetaValues>();
                int count = GetArrayMeasurementCount(arrayMapping);

                for (int i = 0; i < count; i++)
                {
                    IMeasurement measurement = GetArrayMeasurement(i);
                    list.Add(GetMetaValues(measurement));
                }

                obj.Values = list.ToArray();
            }

            return obj;
        }

        private openLSE.Model.ECA.StatusWords CreateECAStatusWords(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            openLSE.Model.ECA.StatusWords obj = new openLSE.Model.ECA.StatusWords();

            {
                // Create double array for "Values" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["Values"];

                List<double> list = new List<double>();
                int count = GetArrayMeasurementCount(arrayMapping);

                for (int i = 0; i < count; i++)
                {
                    IMeasurement measurement = GetArrayMeasurement(i);
                    list.Add((double)measurement.Value);
                }

                obj.Values = list.ToArray();
            }

            return obj;
        }

        private openLSE.Model.ECA._StatusWordsMeta CreateECA_StatusWordsMeta(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            openLSE.Model.ECA._StatusWordsMeta obj = new openLSE.Model.ECA._StatusWordsMeta();

            {
                // Create MetaValues array for "Values" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["Values"];

                List<MetaValues> list = new List<MetaValues>();
                int count = GetArrayMeasurementCount(arrayMapping);

                for (int i = 0; i < count; i++)
                {
                    IMeasurement measurement = GetArrayMeasurement(i);
                    list.Add(GetMetaValues(measurement));
                }

                obj.Values = list.ToArray();
            }

            return obj;
        }

        private openLSE.Model.ECA.PhasorCollection CreateECAPhasorCollection(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            openLSE.Model.ECA.PhasorCollection obj = new openLSE.Model.ECA.PhasorCollection();

            {
                // Create openLSE.Model.ECA.Phasor UDT array for "Phasors" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["Phasors"];
                PushWindowFrame(arrayMapping);

                List<openLSE.Model.ECA.Phasor> list = new List<openLSE.Model.ECA.Phasor>();
                int count = GetUDTArrayTypeMappingCount(arrayMapping);

                for (int i = 0; i < count; i++)
                {
                    TypeMapping nestedMapping = GetUDTArrayTypeMapping(arrayMapping, i);
                    list.Add(CreateECAPhasor(nestedMapping));
                }

                obj.Phasors = list.ToArray();
                PopWindowFrame(arrayMapping);
            }

            return obj;
        }

        private openLSE.Model.ECA._PhasorCollectionMeta CreateECA_PhasorCollectionMeta(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            openLSE.Model.ECA._PhasorCollectionMeta obj = new openLSE.Model.ECA._PhasorCollectionMeta();

            {
                // Create openLSE.Model.ECA._PhasorMeta UDT array for "Phasors" field
                ArrayMapping arrayMapping = (ArrayMapping)fieldLookup["Phasors"];
                PushWindowFrame(arrayMapping);

                List<openLSE.Model.ECA._PhasorMeta> list = new List<openLSE.Model.ECA._PhasorMeta>();
                int count = GetUDTArrayTypeMappingCount(arrayMapping);

                for (int i = 0; i < count; i++)
                {
                    TypeMapping nestedMapping = GetUDTArrayTypeMapping(arrayMapping, i);
                    list.Add(CreateECA_PhasorMeta(nestedMapping));
                }

                obj.Phasors = list.ToArray();
                PopWindowFrame(arrayMapping);
            }

            return obj;
        }

        private openLSE.Model.ECA.Phasor CreateECAPhasor(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            openLSE.Model.ECA.Phasor obj = new openLSE.Model.ECA.Phasor();

            {
                // Assign double value to "Magnitude" field
                FieldMapping fieldMapping = fieldLookup["Magnitude"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.Magnitude = (double)measurement.Value;
            }

            {
                // Assign double value to "Angle" field
                FieldMapping fieldMapping = fieldLookup["Angle"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.Angle = (double)measurement.Value;
            }

            return obj;
        }

        private openLSE.Model.ECA._PhasorMeta CreateECA_PhasorMeta(TypeMapping typeMapping)
        {
            Dictionary<string, FieldMapping> fieldLookup = typeMapping.FieldMappings.ToDictionary(mapping => mapping.Field.Identifier);
            openLSE.Model.ECA._PhasorMeta obj = new openLSE.Model.ECA._PhasorMeta();

            {
                // Assign MetaValues value to "Magnitude" field
                FieldMapping fieldMapping = fieldLookup["Magnitude"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.Magnitude = GetMetaValues(measurement);
            }

            {
                // Assign MetaValues value to "Angle" field
                FieldMapping fieldMapping = fieldLookup["Angle"];
                IMeasurement measurement = GetMeasurement(fieldMapping);
                obj.Angle = GetMetaValues(measurement);
            }

            return obj;
        }

        #endregion
    }
}
