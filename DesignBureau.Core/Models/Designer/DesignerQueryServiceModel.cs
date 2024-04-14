namespace DesignBureau.Core.Models.Designer
{
    public class DesignerQueryServiceModel
    {
        public int TotalTeamCount { get; set; }

        public IEnumerable<DesignerServiceModel> Team { get; set; }
            = new List<DesignerServiceModel>();
    }
}
