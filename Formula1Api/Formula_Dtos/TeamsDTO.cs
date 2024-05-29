using Microsoft.AspNetCore.Mvc;

namespace Formula1Api.Formula_Dtos
{
      public class TeamsDTO
      {
        public string TeamName { get; set; }
        public int TeamTitleCount { get; set; }
        public string TeamPhoto { get; set; }
      }
}