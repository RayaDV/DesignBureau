﻿namespace DesignBureau.Core.Models.Project
{
    public class ImageServiceModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
