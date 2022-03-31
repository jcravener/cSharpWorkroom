using GamesFunction.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesFunction.Models
{
    public static class TeeBoxes
    {
        public static List<TeeBox> _Aldarra = new List<TeeBox>
        {
            { new TeeBox($"{Courses.Aldarra}", Par.Aldarra, $"{AldarraTeeBoxNames.Aldarra}", 151, 74.9, Gender.Male) },
            { new TeeBox($"{Courses.Aldarra}", Par.Aldarra, $"{AldarraTeeBoxNames.Aldarra}", 154, 80.8, Gender.Female) },
            { new TeeBox($"{Courses.Aldarra}", Par.Aldarra, $"{AldarraTeeBoxNames.Championship}", 151, 78.2, Gender.Female) },
            { new TeeBox($"{Courses.Aldarra}", Par.Aldarra, $"{AldarraTeeBoxNames.ComboChampMember}", 142, 71.0, Gender.Male) },
            { new TeeBox($"{Courses.Aldarra}", Par.Aldarra, $"{AldarraTeeBoxNames.ComboChampMember}", 148, 77.0, Gender.Female) },
            { new TeeBox($"{Courses.Aldarra}", Par.Aldarra, $"{AldarraTeeBoxNames.Member}", 139, 70.6, Gender.Male) },
            { new TeeBox($"{Courses.Aldarra}", Par.Aldarra, $"{AldarraTeeBoxNames.Member}", 147, 76.6, Gender.Female) }
        };

        public static Dictionary<string, Dictionary<string, TeeBox>> Adarra = new Dictionary<string, Dictionary<string, TeeBox>>
        {
            { $"{Gender.Male}",
                new Dictionary<string, TeeBox>
                {
                    { $"{AldarraTeeBoxNames.Aldarra}", new TeeBox($"{Courses.Aldarra}", Par.Aldarra, $"{AldarraTeeBoxNames.Aldarra}", 151, 74.9, Gender.Male) },
                    { $"{AldarraTeeBoxNames.Championship}", new TeeBox($"{Courses.Aldarra}", Par.Aldarra, $"{AldarraTeeBoxNames.Championship}", 147, 72.9, Gender.Male) },
                    { $"{AldarraTeeBoxNames.ComboChampMember}", new TeeBox($"{Courses.Aldarra}", Par.Aldarra, $"{AldarraTeeBoxNames.ComboChampMember}", 142, 71.0, Gender.Male) },
                    { $"{AldarraTeeBoxNames.Member}", new TeeBox($"{Courses.Aldarra}", Par.Aldarra, $"{AldarraTeeBoxNames.Member}", 139, 70.6, Gender.Male) }
                }
            },
            { $"{Gender.Female}",
                new Dictionary<string, TeeBox>
                {
                    { $"{AldarraTeeBoxNames.Aldarra}", new TeeBox($"{Courses.Aldarra}", Par.Aldarra, $"{AldarraTeeBoxNames.Aldarra}", 154, 80.8, Gender.Female) },
                    { $"{AldarraTeeBoxNames.Championship}", new TeeBox($"{Courses.Aldarra}", Par.Aldarra, $"{AldarraTeeBoxNames.Championship}", 151, 78.2, Gender.Female) },
                    { $"{AldarraTeeBoxNames.ComboChampMember}", new TeeBox($"{Courses.Aldarra}", Par.Aldarra, $"{AldarraTeeBoxNames.ComboChampMember}", 148, 77.0, Gender.Female) },
                    { $"{AldarraTeeBoxNames.Member}", new TeeBox($"{Courses.Aldarra}", Par.Aldarra, $"{AldarraTeeBoxNames.Member}", 147, 76.6, Gender.Female) }
                }
            }
        };
    }
}
