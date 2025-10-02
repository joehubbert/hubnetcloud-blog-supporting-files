using CRM.Model;

namespace CRM.Helpers
{
    internal class UIModelHelper
    {
        private UIModel _uiModel = new UIModel();

        public DataSubjectLookupResultModel GetDataSubjectProperties(FunctionTitle dataSubject)
        {
            var dataSubjectEntry = _uiModel.DataSubjects
                .FirstOrDefault(x => x.DataSubject == dataSubject);

            if (dataSubjectEntry == null)
                return null;

            var result = new DataSubjectLookupResultModel
            {
                DataSubject = dataSubjectEntry
            };

            if (dataSubjectEntry.DataParentSubject.HasValue)
            {
                result.DataParentSubject = _uiModel.DataSubjects
                    .FirstOrDefault(x => x.DataSubject == dataSubjectEntry.DataParentSubject.Value);
            }

            return result;
        }

        public string GetModuleGroupValue(ModuleGroup moduleGroup, string propertyName)
        {
            var moduleGroupEntry = _uiModel.ModuleGroupFriendlyNames
                .FirstOrDefault(x => x.ModuleGroup == moduleGroup);

            if (moduleGroupEntry == null)
                return string.Empty;

            return propertyName.ToLower() switch
            {
                "modulegroupdatasubjectname" => moduleGroupEntry.ModuleGroupDataSubjectName,
                "modulegroupdatasubjectpluralname" => moduleGroupEntry.ModuleGroupDataSubjectPluralName,
                "modulegroupfriendlyname" => moduleGroupEntry.ModuleGroupFriendlyName,
                _ => string.Empty
            };
        }
    }
}
